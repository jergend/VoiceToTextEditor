namespace Voice_to_Text
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uxFileMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTranscriptMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.printMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.findMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxExportTranscriptDialog = new System.Windows.Forms.SaveFileDialog();
            this.uxTextbox = new System.Windows.Forms.TextBox();
            this.uxProgressBar = new System.Windows.Forms.TrackBar();
            this.songTime = new System.Windows.Forms.Label();
            this.uxVolumeControl = new System.Windows.Forms.TrackBar();
            this.uxImportDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxPlayButton = new System.Windows.Forms.Button();
            this.uxStopButton = new System.Windows.Forms.Button();
            this.uxPauseButton = new System.Windows.Forms.Button();
            this.uxRecordButton = new System.Windows.Forms.Button();
            this.uxToolStrip = new System.Windows.Forms.ToolStrip();
            this.importTranscriptToolStripItem = new System.Windows.Forms.ToolStripButton();
            this.importAudioToolStripItem = new System.Windows.Forms.ToolStripButton();
            this.exportTranscriptToolStripItem = new System.Windows.Forms.ToolStripButton();
            this.printToolStripItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripItem = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripItem = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripItem = new System.Windows.Forms.ToolStripButton();
            this.uxPrintDialog = new System.Windows.Forms.PrintDialog();
            this.uxSoundLabel = new System.Windows.Forms.Label();
            this.uxTranscribeButton = new System.Windows.Forms.Button();
            this.uxExportAudioDialog = new System.Windows.Forms.SaveFileDialog();
            this.uxFontDialog = new System.Windows.Forms.FontDialog();
            this.uxFileMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxVolumeControl)).BeginInit();
            this.uxToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxFileMenu
            // 
            this.uxFileMenu.AutoSize = false;
            this.uxFileMenu.BackColor = System.Drawing.SystemColors.MenuBar;
            this.uxFileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formatToolStripMenuItem});
            this.uxFileMenu.Location = new System.Drawing.Point(0, 0);
            this.uxFileMenu.Name = "uxFileMenu";
            this.uxFileMenu.Size = new System.Drawing.Size(854, 24);
            this.uxFileMenu.TabIndex = 0;
            this.uxFileMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuStripItem,
            this.saveAsToolStripMenuItem,
            this.exportTranscriptMenuStripItem,
            this.toolStripMenuItem1,
            this.printMenuStripItem,
            this.toolStripMenuItem2,
            this.exitMenuStripItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openMenuStripItem
            // 
            this.openMenuStripItem.Name = "openMenuStripItem";
            this.openMenuStripItem.Size = new System.Drawing.Size(165, 22);
            this.openMenuStripItem.Text = "Open...";
            this.openMenuStripItem.Click += new System.EventHandler(this.openMenuStripItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.saveAsToolStripMenuItem.Text = "Import Transcript";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.importTranscriptMenuStripItem_Click);
            // 
            // exportTranscriptMenuStripItem
            // 
            this.exportTranscriptMenuStripItem.Name = "exportTranscriptMenuStripItem";
            this.exportTranscriptMenuStripItem.Size = new System.Drawing.Size(165, 22);
            this.exportTranscriptMenuStripItem.Text = "Export Transcript";
            this.exportTranscriptMenuStripItem.Click += new System.EventHandler(this.exportTranscriptMenuStripItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
            // 
            // printMenuStripItem
            // 
            this.printMenuStripItem.Name = "printMenuStripItem";
            this.printMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printMenuStripItem.Size = new System.Drawing.Size(165, 22);
            this.printMenuStripItem.Text = "Print";
            this.printMenuStripItem.Click += new System.EventHandler(this.printMenuStripItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(162, 6);
            // 
            // exitMenuStripItem
            // 
            this.exitMenuStripItem.Name = "exitMenuStripItem";
            this.exitMenuStripItem.Size = new System.Drawing.Size(165, 22);
            this.exitMenuStripItem.Text = "Exit";
            this.exitMenuStripItem.Click += new System.EventHandler(this.exitMenuStripItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutMenuStripItem,
            this.copyMenuStripItem,
            this.pasteMenuStripItem,
            this.toolStripMenuItem3,
            this.findMenuStripItem,
            this.replaceMenuStripItem,
            this.toolStripMenuItem4,
            this.selectAllMenuStripItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutMenuStripItem
            // 
            this.cutMenuStripItem.Enabled = false;
            this.cutMenuStripItem.Name = "cutMenuStripItem";
            this.cutMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutMenuStripItem.Size = new System.Drawing.Size(167, 22);
            this.cutMenuStripItem.Text = "Cut";
            this.cutMenuStripItem.Click += new System.EventHandler(this.cutMenuStripItem_Click);
            // 
            // copyMenuStripItem
            // 
            this.copyMenuStripItem.Enabled = false;
            this.copyMenuStripItem.Name = "copyMenuStripItem";
            this.copyMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyMenuStripItem.Size = new System.Drawing.Size(167, 22);
            this.copyMenuStripItem.Text = "Copy";
            this.copyMenuStripItem.Click += new System.EventHandler(this.copyMenuStripItem_Click);
            // 
            // pasteMenuStripItem
            // 
            this.pasteMenuStripItem.Name = "pasteMenuStripItem";
            this.pasteMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteMenuStripItem.Size = new System.Drawing.Size(167, 22);
            this.pasteMenuStripItem.Text = "Paste";
            this.pasteMenuStripItem.Click += new System.EventHandler(this.pasteMenuStripItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(164, 6);
            // 
            // findMenuStripItem
            // 
            this.findMenuStripItem.Enabled = false;
            this.findMenuStripItem.Name = "findMenuStripItem";
            this.findMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findMenuStripItem.Size = new System.Drawing.Size(167, 22);
            this.findMenuStripItem.Text = "Find...";
            this.findMenuStripItem.Click += new System.EventHandler(this.findMenuStripItem_Click);
            // 
            // replaceMenuStripItem
            // 
            this.replaceMenuStripItem.Enabled = false;
            this.replaceMenuStripItem.Name = "replaceMenuStripItem";
            this.replaceMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.replaceMenuStripItem.Size = new System.Drawing.Size(167, 22);
            this.replaceMenuStripItem.Text = "Replace...";
            this.replaceMenuStripItem.Click += new System.EventHandler(this.replaceMenuStripItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(164, 6);
            // 
            // selectAllMenuStripItem
            // 
            this.selectAllMenuStripItem.Name = "selectAllMenuStripItem";
            this.selectAllMenuStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllMenuStripItem.Size = new System.Drawing.Size(167, 22);
            this.selectAllMenuStripItem.Text = "Select All";
            this.selectAllMenuStripItem.Click += new System.EventHandler(this.selectAllMenuStripItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontMenuStripItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // fontMenuStripItem
            // 
            this.fontMenuStripItem.Name = "fontMenuStripItem";
            this.fontMenuStripItem.Size = new System.Drawing.Size(98, 22);
            this.fontMenuStripItem.Text = "Font";
            this.fontMenuStripItem.Click += new System.EventHandler(this.fontMenuStripItem_Click);
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.Filter = "WAV Files (*.wav)|*.wav|All files (*.*)|*.*";
            // 
            // uxExportTranscriptDialog
            // 
            this.uxExportTranscriptDialog.FileName = "Untitled";
            this.uxExportTranscriptDialog.Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*";
            // 
            // uxTextbox
            // 
            this.uxTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxTextbox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTextbox.Location = new System.Drawing.Point(0, 122);
            this.uxTextbox.Multiline = true;
            this.uxTextbox.Name = "uxTextbox";
            this.uxTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxTextbox.Size = new System.Drawing.Size(854, 465);
            this.uxTextbox.TabIndex = 1;
            this.uxTextbox.TextChanged += new System.EventHandler(this.uxTextbox_TextChanged);
            // 
            // uxProgressBar
            // 
            this.uxProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxProgressBar.AutoSize = false;
            this.uxProgressBar.BackColor = System.Drawing.SystemColors.Menu;
            this.uxProgressBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uxProgressBar.Enabled = false;
            this.uxProgressBar.Location = new System.Drawing.Point(52, 54);
            this.uxProgressBar.Name = "uxProgressBar";
            this.uxProgressBar.Size = new System.Drawing.Size(790, 21);
            this.uxProgressBar.TabIndex = 3;
            this.uxProgressBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.uxProgressBar.Scroll += new System.EventHandler(this.uxProgressBar_Scroll);
            // 
            // songTime
            // 
            this.songTime.AutoSize = true;
            this.songTime.BackColor = System.Drawing.Color.Transparent;
            this.songTime.Location = new System.Drawing.Point(12, 58);
            this.songTime.Name = "songTime";
            this.songTime.Size = new System.Drawing.Size(34, 13);
            this.songTime.TabIndex = 4;
            this.songTime.Text = "00:00";
            // 
            // uxVolumeControl
            // 
            this.uxVolumeControl.AutoSize = false;
            this.uxVolumeControl.BackColor = System.Drawing.SystemColors.Menu;
            this.uxVolumeControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uxVolumeControl.Enabled = false;
            this.uxVolumeControl.Location = new System.Drawing.Point(171, 73);
            this.uxVolumeControl.Name = "uxVolumeControl";
            this.uxVolumeControl.Size = new System.Drawing.Size(104, 45);
            this.uxVolumeControl.TabIndex = 5;
            this.uxVolumeControl.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.uxVolumeControl.Value = 5;
            this.uxVolumeControl.Scroll += new System.EventHandler(this.uxVolumeControl_Scroll);
            // 
            // uxImportDialog
            // 
            this.uxImportDialog.Filter = "Text Documents (*.txt)|*.txt";
            // 
            // uxPlayButton
            // 
            this.uxPlayButton.BackColor = System.Drawing.Color.LightGray;
            this.uxPlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uxPlayButton.Enabled = false;
            this.uxPlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uxPlayButton.ForeColor = System.Drawing.SystemColors.Window;
            this.uxPlayButton.Location = new System.Drawing.Point(12, 80);
            this.uxPlayButton.Name = "uxPlayButton";
            this.uxPlayButton.Size = new System.Drawing.Size(24, 24);
            this.uxPlayButton.TabIndex = 6;
            this.uxPlayButton.Text = "▶";
            this.uxPlayButton.UseVisualStyleBackColor = false;
            this.uxPlayButton.Click += new System.EventHandler(this.uxPlayButton_Click);
            // 
            // uxStopButton
            // 
            this.uxStopButton.BackColor = System.Drawing.Color.LightGray;
            this.uxStopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uxStopButton.Enabled = false;
            this.uxStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uxStopButton.ForeColor = System.Drawing.SystemColors.Window;
            this.uxStopButton.Location = new System.Drawing.Point(72, 80);
            this.uxStopButton.Name = "uxStopButton";
            this.uxStopButton.Size = new System.Drawing.Size(24, 24);
            this.uxStopButton.TabIndex = 7;
            this.uxStopButton.Text = "■";
            this.uxStopButton.UseVisualStyleBackColor = false;
            this.uxStopButton.Click += new System.EventHandler(this.uxStopButton_Click);
            // 
            // uxPauseButton
            // 
            this.uxPauseButton.BackColor = System.Drawing.Color.LightGray;
            this.uxPauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uxPauseButton.Enabled = false;
            this.uxPauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uxPauseButton.ForeColor = System.Drawing.SystemColors.Window;
            this.uxPauseButton.Location = new System.Drawing.Point(42, 80);
            this.uxPauseButton.Name = "uxPauseButton";
            this.uxPauseButton.Size = new System.Drawing.Size(24, 24);
            this.uxPauseButton.TabIndex = 8;
            this.uxPauseButton.Text = "▎ ▎";
            this.uxPauseButton.UseVisualStyleBackColor = false;
            this.uxPauseButton.Click += new System.EventHandler(this.uxPauseButton_Click);
            // 
            // uxRecordButton
            // 
            this.uxRecordButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.uxRecordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uxRecordButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uxRecordButton.ForeColor = System.Drawing.SystemColors.Window;
            this.uxRecordButton.Location = new System.Drawing.Point(102, 80);
            this.uxRecordButton.Name = "uxRecordButton";
            this.uxRecordButton.Size = new System.Drawing.Size(24, 24);
            this.uxRecordButton.TabIndex = 9;
            this.uxRecordButton.Text = "🔴";
            this.uxRecordButton.UseVisualStyleBackColor = false;
            this.uxRecordButton.Click += new System.EventHandler(this.uxRecordButton_Click);
            // 
            // uxToolStrip
            // 
            this.uxToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxToolStrip.AutoSize = false;
            this.uxToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.uxToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTranscriptToolStripItem,
            this.importAudioToolStripItem,
            this.exportTranscriptToolStripItem,
            this.printToolStripItem,
            this.toolStripSeparator1,
            this.cutToolStripItem,
            this.copyToolStripItem,
            this.pasteToolStripItem,
            this.toolStripSeparator2,
            this.helpToolStripItem});
            this.uxToolStrip.Location = new System.Drawing.Point(0, 24);
            this.uxToolStrip.Name = "uxToolStrip";
            this.uxToolStrip.Size = new System.Drawing.Size(854, 25);
            this.uxToolStrip.TabIndex = 10;
            this.uxToolStrip.Text = "toolStrip1";
            // 
            // importTranscriptToolStripItem
            // 
            this.importTranscriptToolStripItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importTranscriptToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("importTranscriptToolStripItem.Image")));
            this.importTranscriptToolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importTranscriptToolStripItem.Name = "importTranscriptToolStripItem";
            this.importTranscriptToolStripItem.Size = new System.Drawing.Size(23, 22);
            this.importTranscriptToolStripItem.Text = "Import Transcript";
            this.importTranscriptToolStripItem.Click += new System.EventHandler(this.importTranscriptMenuStripItem_Click);
            // 
            // importAudioToolStripItem
            // 
            this.importAudioToolStripItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importAudioToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("importAudioToolStripItem.Image")));
            this.importAudioToolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importAudioToolStripItem.Name = "importAudioToolStripItem";
            this.importAudioToolStripItem.Size = new System.Drawing.Size(23, 22);
            this.importAudioToolStripItem.Text = "Import Audio";
            this.importAudioToolStripItem.Click += new System.EventHandler(this.openMenuStripItem_Click);
            // 
            // exportTranscriptToolStripItem
            // 
            this.exportTranscriptToolStripItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportTranscriptToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("exportTranscriptToolStripItem.Image")));
            this.exportTranscriptToolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportTranscriptToolStripItem.Name = "exportTranscriptToolStripItem";
            this.exportTranscriptToolStripItem.Size = new System.Drawing.Size(23, 22);
            this.exportTranscriptToolStripItem.Text = "Export Transcript";
            this.exportTranscriptToolStripItem.Click += new System.EventHandler(this.exportTranscriptMenuStripItem_Click);
            // 
            // printToolStripItem
            // 
            this.printToolStripItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripItem.Image")));
            this.printToolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripItem.Name = "printToolStripItem";
            this.printToolStripItem.Size = new System.Drawing.Size(23, 22);
            this.printToolStripItem.Text = "Print";
            this.printToolStripItem.Click += new System.EventHandler(this.printMenuStripItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripItem
            // 
            this.cutToolStripItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripItem.Image")));
            this.cutToolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripItem.Name = "cutToolStripItem";
            this.cutToolStripItem.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripItem.Text = "Cut";
            this.cutToolStripItem.Click += new System.EventHandler(this.cutMenuStripItem_Click);
            // 
            // copyToolStripItem
            // 
            this.copyToolStripItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripItem.Image")));
            this.copyToolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripItem.Name = "copyToolStripItem";
            this.copyToolStripItem.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripItem.Text = "Copy";
            this.copyToolStripItem.Click += new System.EventHandler(this.copyMenuStripItem_Click);
            // 
            // pasteToolStripItem
            // 
            this.pasteToolStripItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripItem.Image")));
            this.pasteToolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripItem.Name = "pasteToolStripItem";
            this.pasteToolStripItem.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripItem.Text = "Paste";
            this.pasteToolStripItem.Click += new System.EventHandler(this.pasteMenuStripItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripItem
            // 
            this.helpToolStripItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripItem.Image")));
            this.helpToolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripItem.Name = "helpToolStripItem";
            this.helpToolStripItem.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripItem.Text = "Help";
            this.helpToolStripItem.Click += new System.EventHandler(this.helpToolStripItem_Click);
            // 
            // uxPrintDialog
            // 
            this.uxPrintDialog.AllowSomePages = true;
            this.uxPrintDialog.ShowHelp = true;
            this.uxPrintDialog.UseEXDialog = true;
            // 
            // uxSoundLabel
            // 
            this.uxSoundLabel.AutoSize = true;
            this.uxSoundLabel.BackColor = System.Drawing.Color.Transparent;
            this.uxSoundLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uxSoundLabel.Enabled = false;
            this.uxSoundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSoundLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.uxSoundLabel.Location = new System.Drawing.Point(138, 78);
            this.uxSoundLabel.Name = "uxSoundLabel";
            this.uxSoundLabel.Size = new System.Drawing.Size(32, 29);
            this.uxSoundLabel.TabIndex = 11;
            this.uxSoundLabel.Text = "🔊";
            this.uxSoundLabel.Click += new System.EventHandler(this.uxSoundLabel_Click);
            // 
            // uxTranscribeButton
            // 
            this.uxTranscribeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxTranscribeButton.BackColor = System.Drawing.Color.LightGray;
            this.uxTranscribeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uxTranscribeButton.Enabled = false;
            this.uxTranscribeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uxTranscribeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTranscribeButton.ForeColor = System.Drawing.Color.White;
            this.uxTranscribeButton.Location = new System.Drawing.Point(731, 80);
            this.uxTranscribeButton.Name = "uxTranscribeButton";
            this.uxTranscribeButton.Size = new System.Drawing.Size(102, 24);
            this.uxTranscribeButton.TabIndex = 12;
            this.uxTranscribeButton.Text = "Transcribe";
            this.uxTranscribeButton.UseVisualStyleBackColor = false;
            this.uxTranscribeButton.Click += new System.EventHandler(this.uxTranscribeButton_Click);
            // 
            // uxExportAudioDialog
            // 
            this.uxExportAudioDialog.Filter = "WAV files (*.wav)|*.wav";
            // 
            // uxFontDialog
            // 
            this.uxFontDialog.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFontDialog.ShowEffects = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(854, 588);
            this.Controls.Add(this.uxVolumeControl);
            this.Controls.Add(this.uxTranscribeButton);
            this.Controls.Add(this.uxSoundLabel);
            this.Controls.Add(this.uxToolStrip);
            this.Controls.Add(this.uxRecordButton);
            this.Controls.Add(this.uxPauseButton);
            this.Controls.Add(this.uxStopButton);
            this.Controls.Add(this.uxPlayButton);
            this.Controls.Add(this.songTime);
            this.Controls.Add(this.uxProgressBar);
            this.Controls.Add(this.uxTextbox);
            this.Controls.Add(this.uxFileMenu);
            this.MainMenuStrip = this.uxFileMenu;
            this.Name = "MainForm";
            this.Text = "Voice to Text Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.uxFileMenu.ResumeLayout(false);
            this.uxFileMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxVolumeControl)).EndInit();
            this.uxToolStrip.ResumeLayout(false);
            this.uxToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip uxFileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.SaveFileDialog uxExportTranscriptDialog;
        private System.Windows.Forms.TextBox uxTextbox;
        private System.Windows.Forms.TrackBar uxProgressBar;
        private System.Windows.Forms.ToolStripMenuItem exportTranscriptMenuStripItem;
        private System.Windows.Forms.Label songTime;
        private System.Windows.Forms.TrackBar uxVolumeControl;
        private System.Windows.Forms.OpenFileDialog uxImportDialog;
        private System.Windows.Forms.Button uxPlayButton;
        private System.Windows.Forms.Button uxStopButton;
        private System.Windows.Forms.Button uxPauseButton;
        private System.Windows.Forms.Button uxRecordButton;
        private System.Windows.Forms.ToolStrip uxToolStrip;
        private System.Windows.Forms.ToolStripButton importTranscriptToolStripItem;
        private System.Windows.Forms.ToolStripButton importAudioToolStripItem;
        private System.Windows.Forms.ToolStripButton exportTranscriptToolStripItem;
        private System.Windows.Forms.ToolStripButton printToolStripItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cutToolStripItem;
        private System.Windows.Forms.ToolStripButton copyToolStripItem;
        private System.Windows.Forms.ToolStripButton pasteToolStripItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton helpToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem copyMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem pasteMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem printMenuStripItem;
        private System.Windows.Forms.PrintDialog uxPrintDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitMenuStripItem;
        private System.Windows.Forms.Label uxSoundLabel;
        private System.Windows.Forms.Button uxTranscribeButton;
        private System.Windows.Forms.SaveFileDialog uxExportAudioDialog;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontMenuStripItem;
        private System.Windows.Forms.FontDialog uxFontDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem findMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem replaceMenuStripItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem selectAllMenuStripItem;
    }
}

