namespace AudioHotkeySoundboard
{
    partial class AddEditHotkeyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditHotkeyForm));
            this.tbKeys = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLoc = new System.Windows.Forms.Label();
            this.btnBrowseSoundLoc = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbKeys
            // 
            this.tbKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKeys.Location = new System.Drawing.Point(14, 76);
            this.tbKeys.Name = "tbKeys";
            this.tbKeys.ReadOnly = true;
            this.tbKeys.Size = new System.Drawing.Size(349, 20);
            this.tbKeys.TabIndex = 2;
            this.tbKeys.TabStop = false;
            this.tbKeys.Enter += new System.EventHandler(this.tbKeys_Enter);
            this.tbKeys.Leave += new System.EventHandler(this.tbKeys_Leave);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(276, 110);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(357, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbLocation
            // 
            this.tbLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLocation.Location = new System.Drawing.Point(14, 25);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(349, 20);
            this.tbLocation.TabIndex = 0;
            this.tbLocation.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Keys (click on text box then press desired keys)";
            // 
            // labelLoc
            // 
            this.labelLoc.AutoSize = true;
            this.labelLoc.Location = new System.Drawing.Point(11, 9);
            this.labelLoc.Name = "labelLoc";
            this.labelLoc.Size = new System.Drawing.Size(76, 13);
            this.labelLoc.TabIndex = 5;
            this.labelLoc.Text = "Location of file";
            // 
            // btnBrowseSoundLoc
            // 
            this.btnBrowseSoundLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSoundLoc.Location = new System.Drawing.Point(369, 24);
            this.btnBrowseSoundLoc.Name = "btnBrowseSoundLoc";
            this.btnBrowseSoundLoc.Size = new System.Drawing.Size(63, 22);
            this.btnBrowseSoundLoc.TabIndex = 1;
            this.btnBrowseSoundLoc.TabStop = false;
            this.btnBrowseSoundLoc.Text = "Browse";
            this.btnBrowseSoundLoc.UseVisualStyleBackColor = true;
            this.btnBrowseSoundLoc.Click += new System.EventHandler(this.btnBrowseSoundLoc_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(369, 75);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(63, 22);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.TabStop = false;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // AddEditHotkeyForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(444, 141);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.btnBrowseSoundLoc);
            this.Controls.Add(this.labelLoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbKeys);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(460, 180);
            this.Name = "AddEditHotkeyForm";
            this.Text = "Add / Edit Sound";
            this.Load += new System.EventHandler(this.AddEditSoundKeys_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbKeys;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLoc;
        private System.Windows.Forms.Button btnBrowseSoundLoc;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button buttonClear;
    }
}