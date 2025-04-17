using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class SubscriptionForm : Form
    {
        public SubscriptionForm()
        {
            InitializeComponent();
        }

        private void SubscriptionForm_Load(object sender, EventArgs e)
        {
            // Настройка внешнего вида формы
            this.Text = "Выберите подходящий вам план";
            this.Width = 800;
            this.Height = 450;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label title = new Label()
            {
                Text = "Выберите подходящий вам план",
                Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Top = 20,
                Left = 250
            };
            this.Controls.Add(title);

            FlowLayoutPanel panel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Bottom,
                Height = 350,
                FlowDirection = FlowDirection.LeftToRight
            };
            this.Controls.Add(panel);

            panel.Controls.Add(CreatePlan("Базовый\n0₴", "3 сканирования бесплатно\nИИ (3 сообщения/день)\nХорошая точность\nБыстрая обработка", null));
            panel.Controls.Add(CreatePlan("Плюс\n200₴/мес.", "Без ограничений\nИИ (неограниченно)\nМаксимальная точность\nОчень быстрая обработка", "https://example.com/plus"));
            panel.Controls.Add(CreatePlan("Премиум\n400₴/мес.", "Все возможности\nИИ (неограниченно)\nМаксимальная точность\nМгновенная обработка", "https://example.com/premium"));
        }

        private Panel CreatePlan(string title, string description, string? link)
        {
            Panel planPanel = new Panel()
            {
                Width = 250,
                Height = 300,
                Margin = new Padding(20),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label planTitle = new Label()
            {
                Text = title,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };

            Label planDesc = new Label()
            {
                Text = description,
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 150,
                TextAlign = System.Drawing.ContentAlignment.TopCenter
            };

            Button subscribeBtn = new Button()
            {
                Text = link == null ? "Попробовать бесплатно" : "Оформить",
                Dock = DockStyle.Bottom,
                Height = 40
            };

            if (link != null)
            {
                subscribeBtn.Click += (s, e) => Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
            }
            else
            {
                subscribeBtn.Click += (s, e) => this.Close(); // просто закрыть окно
            }

            planPanel.Controls.Add(planTitle);
            planPanel.Controls.Add(planDesc);
            planPanel.Controls.Add(subscribeBtn);

            return planPanel;
        }
    }
}
