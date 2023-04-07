using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeboardHookAndCodeToHtml
{
  public partial class CopyConvert : Form
  {
    private TextBox originalText;
    private TextBox convertedText;
    public CopyConvert()
    {
      //InitializeComponent();
      Text = "Clipboard Converter";

      // create original text box
      originalText = new TextBox();
      originalText.Dock = DockStyle.Top;
      originalText.Multiline = true;
      originalText.Height = 200;
      originalText.ScrollBars = ScrollBars.Vertical;
      //originalText.TextChanged += OnOriginalTextChanged;
      Controls.Add(originalText);

      // create converted text box
      convertedText = new TextBox();
      convertedText.Dock = DockStyle.Fill;
      convertedText.Multiline = true;
      convertedText.Height = 200;
      convertedText.ScrollBars = ScrollBars.Vertical;
      //convertedText.ReadOnly = true;
      Controls.Add(convertedText);


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
      Console.WriteLine("You pressed Convert");
    }
  }
}
