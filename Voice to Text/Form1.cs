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

namespace Voice_to_Text
{
    public partial class VoiceToText : Form
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

        public VoiceToText()
        {
            InitializeComponent();

            timer.Tick += new EventHandler(timer_Tick);
            wplayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wplayer_PlayStateChange);
            wplayer.CreateControl();
            wplayer.settings.volume = uxVolumeControl.Value * 10;

            comb.Location = new Point(300, 200);
            this.Controls.Add(comb);

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
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
            uxPlayButton.Enabled = false;
            uxPlayButton.BackColor = Color.LightGray;
            uxPauseButton.Enabled = false;
            uxPauseButton.BackColor = Color.LightGray;
            uxProgressBar.Enabled = false;
            uxSoundLabel.Enabled = false;
            uxVolumeControl.Enabled = false;

            if(NAudio.Wave.WaveIn.DeviceCount < 1)
            {
                MessageBox.Show("No microphone detected");
                return;
            }

            isRecording = true;
            waveIn = new WaveIn();
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
            if (uxExportAudioDialog.ShowDialog() == DialogResult.OK)
            {
                uxRecordButton.Enabled = false;
                uxRecordButton.BackColor = Color.LightGray;
                writer = new WaveFileWriter(uxExportAudioDialog.FileName, waveIn.WaveFormat);
                waveIn.StartRecording();
            }

            uxStopButton.Enabled = true;
            uxStopButton.BackColor = SystemColors.Highlight;
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
    }
}
