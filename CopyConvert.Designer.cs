﻿namespace KeboardHookAndCodeToHtml
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
      backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      SuspendLayout();
      // 
      // backgroundWorker1
      // 
      backgroundWorker1.DoWork += backgroundWorker1_DoWork;
      // 
      // CopyConvert
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 498);
      Name = "CopyConvert";
      Text = "Clipboard to Html";
      ResumeLayout(false);
    }

    #endregion

    private System.ComponentModel.BackgroundWorker backgroundWorker1;
  }
}