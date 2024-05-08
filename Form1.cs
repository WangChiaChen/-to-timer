using System;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace 到計時器__to_timer
{
    public partial class Form1 : Form
    {
        private int secondsLeft = 0;
        private Timer timer;

        public Form1()
        {
            InitializeComponent();

            Label label = new Label();
            label.Text = "Seconds left: 100";
            label.Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold);
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(label);
            label.Font = new System.Drawing.Font("Arial", 36, System.Drawing.FontStyle.Bold);

            Button button = new Button();
            button.Text = "Start Countdown";
            button.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            button.Width = 150; // 設置按鈕寬度和高度相等，使其成為正方形
            button.Height = 150;
            button.Dock = DockStyle.Top;
            button.Click += Button_Click;
            this.Controls.Add(button);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            secondsLeft = 100;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (secondsLeft > 0)
            {
                secondsLeft--;
                this.Controls[0].Text = "Seconds left: " + secondsLeft.ToString();
            }
            else
            {
                timer.Stop();
                MessageBox.Show("時間到！", "倒數計時器");
            }
        }
    }
}
