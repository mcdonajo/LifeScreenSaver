using System;
using System.Drawing;
using System.IO;

namespace LifeScreenSaver
{
  class Utilities
  {
    private static readonly string generationString = "Generations";
    private static readonly string seedString = "SeedPercent";
    private static readonly string microbeColorString = "MicrobeColor";

    public static int Generations = 3000;
    public static int SeedPerc = 25;
    public static Color MicrobeColor = Color.WhiteSmoke;

    private static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LifeScreenSaverSettings.cfg";

    public static void SaveFile()
    {
      TextWriter f = new StreamWriter(filePath, false);
      f.WriteLine(generationString + "=" + Generations);
      f.WriteLine(seedString + "=" + SeedPerc);
      f.WriteLine(microbeColorString + "=" + MicrobeColor.ToArgb());
      f.Close();
    }

    public static void LoadFile()
    {
      if (!File.Exists(filePath))
        return;
      TextReader f = new StreamReader(filePath, true);
      string line = f.ReadLine();
      while(line != null)
      {
        string[] lineParts = line.Split('=');
        if (lineParts.Length == 2)
        {
          switch (lineParts[0])
          {
            case "Generations":
              int.TryParse(lineParts[1], out Generations);
              break;
            case "SeedPercent":
              int.TryParse(lineParts[1], out SeedPerc);
              break;
            case "MicrobeColor":
              int lColor = 0;
              int.TryParse(lineParts[1], out lColor);
              MicrobeColor = Color.FromArgb(lColor);
              break;
            default:
              break;
          }
        }
        line = f.ReadLine();
      }
      f.Close();
    }
  }
}
