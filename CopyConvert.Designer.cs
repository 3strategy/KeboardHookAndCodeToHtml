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
            components = new System.ComponentModel.Container();
            checkBoxLineNumbers = new CheckBox();
            chkSwiftAns = new CheckBox();
            button1 = new Button();
            chkAsQuestion = new CheckBox();
            chkMakeAccordeon = new CheckBox();
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            chkOneLineFunction = new CheckBox();
            JavaIt = new CheckBox();
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
            // chkAsQuestion
            // 
            chkAsQuestion.AutoSize = true;
            chkAsQuestion.Location = new Point(188, 247);
            chkAsQuestion.Name = "chkAsQuestion";
            chkAsQuestion.Size = new Size(122, 19);
            chkAsQuestion.TabIndex = 3;
            chkAsQuestion.Text = "treat as a question";
            toolTip1.SetToolTip(chkAsQuestion, "checking this will add header description with usual text and a label with an easy to replace אאאאאא question");
            chkAsQuestion.UseVisualStyleBackColor = true;
            // 
            // chkMakeAccordeon
            // 
            chkMakeAccordeon.AutoSize = true;
            chkMakeAccordeon.Location = new Point(363, 249);
            chkMakeAccordeon.Name = "chkMakeAccordeon";
            chkMakeAccordeon.Size = new Size(160, 19);
            chkMakeAccordeon.TabIndex = 4;
            chkMakeAccordeon.Text = "Make Accordeon אקורדיון";
            toolTip2.SetToolTip(chkMakeAccordeon, "This will turn your code into an accordeon and assign it a time based random");
            chkMakeAccordeon.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            toolTip1.Popup += toolTip1_Popup;
            // 
            // chkOneLineFunction
            // 
            chkOneLineFunction.AutoSize = true;
            chkOneLineFunction.Location = new Point(18, 247);
            chkOneLineFunction.Name = "chkOneLineFunction";
            chkOneLineFunction.Size = new Size(129, 19);
            chkOneLineFunction.TabIndex = 5;
            chkOneLineFunction.Text = "{}one Line Function";
            chkOneLineFunction.UseVisualStyleBackColor = true;
            // 
            // JavaIt
            // 
            JavaIt.AutoSize = true;
            JavaIt.Checked = true;
            JavaIt.CheckState = CheckState.Checked;
            JavaIt.Location = new Point(562, 251);
            JavaIt.Name = "JavaIt";
            JavaIt.Size = new Size(58, 19);
            JavaIt.TabIndex = 6;
            JavaIt.Text = "Java it";
            JavaIt.UseVisualStyleBackColor = true;
            // 
            // CopyConvert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 498);
            Controls.Add(JavaIt);
            Controls.Add(chkOneLineFunction);
            Controls.Add(chkMakeAccordeon);
            Controls.Add(chkAsQuestion);
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
        private CheckBox chkAsQuestion;
        private CheckBox chkMakeAccordeon;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private CheckBox chkOneLineFunction;
        private CheckBox JavaIt;
    }
}