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
            Matchmaking matchmaking = new Matchmaking();

            String[] teams = matchmaking.matchmake(p);

            Form1 Form1 = new Form1();
            Form1.AusfüllendergerolltenNamen(teams);
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
            textBox3.Text = "paulkemper24";
            textBox4.Text = "flappy the bird";
            textBox5.Text = "PhoenixblueLp";
            textBox6.Text = "KingMashallah";
            textBox7.Text = "ItsArtMom";
            textBox8.Text = "havethephlow";
            textBox9.Text = "xGuts";
            textBox10.Text = "TeufelMuffin";

        }
    }
}