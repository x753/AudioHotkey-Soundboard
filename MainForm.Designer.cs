using System.Windows.Forms;

namespace AudioHotkeySoundboard
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.label1 = new System.Windows.Forms.Label();
      this.cbPlaybackDevices = new System.Windows.Forms.ComboBox();
      this.mainTimer = new System.Windows.Forms.Timer(this.components);
      this.btnRemove = new System.Windows.Forms.Button();
      this.btnEdit = new System.Windows.Forms.Button();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnLoad = new System.Windows.Forms.Button();
      this.btnReloadDevices = new System.Windows.Forms.Button();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnSaveAs = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.memoryManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.downloadVBAudioCableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.label2 = new System.Windows.Forms.Label();
      this.cbLoopbackDevices = new System.Windows.Forms.ComboBox();
      this.btnPlaySelectedSound = new System.Windows.Forms.Button();
      this.btnStopAllSounds = new System.Windows.Forms.Button();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.cbAudioDevices = new System.Windows.Forms.GroupBox();
      this.cbPlaybackDevices2 = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.dgvKeySounds = new System.Windows.Forms.DataGridView();
      this.columnSoundClips = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.columnKeys = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cbAudioOverdrive = new System.Windows.Forms.CheckBox();
      this.labelVolume = new System.Windows.Forms.Label();
      this.trackbarVolume = new System.Windows.Forms.TrackBar();
      this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.ToolTip2 = new System.Windows.Forms.ToolTip(this.components);
      this.ToolTip5 = new System.Windows.Forms.ToolTip(this.components);
      this.menuStrip1.SuspendLayout();
      this.cbAudioDevices.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvKeySounds)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackbarVolume)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(5, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(51, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "VB-Cable";
      this.ToolTip1.SetToolTip(this.label1, "This is the primary playback device, which is what other people will hear. This s" +
        "hould be your VB-Cable. ");
      // 
      // cbPlaybackDevices
      // 
      this.cbPlaybackDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbPlaybackDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbPlaybackDevices.FormattingEnabled = true;
      this.cbPlaybackDevices.Location = new System.Drawing.Point(71, 20);
      this.cbPlaybackDevices.Name = "cbPlaybackDevices";
      this.cbPlaybackDevices.Size = new System.Drawing.Size(225, 21);
      this.cbPlaybackDevices.TabIndex = 10;
      this.cbPlaybackDevices.TabStop = false;
      // 
      // mainTimer
      // 
      this.mainTimer.Interval = 50;
      this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
      // 
      // btnRemove
      // 
      this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRemove.Location = new System.Drawing.Point(612, 134);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(75, 43);
      this.btnRemove.TabIndex = 3;
      this.btnRemove.TabStop = false;
      this.btnRemove.Text = "Remove";
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
      // 
      // btnEdit
      // 
      this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnEdit.Location = new System.Drawing.Point(612, 85);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(75, 43);
      this.btnEdit.TabIndex = 2;
      this.btnEdit.TabStop = false;
      this.btnEdit.Text = "Edit";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAdd.Location = new System.Drawing.Point(612, 36);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 43);
      this.btnAdd.TabIndex = 1;
      this.btnAdd.TabStop = false;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnLoad
      // 
      this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnLoad.Location = new System.Drawing.Point(11, 350);
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.Size = new System.Drawing.Size(145, 23);
      this.btnLoad.TabIndex = 7;
      this.btnLoad.TabStop = false;
      this.btnLoad.Text = "Load";
      this.btnLoad.UseVisualStyleBackColor = true;
      this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
      // 
      // btnReloadDevices
      // 
      this.btnReloadDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnReloadDevices.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadDevices.Image")));
      this.btnReloadDevices.Location = new System.Drawing.Point(304, 20);
      this.btnReloadDevices.Name = "btnReloadDevices";
      this.btnReloadDevices.Size = new System.Drawing.Size(22, 75);
      this.btnReloadDevices.TabIndex = 12;
      this.btnReloadDevices.TabStop = false;
      this.btnReloadDevices.UseVisualStyleBackColor = true;
      this.btnReloadDevices.Click += new System.EventHandler(this.btnReloadDevices_Click);
      // 
      // btnClear
      // 
      this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClear.Location = new System.Drawing.Point(612, 183);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(75, 43);
      this.btnClear.TabIndex = 4;
      this.btnClear.TabStop = false;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnSaveAs
      // 
      this.btnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnSaveAs.Location = new System.Drawing.Point(163, 350);
      this.btnSaveAs.Name = "btnSaveAs";
      this.btnSaveAs.Size = new System.Drawing.Size(145, 23);
      this.btnSaveAs.TabIndex = 9;
      this.btnSaveAs.TabStop = false;
      this.btnSaveAs.Text = "Save As";
      this.btnSaveAs.UseVisualStyleBackColor = true;
      this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.memoryManagementToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem,
            this.downloadVBAudioCableToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(697, 24);
      this.menuStrip1.TabIndex = 17;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
      this.settingsToolStripMenuItem.Text = "Settings";
      this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
      // 
      // memoryManagementToolStripMenuItem
      // 
      this.memoryManagementToolStripMenuItem.Name = "memoryManagementToolStripMenuItem";
      this.memoryManagementToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
      this.memoryManagementToolStripMenuItem.Text = "Clear Memory";
      this.memoryManagementToolStripMenuItem.Click += new System.EventHandler(this.MemoryManagementToolStripMenuItem_Click);
      // 
      // checkForUpdateToolStripMenuItem
      // 
      this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
      this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
      this.checkForUpdateToolStripMenuItem.Text = "GitHub";
      this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
      // 
      // downloadVBAudioCableToolStripMenuItem
      // 
      this.downloadVBAudioCableToolStripMenuItem.Name = "downloadVBAudioCableToolStripMenuItem";
      this.downloadVBAudioCableToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
      this.downloadVBAudioCableToolStripMenuItem.Text = "VB-Audio Cable";
      this.downloadVBAudioCableToolStripMenuItem.Click += new System.EventHandler(this.DownloadVBAudioCableToolStripMenuItem_Click);
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(5, 77);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(63, 13);
      this.label2.TabIndex = 18;
      this.label2.Text = "Microphone";
      this.ToolTip2.SetToolTip(this.label2, "This is the audio device that gets injected into the primary playback device. Thi" +
        "s should be your microphone if you want to be able to talk as well as play sound" +
        "s.");
      // 
      // cbLoopbackDevices
      // 
      this.cbLoopbackDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbLoopbackDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbLoopbackDevices.FormattingEnabled = true;
      this.cbLoopbackDevices.Location = new System.Drawing.Point(71, 74);
      this.cbLoopbackDevices.Name = "cbLoopbackDevices";
      this.cbLoopbackDevices.Size = new System.Drawing.Size(225, 21);
      this.cbLoopbackDevices.TabIndex = 11;
      this.cbLoopbackDevices.TabStop = false;
      // 
      // btnPlaySelectedSound
      // 
      this.btnPlaySelectedSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnPlaySelectedSound.Location = new System.Drawing.Point(612, 248);
      this.btnPlaySelectedSound.Name = "btnPlaySelectedSound";
      this.btnPlaySelectedSound.Size = new System.Drawing.Size(75, 43);
      this.btnPlaySelectedSound.TabIndex = 5;
      this.btnPlaySelectedSound.TabStop = false;
      this.btnPlaySelectedSound.Text = "Play Sound";
      this.btnPlaySelectedSound.UseVisualStyleBackColor = true;
      this.btnPlaySelectedSound.Click += new System.EventHandler(this.btnPlaySound_Click);
      // 
      // btnStopAllSounds
      // 
      this.btnStopAllSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnStopAllSounds.Location = new System.Drawing.Point(612, 297);
      this.btnStopAllSounds.Name = "btnStopAllSounds";
      this.btnStopAllSounds.Size = new System.Drawing.Size(75, 43);
      this.btnStopAllSounds.TabIndex = 6;
      this.btnStopAllSounds.TabStop = false;
      this.btnStopAllSounds.Text = "Stop All Sounds";
      this.btnStopAllSounds.UseVisualStyleBackColor = true;
      this.btnStopAllSounds.Click += new System.EventHandler(this.btnStopAllSounds_Click);
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
      this.notifyIcon1.BalloonTipText = "Minimized to the tray.";
      this.notifyIcon1.BalloonTipTitle = "AudioHotkey";
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = "AudioHotkey";
      this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
      // 
      // cbAudioDevices
      // 
      this.cbAudioDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbAudioDevices.Controls.Add(this.cbPlaybackDevices2);
      this.cbAudioDevices.Controls.Add(this.label5);
      this.cbAudioDevices.Controls.Add(this.label1);
      this.cbAudioDevices.Controls.Add(this.label2);
      this.cbAudioDevices.Controls.Add(this.cbPlaybackDevices);
      this.cbAudioDevices.Controls.Add(this.cbLoopbackDevices);
      this.cbAudioDevices.Controls.Add(this.btnReloadDevices);
      this.cbAudioDevices.Location = new System.Drawing.Point(12, 385);
      this.cbAudioDevices.Name = "cbAudioDevices";
      this.cbAudioDevices.Size = new System.Drawing.Size(337, 105);
      this.cbAudioDevices.TabIndex = 10;
      this.cbAudioDevices.TabStop = false;
      this.cbAudioDevices.Text = "Audio Devices";
      // 
      // cbPlaybackDevices2
      // 
      this.cbPlaybackDevices2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbPlaybackDevices2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbPlaybackDevices2.FormattingEnabled = true;
      this.cbPlaybackDevices2.Location = new System.Drawing.Point(71, 47);
      this.cbPlaybackDevices2.Name = "cbPlaybackDevices2";
      this.cbPlaybackDevices2.Size = new System.Drawing.Size(225, 21);
      this.cbPlaybackDevices2.TabIndex = 20;
      this.cbPlaybackDevices2.TabStop = false;
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(5, 50);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(52, 13);
      this.label5.TabIndex = 19;
      this.label5.Text = "Speakers";
      this.ToolTip5.SetToolTip(this.label5, "This is the secondary playback device, which lets you listen to the sounds you\'re" +
        " playing. This should be your speakers or headphones.");
      // 
      // dgvKeySounds
      // 
      this.dgvKeySounds.AllowDrop = true;
      this.dgvKeySounds.AllowUserToAddRows = false;
      this.dgvKeySounds.AllowUserToDeleteRows = false;
      this.dgvKeySounds.AllowUserToResizeRows = false;
      this.dgvKeySounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvKeySounds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvKeySounds.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
      this.dgvKeySounds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dgvKeySounds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnSoundClips,
            this.columnKeys});
      this.dgvKeySounds.Location = new System.Drawing.Point(12, 36);
      this.dgvKeySounds.MultiSelect = false;
      this.dgvKeySounds.Name = "dgvKeySounds";
      this.dgvKeySounds.ReadOnly = true;
      this.dgvKeySounds.RowHeadersVisible = false;
      this.dgvKeySounds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.dgvKeySounds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvKeySounds.Size = new System.Drawing.Size(590, 304);
      this.dgvKeySounds.TabIndex = 18;
      this.dgvKeySounds.DragDrop += new System.Windows.Forms.DragEventHandler(this.DgvKeySounds_DragDrop);
      this.dgvKeySounds.DragEnter += new System.Windows.Forms.DragEventHandler(this.DgvKeySounds_DragEnter);
      this.dgvKeySounds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DgvKeySounds_KeyPress);
      this.dgvKeySounds.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvKeySounds_MouseDoubleClick);
      // 
      // columnSoundClips
      // 
      this.columnSoundClips.HeaderText = "Sound Clips";
      this.columnSoundClips.Name = "columnSoundClips";
      this.columnSoundClips.ReadOnly = true;
      this.columnSoundClips.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // columnKeys
      // 
      this.columnKeys.HeaderText = "Keys";
      this.columnKeys.Name = "columnKeys";
      this.columnKeys.ReadOnly = true;
      this.columnKeys.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
      this.groupBox1.Controls.Add(this.cbAudioOverdrive);
      this.groupBox1.Controls.Add(this.labelVolume);
      this.groupBox1.Controls.Add(this.trackbarVolume);
      this.groupBox1.Location = new System.Drawing.Point(355, 385);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(330, 105);
      this.groupBox1.TabIndex = 21;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Gain Control";
      // 
      // cbAudioOverdrive
      // 
      this.cbAudioOverdrive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbAudioOverdrive.AutoSize = true;
      this.cbAudioOverdrive.Location = new System.Drawing.Point(14, 75);
      this.cbAudioOverdrive.Name = "cbAudioOverdrive";
      this.cbAudioOverdrive.Size = new System.Drawing.Size(143, 17);
      this.cbAudioOverdrive.TabIndex = 10;
      this.cbAudioOverdrive.TabStop = false;
      this.cbAudioOverdrive.Text = "Go Even Further Beyond";
      this.cbAudioOverdrive.UseVisualStyleBackColor = true;
      this.cbAudioOverdrive.CheckedChanged += new System.EventHandler(this.CbAudioOverdrive_CheckedChanged);
      // 
      // labelVolume
      // 
      this.labelVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelVolume.Location = new System.Drawing.Point(238, 71);
      this.labelVolume.Name = "labelVolume";
      this.labelVolume.Size = new System.Drawing.Size(84, 23);
      this.labelVolume.TabIndex = 1;
      this.labelVolume.Text = "0 dB";
      this.labelVolume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // trackbarVolume
      // 
      this.trackbarVolume.BackColor = System.Drawing.SystemColors.Control;
      this.trackbarVolume.LargeChange = 0;
      this.trackbarVolume.Location = new System.Drawing.Point(6, 20);
      this.trackbarVolume.Maximum = 20;
      this.trackbarVolume.Minimum = -20;
      this.trackbarVolume.Name = "trackbarVolume";
      this.trackbarVolume.Size = new System.Drawing.Size(318, 45);
      this.trackbarVolume.TabIndex = 0;
      this.trackbarVolume.TabStop = false;
      this.trackbarVolume.TickFrequency = 10;
      this.trackbarVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
      this.trackbarVolume.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(697, 499);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.dgvKeySounds);
      this.Controls.Add(this.cbAudioDevices);
      this.Controls.Add(this.btnStopAllSounds);
      this.Controls.Add(this.btnPlaySelectedSound);
      this.Controls.Add(this.btnSaveAs);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.btnLoad);
      this.Controls.Add(this.btnRemove);
      this.Controls.Add(this.btnEdit);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new System.Drawing.Size(713, 538);
      this.Name = "MainForm";
      this.Text = "AudioHotkey Soundboard";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.cbFormClosed);
      this.Resize += new System.EventHandler(this.frmMain_Resize);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.cbAudioDevices.ResumeLayout(false);
      this.cbAudioDevices.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvKeySounds)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackbarVolume)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPlaybackDevices;
        private System.Windows.Forms.ComboBox cbPlaybackDevices2;
        internal System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnReloadDevices;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLoopbackDevices;
        private System.Windows.Forms.Button btnPlaySelectedSound;
        private System.Windows.Forms.Button btnStopAllSounds;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox cbAudioDevices;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.DataGridView dgvKeySounds;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSoundClips;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnKeys;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelVolume;
        public System.Windows.Forms.TrackBar trackbarVolume;
        public System.Windows.Forms.CheckBox cbAudioOverdrive;
        private ToolStripMenuItem memoryManagementToolStripMenuItem;
        private ToolTip ToolTip1;
        private ToolStripMenuItem downloadVBAudioCableToolStripMenuItem;
        private ToolTip ToolTip2;
        private ToolTip ToolTip5;
    }
}

