using System;
using System.Collections;
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
    public partial class Panel : Form
    {
        private string[] registerStates;
        private string[] multiplicandStates;
        private string[] multiplierStates;
        private int regNo;
        private TextBox[] registerTboxs;
        private TextBox[] multiplicandTboxs;
        private TextBox[] multiplierTboxs;
        private Label[] labels;

        public Panel(string[] registerStates, string[] multiplicandStates, string[] multiplierStates)
        {
            this.registerStates = registerStates;
            this.multiplicandStates = multiplicandStates;
            this.multiplierStates = multiplierStates;
            this.regNo = registerStates.Length;
            registerTboxs = new TextBox[registerStates.Length];
            multiplicandTboxs = new TextBox[registerStates.Length];
            multiplierTboxs = new TextBox[registerStates.Length];
            labels = new Label[registerStates.Length];
            InitializeComponent();

            RegisterTboxsCreator();
            MultiplicandTboxsCreator();
            MultiplierTboxsCreator();
            LabelCreator();
            TboxEntry();
        }

        private void RegisterTboxsCreator()
        {
            for (int i = 0; i < regNo; i++)
            {
                TextBox tbox = new TextBox();
                tbox.Height = 20;
                tbox.Width = 200;
                tbox.Location = new Point(65, 35 + i * 25);
                this.Controls.Add(tbox);
                registerTboxs[i] = tbox;
            }
        }

        private void MultiplicandTboxsCreator()
        {
            for (int i = 0; i < regNo; i++)
            {
                TextBox tbox = new TextBox();
                tbox.Height = 20;
                tbox.Width = 160;
                tbox.Location = new Point(275, 35 + i * 25);
                this.Controls.Add(tbox);
                multiplicandTboxs[i] = tbox;
            }
        }

        private void MultiplierTboxsCreator()
        {
            for (int i = 0; i < regNo; i++)
            {
                TextBox tbox = new TextBox();
                tbox.Height = 20;
                tbox.Width = 160;
                tbox.Location = new Point(445, 35 + i * 25);
                this.Controls.Add(tbox);
                multiplierTboxs[i] = tbox;
            }
        }

        private void LabelCreator()
        {
            for (int i = 0; i < regNo; i++)
            {
                Label lbl = new Label();
                lbl.Height = 20;
                lbl.Width = 30;
                lbl.Location = new Point(10, 35 + i * 25);
                this.Controls.Add(lbl);
                labels[i] = lbl;
            }
            LabelRenamed();
        }

        private void LabelRenamed()
        {
            int j = 1;
            if (regNo % 3 == 0)
            {
                for(int i = 0, counter = 0; i < regNo; i++, counter++)
                {
                    if(counter == 0)
                        labels[i].Text = String.Format("{0} a", j);
                    else if(counter == 1)
                        labels[i].Text = String.Format("{0} b", j);
                    else
                    {
                        labels[i].Text = String.Format("{0} c", j);
                        counter = -1;
                        j++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < regNo; i++)
                {
                    if (i % 2 == 0)
                        labels[i].Text = String.Format("{0} a", j);
                    else
                    {
                        labels[i].Text = String.Format("{0} b", j);
                        j++;
                    }
                }
            }
        }

        private void TboxEntry()
        {
            int counter = 0;
            string temp;
            for(int i = 0; i < regNo; i++)
            {
                registerTboxs[i].Text = registerStates[i];
                multiplicandTboxs[i].Text = multiplicandStates[i];
                multiplierTboxs[i].Text = multiplierStates[i];
                temp = labels[i].Text;

                if(temp.Contains("a") && regNo % 3 != 0)
                {
                    multiplicandTboxs[i].ForeColor = Color.Red;
                    multiplierTboxs[i].ForeColor = Color.Red;
                }
                else if(temp.Contains("b") && regNo % 3 != 0)
                {
                    registerTboxs[i].ForeColor = Color.Red;
                    multiplicandTboxs[i].ForeColor = Color.Green;
                    multiplierTboxs[i].ForeColor = Color.Green;
                }
                else if(temp.Contains("a") && regNo % 3 == 0)
                {
                    multiplierTboxs[i].ForeColor = Color.Red;
                    counter++;
                }
                else if (temp.Contains("b") && regNo % 3 == 0)
                {
                    multiplicandTboxs[i].ForeColor = Color.Red;
                    registerTboxs[i].ForeColor = Color.Red;
                }
                else if (temp.Contains("c") && regNo % 3 == 0)
                {
                    registerTboxs[i].ForeColor = Color.Red;
                    multiplicandTboxs[i].ForeColor = Color.Green;
                    multiplierTboxs[i].ForeColor = Color.Green;
                }
            }
        }
    }
}
