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

                var response = await client.PostAsync("http://localhost:8000/extract-text", content);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var doc = System.Text.Json.JsonDocument.Parse(json);
                return doc.RootElement.TryGetProperty("text", out var text)
                    ? text.GetString()
                    : "? Текст не найден.";
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }
    }
}