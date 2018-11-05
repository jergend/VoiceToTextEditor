using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Speech.V1;
using Google.Apis.Auth.OAuth2;
using NAudio.Wave;
using System.Collections;

namespace Voice_to_Text
{
    /*              NuGet Packages                  *
     * Install-Package Google.Cloud.Speech.V1 -Pre  *
     * Install-Package NAudio -Version 1.8.4        */

    public partial class MainForm : Form
    {
        AxWMPLib.AxWindowsMediaPlayer wplayer = new AxWMPLib.AxWindowsMediaPlayer();
        Timer timer = new Timer();

        myComboBox comb = new myComboBox();

        PrintDocument pd = new PrintDocument();

        bool isMuted = false;
        int volume;

        WaveIn waveIn;
        WaveFileWriter writer;

        bool isRecording = false;
        bool hasRecorded = false;

        string savedText = "";

        private Stack _editHistory = new Stack();
        private Stack _undoHistory = new Stack();
        private string _lastText = "";

        public TextBox TextBox
        {
            get
            {
                return uxTextbox;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            timer.Tick += new EventHandler(timer_Tick);
            wplayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wplayer_PlayStateChange);
            wplayer.CreateControl();
            wplayer.settings.volume = uxVolumeControl.Value * 10;

            comb.Location = new Point(300, 200);
            this.Controls.Add(comb);

            pd.DocumentName = "Print Document";

            volume = uxVolumeControl.Value;

            waveIn = new WaveIn();
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
        }

        private void openMenuStripItem_Click(object sender, EventArgs e)
        {
            if(uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                wplayer.URL = uxOpenDialog.FileName;
                wplayer.Ctlcontrols.stop();
                uxTranscribeButton.Enabled = true;
                uxPlayButton.Enabled = true;
                uxPauseButton.Enabled = true;
                uxStopButton.Enabled = true;           
                uxSoundLabel.Enabled = true;
                uxVolumeControl.Enabled = true;
                uxTranscribeButton.BackColor = SystemColors.Highlight;
                uxPlayButton.BackColor = SystemColors.Highlight;
                uxPauseButton.BackColor = SystemColors.Highlight;
                uxStopButton.BackColor = SystemColors.Highlight;
                hasRecorded = false;
            }
        }

        private void importTranscriptMenuStripItem_Click(object sender, EventArgs e)
        {
            if (savedText != uxTextbox.Text)
            {
                DialogResult exit = MessageBox.Show("Do you want to save changes to " + uxExportTranscriptDialog.FileName + "?",
                    "Voice To Text Editor", MessageBoxButtons.YesNoCancel);

                if (exit == DialogResult.Yes)
                {
                    if (uxExportTranscriptDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fn = uxExportTranscriptDialog.FileName;
                        string contents = uxTextbox.Text;

                        try
                        {
                            File.WriteAllText(fn, contents);
                            savedText = contents;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                else if(exit == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (uxImportDialog.ShowDialog() == DialogResult.OK)
            {
                string fn = uxImportDialog.FileName;
                string contents = File.ReadAllText(fn);

                try
                {
                    uxTextbox.Text = contents;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void exportTranscriptMenuStripItem_Click(object sender, EventArgs e)
        {
            if (uxExportTranscriptDialog.ShowDialog() == DialogResult.OK)
            {
                string fn = uxExportTranscriptDialog.FileName;
                string contents = uxTextbox.Text;

                try
                {
                    File.WriteAllText(fn, contents);
                    savedText = contents;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void pageSetupMenuStripItem_Click(object sender, EventArgs e)
        {
            uxPageSetupDialog.Document = pd;

            if(uxPageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                pd.DefaultPageSettings = uxPageSetupDialog.PageSettings;
                pd.PrinterSettings = uxPageSetupDialog.PrinterSettings;
            }
        }

        private void printMenuStripItem_Click(object sender, EventArgs e)
        {
            uxPrintDialog.Document = pd;
            if (uxPrintDialog.ShowDialog() == DialogResult.OK)
                pd.Print();
        }

        private void exitMenuStripItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoMenuStripItem_Click(object sender, EventArgs e)
        {
            string editStr = (string)_editHistory.Pop(); // The string inserted or deleted by the edit being undone.
            int loc = (int)_editHistory.Pop(); // The location of the edit to be undone
            bool isDel = (bool)_editHistory.Pop(); // Indicates whether the edit to be undone was a deletion
            DoEdit(uxTextbox, !isDel, loc, editStr); // Does the opposite of the edit being undone.

            _undoHistory.Push(editStr);
            _undoHistory.Push(loc);
            _undoHistory.Push(isDel);
            redoMenuStripItem.Enabled = true;
            if (_editHistory.Count >= 1)
            {
                undoMenuStripItem.Enabled = true;
            }
            else
            {
                undoMenuStripItem.Enabled = false;
            }
        }

        private void redoMenuStripItem_Click(object sender, EventArgs e)
        {
            bool isDel = (bool)_undoHistory.Pop(); // Indicates whether the edit to be redone was a deletion
            int loc = (int)_undoHistory.Pop(); // The location of the edit to be redone
            string editStr = (string)_undoHistory.Pop(); // The string inserted or deleted by the edit being redone.
            DoEdit(uxTextbox, isDel, loc, editStr); // Does the edit being redone.

            _editHistory.Push(isDel);
            _editHistory.Push(loc);
            _editHistory.Push(editStr);
            undoMenuStripItem.Enabled = true;
            if (_undoHistory.Count >= 1)
            {
                redoMenuStripItem.Enabled = true;
            }
            else
            {
                redoMenuStripItem.Enabled = false;
            }
        }

        private void cutMenuStripItem_Click(object sender, EventArgs e)
        {
            Control ctrl = this.ActiveControl;
            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    TextBox tx = (TextBox)ctrl;
                    tx.Cut();
                }
                if (ctrl is myComboBox)
                {
                    myComboBox cb = (myComboBox)ctrl;
                    cb.Cut();
                }
            }
        }

        private void copyMenuStripItem_Click(object sender, EventArgs e)
        {
            Control ctrl = this.ActiveControl;
            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    TextBox tx = (TextBox)ctrl;
                    tx.Copy();
                }
                if (ctrl is myComboBox)
                {
                    myComboBox cb = (myComboBox)ctrl;
                    cb.Copy();
                }
            }
        }

        private void pasteMenuStripItem_Click(object sender, EventArgs e)
        {
            Control ctrl = this.ActiveControl;
            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    TextBox tx = (TextBox)ctrl;
                    tx.Paste();
                }
                if (ctrl is myComboBox)
                {
                    myComboBox cb = (myComboBox)ctrl;
                    cb.Paste();
                }
            }
        }

        private void findMenuStripItem_Click(object sender, EventArgs e)
        {
            FindForm ff = new FindForm(this);
            ff.Show();
        }

        private void replaceMenuStripItem_Click(object sender, EventArgs e)
        {
            ReplaceForm rf = new ReplaceForm(this);
            rf.Show();
        }

        private void selectAllMenuStripItem_Click(object sender, EventArgs e)
        {
            uxTextbox.SelectAll();
            uxTextbox.Focus();
        }

        private void wordWrapMenuStripItem_Click(object sender, EventArgs e)
        {
            uxTextbox.WordWrap = wordWrapMenuStripItem.Checked;
        }

        private void fontMenuStripItem_Click(object sender, EventArgs e)
        {
            if (uxFontDialog.ShowDialog() == DialogResult.OK)
            {
                uxTextbox.Font = uxFontDialog.Font;
            }
        }

        private void helpToolStripItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I don't know man, Google it.");
        }

        private void uxProgressBar_Scroll(object sender, EventArgs e)
        {
            wplayer.Ctlcontrols.currentPosition = uxProgressBar.Value;
            TimeSpan soundTime = TimeSpan.FromSeconds(wplayer.Ctlcontrols.currentPosition);
            songTime.Text = soundTime.ToString(@"mm\:ss");
        }

        private void uxPlayButton_Click(object sender, EventArgs e)
        {
            uxProgressBar.Enabled = true;
            timer.Interval = 1000;
            wplayer.Ctlcontrols.play();   
            timer.Start();
        }

        private void uxPauseButton_Click(object sender, EventArgs e)
        {
            wplayer.Ctlcontrols.pause();
            timer.Stop();
        }

        private void uxStopButton_Click(object sender, EventArgs e)
        {
            if(!isRecording)
            {
                wplayer.Ctlcontrols.stop();
                timer.Stop();
                songTime.Text = "00:00";
                uxProgressBar.Value = 0;
            }
            else
            {
                isRecording = false;

                waveIn.StopRecording();

                uxTranscribeButton.Enabled = true;
                uxTranscribeButton.BackColor = SystemColors.Highlight;
                uxRecordButton.Enabled = true;
                uxRecordButton.BackColor = SystemColors.Highlight;
                uxPlayButton.Enabled = true;
                uxPlayButton.BackColor = SystemColors.Highlight;
                uxPauseButton.Enabled = true;
                uxPauseButton.BackColor = SystemColors.Highlight;
                uxProgressBar.Enabled = true;
                uxSoundLabel.Enabled = true;
                uxVolumeControl.Enabled = true;

                wplayer.URL = uxExportAudioDialog.FileName;
                hasRecorded = true;
                wplayer.Ctlcontrols.stop();
            }
        }

        private void uxRecordButton_Click(object sender, EventArgs e)
        {
            if(NAudio.Wave.WaveIn.DeviceCount < 1)
            {
                MessageBox.Show("No microphone detected");
                return;
            }
            
            if (uxExportAudioDialog.ShowDialog() == DialogResult.OK)
            {
                uxPlayButton.Enabled = false;
                uxPlayButton.BackColor = Color.LightGray;
                uxPauseButton.Enabled = false;
                uxPauseButton.BackColor = Color.LightGray;
                uxProgressBar.Enabled = false;
                uxSoundLabel.Enabled = false;
                uxVolumeControl.Enabled = false;

                isRecording = true;
                waveIn = new WaveIn();
                waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
                waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);
                waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);

                uxRecordButton.Enabled = false;
                uxRecordButton.BackColor = Color.LightGray;
                wplayer.URL = "";
                writer = new WaveFileWriter(uxExportAudioDialog.FileName, waveIn.WaveFormat);
                waveIn.StartRecording();

                uxStopButton.Enabled = true;
                uxStopButton.BackColor = SystemColors.Highlight;
            }
        }

        private void uxSoundLabel_Click(object sender, EventArgs e)
        {
            if (!isMuted)
            {
                volume = uxVolumeControl.Value;
                uxVolumeControl.Value = 0;
                uxSoundLabel.Text = "🔇";
                isMuted = true;
            }
            else
            {
                uxVolumeControl.Value = volume;
                uxSoundLabel.Text = "🔊";
                isMuted = false;
            }
        }

        private void uxVolumeControl_Scroll(object sender, EventArgs e)
        {
            wplayer.settings.volume = uxVolumeControl.Value * 10;
            volume = uxVolumeControl.Value;
            if (uxVolumeControl.Value == 0)
            {
                isMuted = true;
                uxSoundLabel.Text = "🔇";
            }
            else
            {
                isMuted = false;
                uxSoundLabel.Text = "🔊";
            }
        }

        private void uxTranscribeButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                TranscribeAudio(uxOpenDialog.FileName);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                uxRecordButton.Enabled = true;
                uxRecordButton.BackColor = SystemColors.Highlight;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            uxProgressBar.Maximum = Convert.ToInt32(wplayer.Ctlcontrols.currentItem.duration);
            if (uxProgressBar.Value <= uxProgressBar.Maximum)
            {
                uxProgressBar.Value = (int)wplayer.Ctlcontrols.currentPosition;
            }
            TimeSpan soundTime = TimeSpan.FromSeconds(wplayer.Ctlcontrols.currentPosition);
            songTime.Text = soundTime.ToString(@"mm\:ss");
        }

        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if(writer != null)
            {
                writer.Write(e.Buffer, 0, e.BytesRecorded);
                writer.Flush();
            }
        }

        private void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if(waveIn != null)
            {
                waveIn.Dispose();
                waveIn = null;
            }
            if(writer != null)
            {
                writer.Dispose();
                writer = null;
            }

            uxRecordButton.Enabled = true;
            uxRecordButton.BackColor = SystemColors.Highlight;
        }

        private void wplayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(wplayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                uxRecordButton.Enabled = false;
                uxRecordButton.BackColor = Color.LightGray;
            }
            else
            {
                uxRecordButton.Enabled = true;
                uxRecordButton.BackColor = SystemColors.Highlight;
            }
        }

        private void TranscribeAudio(string fn)
        {
            uxTextbox.Text = "";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "MyProject31047-87c642b30d06.json");
            var speech = SpeechClient.Create();
            if(hasRecorded)
            {
                var response = speech.Recognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    SampleRateHertz = 16000,
                    LanguageCode = "en",
                }, RecognitionAudio.FromFile(uxExportAudioDialog.FileName));
                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        uxTextbox.Text += alternative.Transcript;
                    }
                }
            }
            else if(fn != "")
            {
                var response = speech.Recognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    SampleRateHertz = 16000,
                    LanguageCode = "en",
                    EnableAutomaticPunctuation = true,
                }, RecognitionAudio.FromFile(fn));
                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        uxTextbox.Text += alternative.Transcript;
                    }
                }
            }
            else
            {
                MessageBox.Show("No Audio File Found");
            }
        }

        private void uxTextbox_TextChanged(object sender, EventArgs e)
        {
            if(uxTextbox.Text.Length != 0)
            {
                cutMenuStripItem.Enabled = true;
                copyMenuStripItem.Enabled = true;
                findMenuStripItem.Enabled = true;
                replaceMenuStripItem.Enabled = true;
            }
            
            if(uxTextbox.Modified)
            {
                RecordEdit();
            }
        }

        private void RecordEdit()
        {
            bool isDel = IsDeletion(uxTextbox, _lastText); // Indicates whether the edit was a deletion
            int len = GetEditLength(uxTextbox, _lastText); // The length of the string inserted or deleted
            int loc = GetEditLocation(uxTextbox, isDel, len); // The location of the edit
            string text = uxTextbox.Text; // The current editor content
            string editStr = GetEditString(text, _lastText, isDel, loc, len); // The string deleted or inserted
            _lastText = text;

            _editHistory.Push(isDel);
            _editHistory.Push(loc);
            _editHistory.Push(editStr);
            _undoHistory.Clear();
            undoMenuStripItem.Enabled = true;
            redoMenuStripItem.Enabled = false;
        }

        private bool IsDeletion(TextBox editor, string lastContent)
        {
            return editor.TextLength < lastContent.Length;
        }

        private int GetEditLength(TextBox editor, string lastContent)
        {
            return Math.Abs(editor.TextLength - lastContent.Length);
        }

        private int GetEditLocation(TextBox editor, bool isDeletion, int len)
        {
            if (isDeletion)
            {
                return editor.SelectionStart;
            }
            else
            {
                return editor.SelectionStart - len;
            }
        }

        private string GetEditString(string content, string lastContent, bool isDeletion, int editLocation, int len)
        {
            if (isDeletion)
            {
                return lastContent.Substring(editLocation, len);
            }
            else
            {
                return content.Substring(editLocation, len);
            }
        }

        private void DoEdit(TextBox editor, bool isDeletion, int loc, string text)
        {
            if (isDeletion)
            {
                _lastText = editor.Text.Remove(loc, text.Length);
                editor.Text = _lastText;
                editor.SelectionStart = loc;
            }
            else
            {
                _lastText = editor.Text.Insert(loc, text);
                editor.Text = _lastText;
                editor.SelectionStart = loc + text.Length;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(savedText != uxTextbox.Text)
            {
                DialogResult exit = MessageBox.Show("Do you want to save changes to " + uxExportTranscriptDialog.FileName + "?",
                    "Voice To Text Editor", MessageBoxButtons.YesNoCancel);

                if(exit == DialogResult.Yes)
                {
                    if (uxExportTranscriptDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fn = uxExportTranscriptDialog.FileName;
                        string contents = uxTextbox.Text;

                        try
                        {
                            File.WriteAllText(fn, contents);
                            savedText = contents;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else if(exit == DialogResult.No)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
