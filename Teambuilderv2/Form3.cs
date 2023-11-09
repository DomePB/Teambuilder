﻿using System;
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
    public partial class Form3 : Form
    {
        String[] team1 = new String[4];
        String[] team2 = new String[4];
        String[] players = new String[8];
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ArenaRollen = new Form4();
            ArenaRollen.Show();
            this.Hide();
        }
        public void AusfüllendergerolltenNamen(String[] ausfüllen)
        {

            Console.WriteLine("aufüllenwirdausgeführt");
            Ausgabe1.Text = Convert.ToString(ausfüllen[0]);
            Ausgabe2.Text = Convert.ToString(ausfüllen[1]);
            Ausgabe3.Text = Convert.ToString(ausfüllen[2]);
            Ausgabe4.Text = Convert.ToString(ausfüllen[3]);
            Ausgabe5.Text = Convert.ToString(ausfüllen[4]);
            Ausgabe6.Text = Convert.ToString(ausfüllen[5]);
            Ausgabe7.Text = Convert.ToString(ausfüllen[6]);
            Ausgabe8.Text = Convert.ToString(ausfüllen[7]);

            for (int m = 0; m < 8; m++)
            {
                if (m < 4)
                {
                    team1[m] = ausfüllen[m];
                    players[m] = ausfüllen[m];
                }
                else
                {
                    team2[m - 4] = ausfüllen[m];
                    players[m] = ausfüllen[m];
                }
            }
           
        }
    }
}
