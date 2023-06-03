namespace hw_03._06__Timer_
{
    enum MyColor { Black, Red, Yellow, Green, Blue, DarkBlue, Pink, White };

    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer t2 = new System.Windows.Forms.Timer();
        int yearNow = DateTime.Now.Year;

        static int value = 0;
        static int maxValue = 255;
        static MyColor color = MyColor.Red;

        public Form1()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            labelText.Text = $"Time before {yearNow + 1}:";
            StartPosition = FormStartPosition.CenterScreen;

            StartTimer();
        }

        private void StartTimer()
        {
            t1.Interval = 1000;
            t1.Tick += T_Tick;
            T_Tick(t1, EventArgs.Empty);
            t1.Start();

            t2.Interval = 1;
            t2.Tick += T_Tick;
            t2.Start();
        }

        private void T_Tick(object? sender, EventArgs e)
        {
            //Time 'till NY
            TimeSpan remainderTime = new DateTime(yearNow + 1, 1, 1) - DateTime.Now;

            string h = remainderTime.Hours.ToString();
            if (remainderTime.Hours < 10) h = $"0{h}";

            string m = remainderTime.Minutes.ToString();
            if (remainderTime.Minutes < 10) m = $"0{m}";

            string s = remainderTime.Seconds.ToString();
            if (remainderTime.Seconds < 10) s = $"0{s}";

            labelTime.Text = $"{remainderTime.Days} days, {h}:{m}:{s}";

            //Time from start
            TimeSpan time = DateTime.Now - startTime;
            Text = (int)time.TotalMilliseconds + "";

            //Change color
            switch (color)
            {
                case MyColor.Red:
                    if (value < maxValue) BackColor = Color.FromArgb(++value, 0, 0);
                    else
                    {
                        value = 0;
                        color = MyColor.Yellow;
                    }
                    break;

                case MyColor.Yellow:
                    if (value < maxValue) BackColor = Color.FromArgb(maxValue, ++value, 0);
                    else color = MyColor.Green;
                    break;

                case MyColor.Green:
                    if (value > 0) BackColor = Color.FromArgb(--value, maxValue, 0);
                    else color = MyColor.Blue;
                    break;

                case MyColor.Blue:
                    if (value < maxValue) BackColor = Color.FromArgb(0, maxValue, ++value);
                    else color = MyColor.DarkBlue;
                    break;

                case MyColor.DarkBlue:
                    if (value > 0) BackColor = Color.FromArgb(0, --value, maxValue);
                    else color = MyColor.White;
                    break;

                case MyColor.White:
                    if (value < maxValue) BackColor = Color.FromArgb(++value, value, maxValue);
                    else color = MyColor.Black;
                    break;

                case MyColor.Black:
                    if (value > 0) BackColor = Color.FromArgb(--value, value, value);
                    else color = MyColor.Red;
                    break;
            }
        }

        DateTime startTime = DateTime.Now;
    }
}