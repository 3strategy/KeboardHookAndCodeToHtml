namespace KeboardHookAndCodeToHtml
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private GlobalKeyboardHook _globalKeyboardHook;

    private void buttonHook_Click(object sender, EventArgs e)
    {
      buttonHook.Enabled = false;
      // Hooks only into specified Keys (here "A" and "B").
      _globalKeyboardHook = new GlobalKeyboardHook(new Keys[] { Keys.C, Keys.B });

      // Hooks into all keys.
      //_globalKeyboardHook = new GlobalKeyboardHook();
      _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
    }

    private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
    {
      // EDT: No need to filter for VkSnapshot anymore. This now gets handled
      // through the constructor of GlobalKeyboardHook(...).
      if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
      {
        // Now you can access both, the key and virtual code
        Keys loggedKey = e.KeyboardData.Key;
        if (loggedKey == Keys.C && e.KeyboardData.Flags==16) 
        {
        }
        int loggedVkCode = e.KeyboardData.VirtualCode;
      }
    }
  }
}