using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using WinFormsApp1;
using WinFormsApp;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int freeTriesLeft = 5; // Количество бесплатных попыток
        private string selectedImagePath = "";
        private LinkLabel linkLabelLogin;

        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 loginForm = new Form2();
            loginForm.FormClosed += (s, args) => this.Show();
            loginForm.Show();
            this.Hide();
        }

        private async void selectButton_Click(object sender, EventArgs e)
        {
            if (freeTriesLeft <= 0)
            {
                ShowSubscriptionPrompt();
                return;
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = dialog.FileName;
                    imageBox.Image = Image.FromFile(selectedImagePath);

                    resultText.Text = "? Распознавание...";
                    string result = await SendImageToServer(selectedImagePath);
                    resultText.Text = result;

                    freeTriesLeft--;
                    if (freeTriesLeft == 0)
                    {
                        MessageBox.Show("Вы использовали все бесплатные попытки.", "Лимит исчерпан", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowSubscriptionPrompt();
                    }
                }
            }
        }

        private void ShowSubscriptionPrompt()
        {
            SubscriptionForm subscriptionForm = new SubscriptionForm();
            subscriptionForm.ShowDialog();
        }

        private async Task<string> SendImageToServer(string filePath)
        {
            try
            {
                using var client = new HttpClient();
                using var content = new MultipartFormDataContent();

                var fileStream = File.OpenRead(filePath);
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                content.Add(fileContent, "file", Path.GetFileName(filePath));

                var response = await client.PostAsync("https://fastapitext.fly.dev/extract-text/", content);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var doc = System.Text.Json.JsonDocument.Parse(json);

                if (doc.RootElement.TryGetProperty("text", out var textElement))
                {
                    var extractedText = textElement.GetString();

                    if (string.IsNullOrWhiteSpace(extractedText))
                    {
                        return "Текст не распознан, попробуйте другую картинку...";
                    }

                    return extractedText;
                }
                else
                {
                    return "❓ Текст не найден в ответе сервера.";
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "http://localhost:3000/about",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии сайта: " + ex.Message);
            }
        }

    }
}
