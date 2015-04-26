using System;
using System.Windows.Forms;

namespace LifeScreenSaver
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      if (args.Length > 0)
      {
        string arg1 = args[0].ToLower().Trim();
        string arg2 = "";
        if (arg1.Length > 2)
        {
          arg2 = arg1.Substring(3).Trim();
          arg1 = arg1.Substring(0, 2);
        }
        switch (arg1)
        {
          case "/c":  //Configuration
            Application.Run(new FormConfig());
            break;
          case "/p":  //Preview
            if (arg2 == "")
            {
              if (args.Length > 1)
                arg2 = args[1];
            }
            if (arg2 != "")
            {
              IntPtr wHandle = new IntPtr(long.Parse(arg2));
              Application.Run(new FormApp(wHandle));
            }
            break;
          case "/s":  //Full screen
            Application.Run(new FormApp());
            break;
          default:  // Incorrect options
            break;
        }
      }
      else
      {
        Application.Run(new FormApp());
      }
    }
  }
}