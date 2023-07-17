using Gma.System.MouseKeyHook;
using CsharpToColouredHTML.Core;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
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
            originalText.Text = "To use this just copy the code you need (Ctrl+C), then press Ctrl+Win+C to convert." +
                "\r\nOther trigger keys are Ctrl +Shift +X, Ctrl +Shift +C" +
              "\r\nThe original clipboard code will appear here, and the HTML code will appear below" +
              "\r\nThe HTML is automatically copied to the clipboard\r\n\r\n" +
              "You may use the conversion shortcut while this app is in the background.\r\nFeel free to minimize this window" +
              "\r\n\r\nCreating accordions for answers is now easier by checking the Make Accordeon." +
              "\r\nFormat as answer should also be selected if it's an answer";
            Controls.Add(originalText);

            InitializeComponent();
            //1. Define key combinations
            var fullScrCombi = Combination.FromString("Control+Shift+F");
            var copyConvertPasteCombi = Combination.FromString("Control+Shift+C");
            var copyConvertPasteCombi2 = Combination.FromString("Control+Shift+X");
            var copyConvertPasteCombi3 = Combination.FromString("Control+LWin+C");
            //2. Define actions
            Action actionConvert = CopyConvertToHtml;
            Action actionFullScreen = () => { Console.WriteLine("You Pressed FULL SCREEN"); };

            //3. Assign actions to key combinations
            var assignment = new Dictionary<Combination, Action>
      {
          {fullScrCombi, actionFullScreen},
          {copyConvertPasteCombi, actionConvert},
          {copyConvertPasteCombi2, actionConvert},
          {copyConvertPasteCombi3, actionConvert}
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


            //Remove .... dots
            originalText.Text = regexDotsToSpaces(originalText.Text);//fixed dots to spaces.

            //Convert to Java
            if (JavaIt.Checked)
                originalText.Text = regexToJava(originalText.Text);
            //Convert to Java brackets
            if (JavaBrackets.Checked)
                originalText.Text = regextJavaBrackets(originalText.Text);

            string convertedHtml;
            //format one line function signatures as functions
            if (chkOneLineFunction.Checked)
            {
                convertedHtml = new CsharpColourer().ProcessSourceCode(originalText.Text + "{r;}", new HTMLEmitter(settings));
                convertedHtml = Regex.Replace(convertedHtml, "{r;}", "");
            }
            else
                convertedHtml = new CsharpColourer().ProcessSourceCode(originalText.Text, new HTMLEmitter(settings));
            //update the converted html to include some relevant tags to make it work
            //properly inside campus site.
            int i = convertedHtml.IndexOf("<pre class=\"background\"") + 24;
            string swift = chkSwiftAns.Checked ? "swiftAns" : "swiftly"; //קביעת המחלקה בהתאם לסוף התוצר
            string embeddedHtml = "<div class=\"code " + swift + "\"><pre>" + convertedHtml.Substring(i, convertedHtml.Length - i);
            i = embeddedHtml.IndexOf("</pre>");
            embeddedHtml = embeddedHtml.Substring(0, i) + "</pre></div>";
            if (chkAsQuestion.Checked) //אחרי <label> הוספת טקסט לפני ותגית  
                embeddedHtml = $"<div class=\"desc_header\">הביטו בקטע הקוד הבא, עקבו וענו מבלי להריץ במחשב:</div>" +
                    $"\r\n{embeddedHtml}\r\n\r\n<multiplechoiceresponse>\r\n<label>אאאאאאאאאאאאאאאאא</label>\r\n<description/>\r\n";


            if (chkMakeAccordeon.Checked)
            {   //support making code into accoreon directly.
                string ans = chkAsQuestion.Checked ? "שאלה?????" : "תשובה:";
                int nonce = DateTime.Now.Millisecond;
                embeddedHtml = $"<button class=\"box_title\" aria-expanded=\"true\" " +
                    $"onclick=\"toggle_visibility('topic{nonce}')\">{ans}</button>\r\n<div id=\"topic{nonce}\" class=\"box_content\">\r\n{embeddedHtml}\r\n</div>";
            }

            convertedText.Text = embeddedHtml;
            Clipboard.SetText(embeddedHtml); //save the conversion result back to the clipboard
        }

        public string regexDotsToSpaces(string input)
        {
            input = input.Replace("…………", "          "); //12
            input = input.Replace("……..", "       "); //8 = 6+2
            input = input.Replace("….", "    ");//4 = 3+1

            string pattern = @"(\.{4})";
            string replacement = "    ";
            string result = Regex.Replace(input, pattern, replacement);
            
            return result;
        }

        public string regextJavaBrackets(string input)
        {
            input = Regex.Replace(input, @"(\s*//.*)\r\n\s*{", " { $1"); // replace for line with comments.
            return Regex.Replace(input, @"(\s*//.*|\s*)\r\n\s*{", "$1 {"); // replace all the rest
        }

        public string regexToJava(string input)
        {
            //input = Regex.Replace(input, "\r\n                    {", " {");
            //input = Regex.Replace(input, "\r\n                {", " {");
            //input = Regex.Replace(input, "\r\n            {", " {");
            //input = Regex.Replace(input, "\r\n        {", " {");
            //input = Regex.Replace(input, "\r\n    {", " {");
            //input = Regex.Replace(input, "\r\n{", " {");

            input = input.Replace("Console.WriteLine", "System.out.println");
            input = input.Replace("Console.Write", "System.out.print");
            input = input.Replace("int.Parse(Console.ReadLine())", "input.nextInt()");
            input = input.Replace("double.Parse(Console.ReadLine())", "input.nextDouble()");
            input = input.Replace("Console.ReadLine()", "input.next()");
            input = input.Replace("bool", "boolean");
            input = input.Replace("string", "String");
            input = Regex.Replace(input, @"(void|String|boolean|int|double|char|static)\s+([A-Z])", m => $"{m.Groups[1]} {m.Groups[2].Value.ToLower()}");
            //replace . function calls.
            input = Regex.Replace(input, @"\.+([A-Z])", m => $"{m.Value.ToLower()}");
            //replace function calls to lower case functions.
            input = Regex.Replace(input, @"(\b[A-Z])(\w*)\(", m => $"{m.Groups[1].Value.ToLower()}{m.Groups[2].Value}(");
            input = input.Replace("int.minValue", "Integer.MIN_VALUE");
            input = input.Replace("int.maxValue", "Integer.MAX_VALUE");
            input = input.Replace("next", "nextInt");
            input = input.Replace("nextInt(min, max)", "nextInt(max + 1 - min) + min");
            input = input.Replace("nextInt(min,max)", "nextInt(max + 1 - min) + min");
            input = convertBaseToSuper(input);
            input = convertInheritanceToJava(input);
            return input;
        }
        public string convertBaseToSuper(string input)
        {
            return Regex.Replace(input, @"\s*:\s*base\((.*?)\)\s*{", m => ") {\r\n        super(" + m.Groups[1].Value + ");");
        }
        public string convertInheritanceToJava(string input)
        {
            return Regex.Replace(input, @"(\bclass\s+[A-Z]\w*)\s*:\s*([A-Z]\w*)", "$1 extends $2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CopyConvertToHtml();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
