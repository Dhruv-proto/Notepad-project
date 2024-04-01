using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    public class MainForm : Form
    {
        private TextBox textBox;
        private Button saveButton;

        private string currentFilePath;

        public MainForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Notepad";
            this.Size = new Size(600, 400);

            this.textBox = new TextBox();
            this.textBox.Dock = DockStyle.Fill;
            this.textBox.Multiline = true;
            this.textBox.ScrollBars = ScrollBars.Both;

            this.Controls.Add(this.textBox);

            this.saveButton = new Button();
            this.saveButton.Text = "Save";
            this.saveButton.Dock = DockStyle.Bottom;
            this.saveButton.Click += new EventHandler(SaveButton_Click);

            this.Controls.Add(this.saveButton);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.currentFilePath = saveFileDialog.FileName;
                try
                {
                    File.WriteAllText(this.currentFilePath, this.textBox.Text);
                    MessageBox.Show("Saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving note: " + ex.Message);
                }
            }
        }
    }

    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}