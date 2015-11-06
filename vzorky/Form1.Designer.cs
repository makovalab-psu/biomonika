namespace vzorky {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chooseSequenceDirectory = new System.Windows.Forms.Button();
            this.chooseExcelFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chooseSequenceDirectory
            // 
            this.chooseSequenceDirectory.BackColor = System.Drawing.Color.Lime;
            this.chooseSequenceDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chooseSequenceDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseSequenceDirectory.ForeColor = System.Drawing.Color.Black;
            this.chooseSequenceDirectory.Location = new System.Drawing.Point(21, 186);
            this.chooseSequenceDirectory.Name = "chooseSequenceDirectory";
            this.chooseSequenceDirectory.Size = new System.Drawing.Size(196, 23);
            this.chooseSequenceDirectory.TabIndex = 1;
            this.chooseSequenceDirectory.TabStop = false;
            this.chooseSequenceDirectory.Text = "vyber slozku se sekvencemi";
            this.chooseSequenceDirectory.UseVisualStyleBackColor = false;
            this.chooseSequenceDirectory.Click += new System.EventHandler(this.chooseSequenceDirectory_Click);
            // 
            // chooseExcelFile
            // 
            this.chooseExcelFile.BackColor = System.Drawing.Color.Lime;
            this.chooseExcelFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chooseExcelFile.Enabled = false;
            this.chooseExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseExcelFile.Location = new System.Drawing.Point(21, 227);
            this.chooseExcelFile.Name = "chooseExcelFile";
            this.chooseExcelFile.Size = new System.Drawing.Size(196, 23);
            this.chooseExcelFile.TabIndex = 1;
            this.chooseExcelFile.Text = "vyber CSV soubor";
            this.chooseExcelFile.UseVisualStyleBackColor = false;
            this.chooseExcelFile.Click += new System.EventHandler(this.chooseExcelFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 156);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(292, 285);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseSequenceDirectory);
            this.Controls.Add(this.chooseExcelFile);
            this.Name = "Form1";
            this.Text = "Roztřiď sekvence do složek";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseExcelFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chooseSequenceDirectory;
    }
}

