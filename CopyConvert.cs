using Gma.System.MouseKeyHook;
using CsharpToColouredHTML.Core;
//the above are using nugets that have available GITs and documentation 

namespace KeboardHookAndCodeToHtml
{
    public partial class CopyConvert : Form
    {
        private TextBox originalText; // These texts can be ignored. The app should normally be used without the GUI.
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
              "\r\nThe HTML is automatically copied to the clipboard\r\n\r\n" +
              "You may use the conversion shortcut while this app is in the background.\r\nFeel free to minimize this window";
            Controls.Add(originalText);

            InitializeComponent();
            //1. Define key combinations
            var fullScrCombi = Combination.FromString("Control+Shift+F");
            var copyConvertPasteCombi = Combination.FromString("Control+Shift+C");
            var copyConvertPasteCombi2 = Combination.FromString("Control+Shift+X");

            //2. Define actions
            Action actionConvert = CopyConvertToHtml;
            Action actionFullScreen = () => { Console.WriteLine("You Pressed FULL SCREEN"); };

            //3. Assign actions to key combinations
            var assignment = new Dictionary<Combination, Action>
      {
          {fullScrCombi, actionFullScreen},
          {copyConvertPasteCombi, actionConvert},
          {copyConvertPasteCombi2, actionConvert}
      };

            //4. Install listener
            Hook.GlobalEvents().OnCombination(assignment);
        }
        void CopyConvertToHtml()
        {
            originalText.Text = Clipboard.GetText(); //get clipboard content
            HTMLEmitterSettings settings;
            if (checkBoxLineNumbers.Checked)
                settings = new HTMLEmitterSettings().DisableIframe();
            else
                settings = new HTMLEmitterSettings().DisableIframe().DisableLineNumbers();

            //This was not recently tested without the line numbers
            string convertedHtml = new CsharpColourer().ProcessSourceCode(originalText.Text, new HTMLEmitter(settings));
            //update the converted html to include some relevant tags to make it work
            //properly inside campus site.
            int i = convertedHtml.IndexOf("<pre class=\"background\"") + 24;
            string swift = chkSwiftAns.Checked ? "swiftAns" : "swiftly"; //קביעת המחלקה בהתאם לסוף התוצר
            string embeddedHtml = "<div class=\"code " + swift + "\"><pre>" + convertedHtml.Substring(i, convertedHtml.Length - i);
            i = embeddedHtml.IndexOf("</pre>");
            embeddedHtml = embeddedHtml.Substring(0, i) + "</pre></div>";

            convertedText.Text = embeddedHtml;
            Clipboard.SetText(embeddedHtml); //save the conversion result back to the clipboard
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CopyConvertToHtml();
        }
    }
}
