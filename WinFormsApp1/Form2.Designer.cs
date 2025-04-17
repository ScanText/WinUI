namespace WinFormsApp
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelTitle;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Button btnLogin;
        private Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle = new Label();
            this.labelEmail = new Label();
            this.textBoxEmail = new TextBox();
            this.textBoxLogin = new TextBox();
            this.textBoxPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnRegister = new Button();
            this.SuspendLayout();

            // labelTitle
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(100, 20);
            this.labelTitle.Size = new System.Drawing.Size(200, 30);
            this.labelTitle.Text = "Вход в аккаунт";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // labelEmail
            this.labelEmail.Location = new System.Drawing.Point(100, 60);
            this.labelEmail.Size = new System.Drawing.Size(200, 15);
            this.labelEmail.Text = "Email:";
            this.labelEmail.Visible = false;

            // textBoxEmail
            this.textBoxEmail.Location = new System.Drawing.Point(100, 75);
            this.textBoxEmail.Size = new System.Drawing.Size(200, 23);
            this.textBoxEmail.PlaceholderText = "Email";
            this.textBoxEmail.Visible = false;

            // textBoxLogin
            this.textBoxLogin.Location = new System.Drawing.Point(100, 110);
            this.textBoxLogin.Size = new System.Drawing.Size(200, 23);
            this.textBoxLogin.PlaceholderText = "Логин";

            // textBoxPassword
            this.textBoxPassword.Location = new System.Drawing.Point(100, 150);
            this.textBoxPassword.Size = new System.Drawing.Size(200, 23);
            this.textBoxPassword.PlaceholderText = "Пароль";
            this.textBoxPassword.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(100, 190);
            this.btnLogin.Size = new System.Drawing.Size(200, 30);
            this.btnLogin.Text = "Войти";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnRegister
            this.btnRegister.Location = new System.Drawing.Point(100, 230);
            this.btnRegister.Size = new System.Drawing.Size(200, 30);
            this.btnRegister.Text = "Регистрация";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // Form2
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
