using System;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace 到計時器__to_timer
{
    public partial class Form1 : Form
    {
        private int secondsLeft = 0; // 計時器剩餘秒數
        private Timer timer; // 計時器物件

        public Form1()
        {
            InitializeComponent();

            // 建立並設置倒數計時器標籤
            Label label = new Label();
            label.Text = "Seconds left: 100"; // 設置初始秒數為 100
            label.Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold); // 設置標籤字型
            label.Dock = DockStyle.Fill; // 設置標籤填滿視窗
            label.TextAlign = ContentAlignment.MiddleCenter; // 設置標籤文字置中對齊
            this.Controls.Add(label); // 將標籤加入視窗控制項集合中
            label.Font = new System.Drawing.Font("Arial", 36, System.Drawing.FontStyle.Bold); // 調整字型大小

            // 建立並設置 "開始計時" 按鈕
            Button button = new Button();
            button.Text = "Start Countdown";
            button.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold); // 設置按鈕字型
            button.Width = 150; // 設置按鈕寬度
            button.Height = 150; // 設置按鈕高度
            button.Dock = DockStyle.Top; // 設置按鈕停靠在視窗上方
            button.Click += Button_Click; // 設置按鈕點擊事件
            this.Controls.Add(button); // 將按鈕加入視窗控制項集合中

            timer = new Timer(); // 建立計時器物件
            timer.Interval = 1000; // 設置計時器間隔為 1 秒
            timer.Tick += Timer_Tick; // 設置計時器 Tick 事件處理函式
        }

        // "開始計時" 按鈕點擊事件處理函式
        private void Button_Click(object sender, EventArgs e)
        {
            secondsLeft = 100; // 設置初始秒數為 100
            timer.Start(); // 啟動計時器
        }

        // 計時器 Tick 事件處理函式
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (secondsLeft > 0)
            {
                secondsLeft--; // 減少剩餘秒數
                this.Controls[0].Text = "Seconds left: " + secondsLeft.ToString(); // 更新標籤顯示的秒數
            }
            else
            {
                timer.Stop(); // 停止計時器
                MessageBox.Show("時間到！", "倒數計時器"); // 顯示消息框提示時間到
            }
        }
    }
}
