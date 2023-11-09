using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Teambuilderv2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] Textboxarr = { Convert.ToString(textBox1.Text), Convert.ToString(textBox2.Text), Convert.ToString(textBox3.Text), Convert.ToString(textBox4.Text), Convert.ToString(textBox5.Text), Convert.ToString(textBox6.Text), Convert.ToString(textBox7.Text), Convert.ToString(textBox8.Text)};

            //  textBox1.Text = Textboxarr[0] + "ausgabe";

            Roll(Textboxarr);
        }
        private void Roll(String[] p)
        {
            Matchmaking matchmaking = new Matchmaking();
            String[] teams = matchmaking.arenamatchmake(p);

            Form3 Form3 = new Form3();
            Form3.AusfüllendergerolltenNamen(teams);
            Form3.Show();
            this.Close();
        }

    }
}
