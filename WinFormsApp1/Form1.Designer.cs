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
            selectButton = new HopeButton();
            imageBox = new HopePictureBox();
            resultText = new DungeonRichTextBox();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabelLogin = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)imageBox).BeginInit();
            SuspendLayout();
            // 
            // selectButton
            // 
            selectButton.BorderColor = Color.FromArgb(220, 223, 230);
            selectButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            selectButton.DangerColor = Color.FromArgb(245, 108, 108);
            selectButton.DefaultColor = Color.FromArgb(255, 255, 255);
            selectButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            selectButton.HoverTextColor = Color.FromArgb(48, 49, 51);
            selectButton.InfoColor = Color.FromArgb(144, 147, 153);
            selectButton.Location = new Point(330, 500);
            selectButton.Name = "selectButton";
            selectButton.PrimaryColor = Color.MediumSlateBlue;
            selectButton.Size = new Size(240, 45);
            selectButton.SuccessColor = Color.FromArgb(103, 194, 58);
            selectButton.TabIndex = 2;
            selectButton.Text = "Выбрать изображение";
            selectButton.TextColor = Color.White;
            selectButton.WarningColor = Color.FromArgb(230, 162, 60);
            selectButton.Click += selectButton_Click;
            // 
            // imageBox
            // 
            imageBox.BackColor = Color.FromArgb(192, 196, 204);
            imageBox.Location = new Point(50, 70);
            imageBox.Name = "imageBox";
            imageBox.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            imageBox.Size = new Size(300, 300);
            imageBox.SizeMode = PictureBoxSizeMode.Zoom;
            imageBox.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            imageBox.TabIndex = 0;
            imageBox.TabStop = false;
            imageBox.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // resultText
            // 
            resultText.AutoWordSelection = false;
            resultText.BackColor = Color.White;
            resultText.BorderColor = Color.FromArgb(180, 180, 180);
            resultText.EdgeColor = Color.White;
            resultText.Font = new Font("Segoe UI", 10F);
            resultText.ForeColor = Color.Black;
            resultText.Location = new Point(380, 70);
            resultText.Name = "resultText";
            resultText.ReadOnly = true;
            resultText.Size = new Size(470, 300);
            resultText.TabIndex = 1;
            resultText.Text = "Здесь будет результат...";
            resultText.TextBackColor = Color.White;
            resultText.WordWrap = true;
            // 
            // linkLabel1
            // 
            linkLabel1.Location = new Point(0, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(100, 23);
            linkLabel1.TabIndex = 5;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.BackColor = Color.Transparent;
            linkLabel2.LinkColor = Color.White;
            linkLabel2.Location = new Point(783, 576);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(92, 15);
            linkLabel2.TabIndex = 4;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Оставить отзыв";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabelLogin
            // 
            linkLabelLogin.BackColor = Color.Transparent;
            linkLabelLogin.ForeColor = Color.Transparent;
            linkLabelLogin.LinkColor = Color.White;
            linkLabelLogin.Location = new Point(675, 22);
            linkLabelLogin.Name = "linkLabelLogin";
            linkLabelLogin.Size = new Size(200, 23);
            linkLabelLogin.TabIndex = 0;
            linkLabelLogin.TabStop = true;
            linkLabelLogin.Text = "Войти или зарегистрироваться";
            linkLabelLogin.TextAlign = ContentAlignment.MiddleCenter;
            linkLabelLogin.LinkClicked += linkLabelLogin_LinkClicked;
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(32, 34, 37);
            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Image.FromFile("../../../bg1.jpg");
            ClientSize = new Size(900, 600);
            Controls.Add(linkLabelLogin);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(imageBox);
            Controls.Add(resultText);
            Controls.Add(selectButton);
            Name = "Form1";
            Text = "ScanText";
            ((System.ComponentModel.ISupportInitialize)imageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
    }
}