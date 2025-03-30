using ReaLTaiizor.Controls;
using System.Drawing;

namespace WinFormsApp1
{
    partial class Form1
    {
        private HopeButton selectButton;
        private HopePictureBox imageBox;
        private DungeonRichTextBox resultText;

        private void InitializeComponent()
        {
            this.selectButton = new HopeButton();
            this.imageBox = new HopePictureBox();
            this.resultText = new DungeonRichTextBox();
            this.BackgroundImage = Image.FromFile("../../../bg1.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Text = "AI Распознавание текста";
            this.ClientSize = new Size(900, 600);
            this.BackColor = Color.FromArgb(32, 34, 37);

            this.imageBox.Location = new Point(50, 70);
            this.imageBox.Size = new Size(300, 300);
            this.imageBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.imageBox.Image = null;
            this.Controls.Add(this.imageBox);

            this.resultText.Location = new Point(380, 70);
            this.resultText.Size = new Size(470, 300);
            this.resultText.Font = new Font("Segoe UI", 10);
            this.resultText.ReadOnly = true;
            this.resultText.ForeColor = Color.Black;
            this.resultText.BackColor = Color.White;
            this.resultText.Text = "Здесь будет результат...";
            this.Controls.Add(this.resultText);

            this.selectButton.Text = "📤 Выбрать изображение";
            this.selectButton.Location = new Point(330, 500);
            this.selectButton.Size = new Size(240, 45);
            this.selectButton.PrimaryColor = Color.MediumSlateBlue;
            this.selectButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            this.Controls.Add(this.selectButton);
        }
    }
}