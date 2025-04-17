using System;
using System.Text.Json;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace WinFormsApp
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public DateTime registered_at { get; set; }
        public string role { get; set; }
    }
    public partial class Form2 : Form
    {
        private bool isLoginMode = true;

        public Form2()
        {
            InitializeComponent();
            UpdateMode();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://localhost:8000/user/login";

                    var loginData = new
                    {
                        login = login,
                        password = password
                    };

                    var json = JsonSerializer.Serialize(loginData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var user = JsonSerializer.Deserialize<User>(responseBody);

                        MessageBox.Show($"Вход выполнен! Добро пожаловать, {user.login}");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка входа: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к серверу: " + ex.Message);
            }
        }



        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (isLoginMode)
            {
                // Переключение на режим регистрации
                isLoginMode = false;
                UpdateMode();
                return;
            }

            string login = textBoxLogin.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            var newUser = new
            {
                login = login,
                email = email,
                password = password
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://localhost:8000/user/register"; 

                    string jsonContent = JsonSerializer.Serialize(newUser);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Регистрация прошла успешно!");
                        isLoginMode = true;
                        UpdateMode();
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка регистрации: {responseContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения: " + ex.Message);
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Закрываем форму без регистрации
            this.Close();
        }


        private void UpdateMode()
        {
            labelTitle.Text = isLoginMode ? "Вход в аккаунт" : "Регистрация";
            btnLogin.Visible = isLoginMode;
            btnRegister.Text = isLoginMode ? "Регистрация" : "Назад ко входу";

            // Показывать Email только в режиме регистрации
            textBoxEmail.Visible = !isLoginMode;
            labelEmail.Visible = !isLoginMode;
        }
    }
}
