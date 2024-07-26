using System;
using System.IO;
using System.Windows.Forms;

namespace BatchFileCreator
{
    public partial class Form1 : Form
    {
        private const int MaxApplications = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            string batFilePath = "launch_apps.bat";
            using (StreamWriter writer = new StreamWriter(batFilePath))
            {
                for (int i = 0; i < MaxApplications; i++)
                {
                    TextBox textBox = this.Controls["textBoxPath" + i] as TextBox;
                    if (!string.IsNullOrEmpty(textBox?.Text))
                    {
                        writer.WriteLine($"start \"\" \"{textBox.Text}\"");
                    }
                }
            }

            MessageBox.Show($"Batch file created: {batFilePath}");
        }
    }
}
