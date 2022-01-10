using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinuVorm
{

    public partial class KinoForm : Form
    {

        public PictureBox img = new PictureBox();
        private Control image;

        public Button but;
        private Control button;


        public KinoForm()
        {
            this.ClientSize = new System.Drawing.Size(1000, 600);
            BackColor = Color.LightGray;



            TextBox box = new TextBox();
            box.Location = new Point(70, 100);

            box.Text = "Здравствуйте, Приветствуем вас в кинотеатре \"Надежда\"";
            Font myfont = new Font("Times New Roman", 25.0f);        //изменения размера шрифта
            box.Font = myfont;                                    // хз

            box.ReadOnly = true;                                //только для чтения
            box.Height = 150;
            box.Width = 795;
            box.BackColor = Color.AliceBlue;                //изменяет забний цвет на цвет страницы
            box.BorderStyle = 0;                             // уберает чёрные рамки

            this.Controls.Add(box);
            but = new Button();
            but.BackColor = Color.Yellow;
            but.Text = "Tagasi";
            but.Size = new Size(100, 70);
            but.ForeColor = Color.Green;
            but.Location = new Point(100, 300);
            but.Font = new Font("Times New Roman", 18);
            but.Click += new EventHandler(but_Click);
            this.Controls.Add(but);

            //////////////////////////////////////////////////////////////////////////// 
            img.Size = new Size(1000, 600);
            //img.Image = Image.FromFile(@"..\..\img\kinoshka2.jpg");
            this.Controls.Add(img);
            /////////////////////////////////////////////////////////////////////////////////////
            //
        }

        private void but_Click(object sender, EventArgs e)
        {
            Bilerid uus_aken = new Bilerid();
            this.Hide();
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }          //Класс для автоматического закрытия всплывающего окна при переходе между формами
        /*private void but_Click(object sender, EventArgs e)
        {
            AutoClosingMessageBox.Show("Please Wait", "Treatment", 1000);    //Авто закрытие меседж бокса
            KinoForm Start_form = new KinoForm();    //переходна вторую форму
            Start_form.Show();
            this.Hide();
        }*/                //для меседжа
    }
}