using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teambuilderv2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {
            String[] Textboxarr = { Convert.ToString(textBox1.Text), Convert.ToString(textBox2.Text), Convert.ToString(textBox3.Text), Convert.ToString(textBox4.Text), Convert.ToString(textBox5.Text), Convert.ToString(textBox6.Text), Convert.ToString(textBox7.Text), Convert.ToString(textBox8.Text), Convert.ToString(textBox9.Text), Convert.ToString(textBox10.Text) };

          //  textBox1.Text = Textboxarr[0] + "ausgabe";

            Roll(Textboxarr);
        }

        private void Roll(String[] p)
        {

            String[] pauserollen = new String[10]; // NICHT SICHER OB HIER 10 musss aber bei 9 chrashed wenn 9 gerollt wird?????

            for (int swap = 0; swap < pauserollen.Length; swap++)
            {

                pauserollen[swap] = p[swap];

                Console.WriteLine("pausenrollen:" + pauserollen[swap] + "p array:" + p[swap]);

            }

            for (int i = 0; i < p.Length; i++)
            {

                Console.WriteLine("for i zählen " + i);

                Random random = new Random();

                int m = GetRandom();

                Console.WriteLine("m before if" + m);

                if (String.Compare(pauserollen[m], p[0]) != 0 && pauserollen[m] != null)
                {

                    p[i] = pauserollen[m];
                    pauserollen[m] = null;

                    Console.WriteLine("pausenrollen war nicht leer + nicht das selbe");
                }
                else
                {
                    Console.WriteLine("Es war dasselbe why ever oder pausenrollen war leer");
                    int x = GetRandom(); // Darf nicht die selbe sein deshalb nächste while



                    while (x.CompareTo(m) == 0 || pauserollen[x] == null)
                    {
                        x = GetRandom();

                        Console.WriteLine("x" + x);
                    }

                    p[i] = pauserollen[x];
                    pauserollen[x] = null;

                }



            }

            

            for (int forx = 0; forx < p.Length; forx++)
            {

                Console.WriteLine(p[forx]);

            }

            Form1 Form1 = new Form1();
            Form1.AusfüllendergerolltenNamen(p);
            Form1.Show();
            this.Close();
        }

        private static Random rnd = new Random();
        public static int GetRandom()
        {
            return rnd.Next(10);
        }

        private void Stammspieler1_Click(object sender, EventArgs e)
        {

            textBox1.Text = "DomePB";
            textBox2.Text = "Bitse";
            textBox3.Text = "Paulkemper24";
            textBox4.Text = "Flappy the bird";
            textBox5.Text = "Phoenixbluez";

        }
    }
}