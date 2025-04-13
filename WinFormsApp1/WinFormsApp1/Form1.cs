using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string selectedImagePath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private async void selectButton_Click(object sender, EventArgs e)
        {
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
                }
            }
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

    }
}