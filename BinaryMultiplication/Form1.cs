using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryMultiplication
{
    public partial class Form1 : Form
    {
        private int digits;
        private string bin1, bin2;

        public Form1()
        {
            InitializeComponent();
            digits = 4;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bin1 = textBox1.Text;
            label5.Text = "Uzunluk : " + bin1.Length;
            label7.Text = "Durum : Hazır";

            if (textBox1.Text == "")
                label8.Text = "10 Tabanında Karşılığı : ";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bin2 = textBox2.Text;
            label6.Text = "Uzunluk : " + bin2.Length;
            label7.Text = "Durum : Hazır";

            if(textBox2.Text == "")
                label9.Text = "10 Tabanında Karşılığı : ";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Allow backspace, 0 and 1
                e.Handled = !("\b01".Contains(e.KeyChar));
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                label8.Text = String.Format("10 Tabanında Karşılığı : {0} ", Convert.ToInt64(bin1, 2));
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                label9.Text = String.Format("10 Tabanında Karşılığı : {0}", Convert.ToInt64(bin2, 2));
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            int n = int.Parse(((RadioButton)sender).Tag.ToString());
            digits = n;
            textBox1.MaxLength = n;
            textBox2.MaxLength = n;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(sender.Equals(button4))
            {
                InformationPage ip = new InformationPage();
                ip.Show();
            }
            else if(sender.Equals(button5))
            {
                InformationForFirst iff = new InformationForFirst();
                iff.Show();
            }
            else if(sender.Equals(button6))
            {
                InformationForSecond ifs = new InformationForSecond();
                ifs.Show();
            }
            else if (sender.Equals(button7))
            {
                InformationForThird ift = new InformationForThird();
                ift.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value1, value2;
            Multiplication mo;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox1.Text.Length != digits || textBox2.Text.Length != digits)
                label7.Text = "Durum : Eksik veya Hatalı Deger Girdiniz! Lütfen Düzeltiniz.";
            else
            {
                value1 = Convert.ToInt32(textBox1.Text, 2);
                value2 = Convert.ToInt32(textBox2.Text, 2);

                if (sender.Equals(button1))
                    mo = new FirstMethod(digits, value1, value2);
                else if(sender.Equals(button2))
                    mo = new SecondMethod(digits, value1, value2);
                else
                    mo = new ThirdMethod(digits, value1, value2);

                label7.Text = "Durum : Hesaplama Tamamlandı.";
                Panel po = new Panel(mo.registerstates, mo.multiplicandstates, mo.multiplierstates);
                po.ShowDialog();
            }
        }
    }
}
