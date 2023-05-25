namespace KeboardHookAndCodeToHtml
{
    partial class CopyConvert
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
            checkBoxLineNumbers = new CheckBox();
            chkSwiftAns = new CheckBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // checkBoxLineNumbers
            // 
            checkBoxLineNumbers.AutoSize = true;
            checkBoxLineNumbers.Checked = true;
            checkBoxLineNumbers.CheckState = CheckState.Checked;
            checkBoxLineNumbers.Location = new Point(20, 225);
            checkBoxLineNumbers.Name = "checkBoxLineNumbers";
            checkBoxLineNumbers.Size = new Size(125, 19);
            checkBoxLineNumbers.TabIndex = 0;
            checkBoxLineNumbers.Text = "Add Line Numbers";
            checkBoxLineNumbers.UseVisualStyleBackColor = true;
            // 
            // chkSwiftAns
            // 
            chkSwiftAns.AutoSize = true;
            chkSwiftAns.Location = new Point(364, 223);
            chkSwiftAns.Name = "chkSwiftAns";
            chkSwiftAns.Size = new Size(118, 19);
            chkSwiftAns.TabIndex = 1;
            chkSwiftAns.Text = "format as Answer";
            chkSwiftAns.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(559, 223);
            button1.Name = "button1";
            button1.Size = new Size(149, 23);
            button1.TabIndex = 2;
            button1.Text = "הכפתור של דורית";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CopyConvert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 498);
            Controls.Add(button1);
            Controls.Add(chkSwiftAns);
            Controls.Add(checkBoxLineNumbers);
            Name = "CopyConvert";
            Text = "Clipboard to Html";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox checkBoxLineNumbers;
        private CheckBox chkSwiftAns;
        private Button button1;
    }
}