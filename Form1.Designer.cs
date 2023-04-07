namespace KeboardHookAndCodeToHtml
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      buttonHook = new Button();
      SuspendLayout();
      // 
      // buttonHook
      // 
      buttonHook.Location = new Point(715, 204);
      buttonHook.Name = "buttonHook";
      buttonHook.Size = new Size(75, 23);
      buttonHook.TabIndex = 0;
      buttonHook.Text = "buttonHook";
      buttonHook.UseVisualStyleBackColor = true;
      buttonHook.Click += buttonHook_Click;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(buttonHook);
      Name = "Form1";
      Text = "Form1";
      ResumeLayout(false);
    }

    #endregion

    private Button buttonHook;
  }
}