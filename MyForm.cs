using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinuVorm
{
    public partial class MyForm : Form
    {
        Label message = new Label();
        Button[] btn = new Button[4];
        string[] texts = new string[4];
        TableLayoutPanel tlp = new TableLayoutPanel();
        Button btn_tabel;
        int btn_w, btn_h;
        public MyForm()                       //пустая форма
        {}
        public MyForm(string title, string body, string button1, string button2, string button3, string button4)        //создание кнопок/тайтла/надписи
        {
            texts[0] = button1;                                       //обьявляем что находится под каким номером в массиве
            texts[1] = button2;
            texts[2] = button3;
            texts[3] = button4;
            this.ClientSize = new System.Drawing.Size(400, 100);
            BackColor = Color.Beige;
            this.Text = title;
            int x = 10;
            for (int i = 0; i < 4; i++)                               //цикл раставляющий кнопки по каардинатам
            {
                btn[i] = new Button
                {
                    Location = new System.Drawing.Point(x, 50),
                    Size=new System.Drawing.Size(80,25),
                    Text=texts[i]
                };
                btn[i].Click += MyForm_Click;
                x += 100;
                this.Controls.Add(btn[i]);
            }
            message.Location = new System.Drawing.Point(10, 10);     //расположение месаджа
            message.Text = body;                                     //берём названия из боди
            this.Controls.Add(message);                              //добавление месаджа

        }                                                   

        public MyForm(int read,int kohad)                     //форма с кучей кнопок
        {
            this.tlp.ColumnCount = kohad;
            this.tlp.RowCount = read;
            this.tlp.ColumnStyles.Clear();
            this.tlp.RowStyles.Clear();
            int i, j;
            for ( j = 0; j < read; j++)
            {
                this.tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / read));
                this.tlp.RowStyles[0].Height = 100 / read;
            }
            
            for ( j = 0; j < kohad; j++)
            {
                this.tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / kohad));
                this.tlp.ColumnStyles[j].Width = 100 / kohad;
            }
            this.Size = new System.Drawing.Size(kohad * 100, read * 100);            //создаёт форме размер
            for ( i = 0; i < read; i++)
            {
                for ( j = 0; j < kohad; j++)
                {
                    btn_tabel = new Button 
                    {
                        Text = string.Format("{0}{1}", i, j),
                        Name = string.Format("btn_{0}{1}",i,j),
                        Dock=DockStyle.Fill

                    };
                    this.tlp.Controls.Add(btn_tabel, i, j);
                }

            }
            //btn_w = (int)(100 / kohad);
            //btn_h = (int)(100 / read);
            this.tlp.Dock = DockStyle.Fill;
            //this.tlp.Size = new System.Drawing.Size(tlp.ColumnCount*btn_w,tlp.RowCount*btn_h);
            BackColor = Color.Beige;
            this.Controls.Add(tlp);
        }
            private void MyForm_Click(object sender, EventArgs e)            //выводит надпись "первую вторую третью четвёртую кнопку нажали"
            {
            Button btn_click = (Button)sender;
            MessageBox.Show("Oli valitud "+btn_click.Text+" nupp");
            BackColor = Color.Beige;
        }
    }
}