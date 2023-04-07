using Gma.System.MouseKeyHook;
using CsharpToColouredHTML.Core;

namespace KeboardHookAndCodeToHtml
{
  public partial class CopyConvert : Form
  {
    private TextBox originalText;
    private TextBox convertedText;
    public CopyConvert()
    {
      // create converted text box
      convertedText = new TextBox();
      convertedText.Dock = DockStyle.Bottom;
      convertedText.Multiline = true;
      convertedText.Height = 200;
      convertedText.ScrollBars = ScrollBars.Vertical;
      //convertedText.ReadOnly = true;
      Controls.Add(convertedText);

      // create original text box
      originalText = new TextBox();
      originalText.Dock = DockStyle.Top;
      originalText.Multiline = true;
      originalText.Height = 200;
      originalText.ScrollBars = ScrollBars.Vertical;
      originalText.Text = "To use this just copy the code you need (Ctrl+C), then press Ctrl+Shift+C to convert." +
        "\r\nThe original clipboard code will appear here, and the HTML code will appear below" +
        "\r\nThe HTML is automatically copied to the clipboard\r\n" +
        "You may use these shortcuts with this app in the background";
      Controls.Add(originalText);

      InitializeComponent();
      //1. Define key combinations
      var fullScrCombi = Combination.FromString("Control+Shift+F");
      var copyConvertPasteCombi = Combination.FromString("Control+Shift+C");

      //2. Define actions
      Action actionConvert = CopyConvertToHtml;
      Action actionFullScreen = () => { Console.WriteLine("You Pressed FULL SCREEN"); };

      //3. Assign actions to key combinations
      var assignment = new Dictionary<Combination, Action>
      {
          {fullScrCombi, actionFullScreen},
          {copyConvertPasteCombi, actionConvert}
      };

      //4. Install listener
      Hook.GlobalEvents().OnCombination(assignment);
    }
    void CopyConvertToHtml()
    {
      originalText.Text = Clipboard.GetText();

      var settings = new HTMLEmitterSettings().DisableIframe();//.DisableLineNumbers();
      string convertedHtml = new CsharpColourer().ProcessSourceCode(originalText.Text, new HTMLEmitter(settings));
      int i = convertedHtml.IndexOf("<pre class=\"background\"") + 24;
      string embeddedHtml = "<div class=\"code, swiftly\"><pre><code>" + convertedHtml.Substring(i, convertedHtml.Length - i);
      i = embeddedHtml.IndexOf("</pre>");
      embeddedHtml = embeddedHtml.Substring(0, i) + "</code></pre></div>";

      convertedText.Text = embeddedHtml;
      Clipboard.SetText(embeddedHtml);
    }

    private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {

    }
  }
}
