using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LifeScreenSaver
{
  public partial class FormConfig : Form
  {
    public FormConfig()
    {
      InitializeComponent();
    }

    private void FormConfig_Load(object sender, EventArgs e)
    {
      Utilities.LoadFile();
      microbeColorPanel.BackColor = Utilities.MicrobeColor;
      SetGenerationPickerValue();
      seedLifePicker.Value = Utilities.SeedPerc;
      startingLifeValueLabel.Text = "" + seedLifePicker.Value + " %";
    }

    private void leftColorPanel_MouseClick(object sender, MouseEventArgs e)
    {
      if (colorPicker.ShowDialog() == DialogResult.OK)
      {
        Utilities.MicrobeColor = colorPicker.Color;
        microbeColorPanel.BackColor = Utilities.MicrobeColor;
      }
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      Utilities.Generations = GetGenerationPickerValue();
      Utilities.SeedPerc = seedLifePicker.Value;
      Utilities.MicrobeColor = microbeColorPanel.BackColor;
      Utilities.SaveFile();
      this.Close();
    }

    private int GetGenerationPickerValue()
    {
      string str = generationPicker.Text;
      if (str == "Never")
        return -1;
      int temp = 0;
      if (int.TryParse(str, out temp))
        return temp;
      return Utilities.Generations;
    }

    private void SetGenerationPickerValue()
    {
      if (Utilities.Generations == -1)
        generationPicker.Text = "Never";
      else
        generationPicker.Text = "" + Utilities.Generations;
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void seedLifePicker_Scroll(object sender, EventArgs e)
    {
      startingLifeValueLabel.Text = "" + seedLifePicker.Value + " %";
    }
  }
}