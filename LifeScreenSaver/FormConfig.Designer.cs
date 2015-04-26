namespace LifeScreenSaver
{
  partial class FormConfig
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.colorGroupBox = new System.Windows.Forms.GroupBox();
      this.microbeColorPanel = new System.Windows.Forms.Panel();
      this.optionsGroupBox = new System.Windows.Forms.GroupBox();
      this.startingLifeValueLabel = new System.Windows.Forms.Label();
      this.generationsLabel2 = new System.Windows.Forms.Label();
      this.generationPicker = new System.Windows.Forms.ComboBox();
      this.generationsLabel1 = new System.Windows.Forms.Label();
      this.startLifeLabel = new System.Windows.Forms.Label();
      this.seedLifePicker = new System.Windows.Forms.TrackBar();
      this.colorPicker = new System.Windows.Forms.ColorDialog();
      this.panel1.SuspendLayout();
      this.colorGroupBox.SuspendLayout();
      this.optionsGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.seedLifePicker)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.cancelButton);
      this.panel1.Controls.Add(this.okButton);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 263);
      this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(379, 59);
      this.panel1.TabIndex = 0;
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(155, 16);
      this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(100, 28);
      this.cancelButton.TabIndex = 1;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(263, 16);
      this.okButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(100, 28);
      this.okButton.TabIndex = 0;
      this.okButton.Text = "Ok";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // colorGroupBox
      // 
      this.colorGroupBox.Controls.Add(this.microbeColorPanel);
      this.colorGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.colorGroupBox.Location = new System.Drawing.Point(0, 140);
      this.colorGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.colorGroupBox.Name = "colorGroupBox";
      this.colorGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.colorGroupBox.Size = new System.Drawing.Size(379, 123);
      this.colorGroupBox.TabIndex = 1;
      this.colorGroupBox.TabStop = false;
      this.colorGroupBox.Text = "Microbe Color";
      // 
      // microbeColorPanel
      // 
      this.microbeColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.microbeColorPanel.Cursor = System.Windows.Forms.Cursors.Hand;
      this.microbeColorPanel.Location = new System.Drawing.Point(8, 23);
      this.microbeColorPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.microbeColorPanel.Name = "microbeColorPanel";
      this.microbeColorPanel.Size = new System.Drawing.Size(363, 92);
      this.microbeColorPanel.TabIndex = 0;
      this.microbeColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.leftColorPanel_MouseClick);
      // 
      // optionsGroupBox
      // 
      this.optionsGroupBox.Controls.Add(this.startingLifeValueLabel);
      this.optionsGroupBox.Controls.Add(this.generationsLabel2);
      this.optionsGroupBox.Controls.Add(this.generationPicker);
      this.optionsGroupBox.Controls.Add(this.generationsLabel1);
      this.optionsGroupBox.Controls.Add(this.startLifeLabel);
      this.optionsGroupBox.Controls.Add(this.seedLifePicker);
      this.optionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.optionsGroupBox.Location = new System.Drawing.Point(0, 0);
      this.optionsGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.optionsGroupBox.Name = "optionsGroupBox";
      this.optionsGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.optionsGroupBox.Size = new System.Drawing.Size(379, 140);
      this.optionsGroupBox.TabIndex = 2;
      this.optionsGroupBox.TabStop = false;
      this.optionsGroupBox.Text = "Options";
      // 
      // startingLifeValueLabel
      // 
      this.startingLifeValueLabel.AutoSize = true;
      this.startingLifeValueLabel.Location = new System.Drawing.Point(108, 58);
      this.startingLifeValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.startingLifeValueLabel.Name = "startingLifeValueLabel";
      this.startingLifeValueLabel.Size = new System.Drawing.Size(0, 17);
      this.startingLifeValueLabel.TabIndex = 5;
      // 
      // generationsLabel2
      // 
      this.generationsLabel2.AutoSize = true;
      this.generationsLabel2.Location = new System.Drawing.Point(277, 23);
      this.generationsLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.generationsLabel2.Name = "generationsLabel2";
      this.generationsLabel2.Size = new System.Drawing.Size(86, 17);
      this.generationsLabel2.TabIndex = 4;
      this.generationsLabel2.Text = "Generations";
      // 
      // generationPicker
      // 
      this.generationPicker.FormattingEnabled = true;
      this.generationPicker.Items.AddRange(new object[] {
            "1000",
            "2000",
            "3000",
            "4000",
            "5000",
            "Never"});
      this.generationPicker.Location = new System.Drawing.Point(83, 20);
      this.generationPicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.generationPicker.Name = "generationPicker";
      this.generationPicker.Size = new System.Drawing.Size(185, 24);
      this.generationPicker.TabIndex = 3;
      // 
      // generationsLabel1
      // 
      this.generationsLabel1.AutoSize = true;
      this.generationsLabel1.Location = new System.Drawing.Point(19, 23);
      this.generationsLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.generationsLabel1.Name = "generationsLabel1";
      this.generationsLabel1.Size = new System.Drawing.Size(54, 17);
      this.generationsLabel1.TabIndex = 2;
      this.generationsLabel1.Text = "Stop At";
      // 
      // startLifeLabel
      // 
      this.startLifeLabel.AutoSize = true;
      this.startLifeLabel.Location = new System.Drawing.Point(19, 48);
      this.startLifeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.startLifeLabel.Name = "startLifeLabel";
      this.startLifeLabel.Size = new System.Drawing.Size(84, 17);
      this.startLifeLabel.TabIndex = 1;
      this.startLifeLabel.Text = "Starting Life";
      // 
      // seedLifePicker
      // 
      this.seedLifePicker.Location = new System.Drawing.Point(12, 69);
      this.seedLifePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.seedLifePicker.Maximum = 100;
      this.seedLifePicker.Name = "seedLifePicker";
      this.seedLifePicker.Size = new System.Drawing.Size(351, 56);
      this.seedLifePicker.TabIndex = 0;
      this.seedLifePicker.TickFrequency = 0;
      this.seedLifePicker.Scroll += new System.EventHandler(this.seedLifePicker_Scroll);
      // 
      // FormConfig
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(379, 322);
      this.Controls.Add(this.optionsGroupBox);
      this.Controls.Add(this.colorGroupBox);
      this.Controls.Add(this.panel1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "FormConfig";
      this.ShowIcon = false;
      this.Text = "Life Configuration";
      this.Load += new System.EventHandler(this.FormConfig_Load);
      this.panel1.ResumeLayout(false);
      this.colorGroupBox.ResumeLayout(false);
      this.optionsGroupBox.ResumeLayout(false);
      this.optionsGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.seedLifePicker)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.GroupBox colorGroupBox;
    private System.Windows.Forms.GroupBox optionsGroupBox;
    private System.Windows.Forms.Panel microbeColorPanel;
    private System.Windows.Forms.Label generationsLabel1;
    private System.Windows.Forms.Label startLifeLabel;
    private System.Windows.Forms.TrackBar seedLifePicker;
    private System.Windows.Forms.Label generationsLabel2;
    private System.Windows.Forms.ComboBox generationPicker;
    private System.Windows.Forms.ColorDialog colorPicker;
    private System.Windows.Forms.Label startingLifeValueLabel;
  }
}