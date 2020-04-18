namespace AudioHotkeySoundboard
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbStopSoundKeys = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSoundboardFiles = new System.Windows.Forms.DataGridView();
            this.columnSoundboardFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnKeys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.cbPlaySoundsOverEachOther = new System.Windows.Forms.CheckBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPlaySelectionKeys = new System.Windows.Forms.TextBox();
            this.buttonClear2 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoundboardFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stop All Sounds Keys";
            // 
            // tbStopSoundKeys
            // 
            this.tbStopSoundKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStopSoundKeys.Location = new System.Drawing.Point(122, 12);
            this.tbStopSoundKeys.Name = "tbStopSoundKeys";
            this.tbStopSoundKeys.ReadOnly = true;
            this.tbStopSoundKeys.Size = new System.Drawing.Size(355, 20);
            this.tbStopSoundKeys.TabIndex = 0;
            this.tbStopSoundKeys.TabStop = false;
            this.tbStopSoundKeys.Enter += new System.EventHandler(this.tbStopSoundKeys_Enter);
            this.tbStopSoundKeys.Leave += new System.EventHandler(this.tbStopSoundKeys_Leave);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(393, 347);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(6, 201);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(87, 201);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.TabStop = false;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(168, 201);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.TabStop = false;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(474, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvSoundboardFiles);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 230);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Switch between saves with keybinds";
            // 
            // dgvSoundboardFiles
            // 
            this.dgvSoundboardFiles.AllowDrop = true;
            this.dgvSoundboardFiles.AllowUserToAddRows = false;
            this.dgvSoundboardFiles.AllowUserToDeleteRows = false;
            this.dgvSoundboardFiles.AllowUserToResizeRows = false;
            this.dgvSoundboardFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSoundboardFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSoundboardFiles.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSoundboardFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSoundboardFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnSoundboardFile,
            this.columnKeys});
            this.dgvSoundboardFiles.Location = new System.Drawing.Point(6, 19);
            this.dgvSoundboardFiles.MultiSelect = false;
            this.dgvSoundboardFiles.Name = "dgvSoundboardFiles";
            this.dgvSoundboardFiles.ReadOnly = true;
            this.dgvSoundboardFiles.RowHeadersVisible = false;
            this.dgvSoundboardFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSoundboardFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSoundboardFiles.Size = new System.Drawing.Size(522, 176);
            this.dgvSoundboardFiles.TabIndex = 19;
            this.dgvSoundboardFiles.TabStop = false;
            // 
            // columnSoundboardFile
            // 
            this.columnSoundboardFile.HeaderText = "Soundboard File";
            this.columnSoundboardFile.Name = "columnSoundboardFile";
            this.columnSoundboardFile.ReadOnly = true;
            // 
            // columnKeys
            // 
            this.columnKeys.HeaderText = "Keys";
            this.columnKeys.Name = "columnKeys";
            this.columnKeys.ReadOnly = true;
            // 
            // cbMinimizeToTray
            // 
            this.cbMinimizeToTray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbMinimizeToTray.AutoSize = true;
            this.cbMinimizeToTray.Location = new System.Drawing.Point(12, 323);
            this.cbMinimizeToTray.Name = "cbMinimizeToTray";
            this.cbMinimizeToTray.Size = new System.Drawing.Size(216, 17);
            this.cbMinimizeToTray.TabIndex = 5;
            this.cbMinimizeToTray.TabStop = false;
            this.cbMinimizeToTray.Text = "Minimize button sends application to tray";
            this.cbMinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // cbPlaySoundsOverEachOther
            // 
            this.cbPlaySoundsOverEachOther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbPlaySoundsOverEachOther.AutoSize = true;
            this.cbPlaySoundsOverEachOther.Location = new System.Drawing.Point(12, 346);
            this.cbPlaySoundsOverEachOther.Name = "cbPlaySoundsOverEachOther";
            this.cbPlaySoundsOverEachOther.Size = new System.Drawing.Size(161, 17);
            this.cbPlaySoundsOverEachOther.TabIndex = 9;
            this.cbPlaySoundsOverEachOther.TabStop = false;
            this.cbPlaySoundsOverEachOther.Text = "Play sounds over each other";
            this.cbPlaySoundsOverEachOther.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(483, 11);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(63, 22);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.TabStop = false;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Play Selection Keys";
            // 
            // tbPlaySelectionKeys
            // 
            this.tbPlaySelectionKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPlaySelectionKeys.Location = new System.Drawing.Point(122, 49);
            this.tbPlaySelectionKeys.Name = "tbPlaySelectionKeys";
            this.tbPlaySelectionKeys.ReadOnly = true;
            this.tbPlaySelectionKeys.Size = new System.Drawing.Size(355, 20);
            this.tbPlaySelectionKeys.TabIndex = 11;
            this.tbPlaySelectionKeys.TabStop = false;
            this.tbPlaySelectionKeys.Enter += new System.EventHandler(this.TbPlaySelectionKeys_Enter);
            this.tbPlaySelectionKeys.Leave += new System.EventHandler(this.TbPlaySelectionKeys_Leave);
            // 
            // buttonClear2
            // 
            this.buttonClear2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear2.Location = new System.Drawing.Point(483, 48);
            this.buttonClear2.Name = "buttonClear2";
            this.buttonClear2.Size = new System.Drawing.Size(63, 22);
            this.buttonClear2.TabIndex = 13;
            this.buttonClear2.TabStop = false;
            this.buttonClear2.Text = "Clear";
            this.buttonClear2.UseVisualStyleBackColor = true;
            this.buttonClear2.Click += new System.EventHandler(this.ButtonClear2_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 382);
            this.Controls.Add(this.buttonClear2);
            this.Controls.Add(this.tbPlaySelectionKeys);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.cbPlaySoundsOverEachOther);
            this.Controls.Add(this.cbMinimizeToTray);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbStopSoundKeys);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(577, 343);
            this.Name = "SettingsForm";
            this.Text = "Soundboard Settings";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoundboardFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStopSoundKeys;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbMinimizeToTray;
        private System.Windows.Forms.CheckBox cbPlaySoundsOverEachOther;
        internal System.Windows.Forms.DataGridView dgvSoundboardFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSoundboardFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnKeys;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPlaySelectionKeys;
        private System.Windows.Forms.Button buttonClear2;
        private System.Windows.Forms.Timer timer2;
    }
}