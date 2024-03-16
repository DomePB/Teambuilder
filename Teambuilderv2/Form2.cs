using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
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
            String[] Taglines = { Convert.ToString(Tagline1.Text), Convert.ToString(Tagline2.Text), Convert.ToString(Tagline3.Text), Convert.ToString(Tagline4.Text), Convert.ToString(Tagline5.Text), Convert.ToString(Tagline6.Text), Convert.ToString(Tagline7.Text), Convert.ToString(Tagline8.Text), Convert.ToString(Tagline9.Text), Convert.ToString(Tagline10.Text) };
          //  textBox1.Text = Textboxarr[0] + "ausgabe";

            Roll(Textboxarr,Taglines);
        }

        private void Roll(String[] p, String[] Tags)
        {
            Matchmaking matchmaking = new Matchmaking();

            (String[] teams, String[] TagsLines) = matchmaking.matchmake(p,Tags);

            Form1 Form1 = new Form1();
            Form1.AusfüllendergerolltenNamen(teams, TagsLines);
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

            textBox1.Text = "Nitror";
            textBox2.Text = "Bitse";
            textBox3.Text = "Don Noway";
            textBox4.Text = "Nitror";
            textBox5.Text = "PhoenixblueLp";
            textBox6.Text = "Envy Carry";
            textBox7.Text = "Witness Azir";
            textBox8.Text = "Tee Tiger";
            textBox9.Text = "xGuts";
            textBox10.Text = "Replay Remix";

        }

        

        private string[] Filter(string [] notFilltered)
        {
            string[] filltered = new string[10];
            int m = 0;
            for(int i = 0;i<notFilltered.Length;i++)
            {
                if(!int.TryParse(notFilltered[i],out _) && !notFilltered[i].Contains(":"))
                {
                    filltered[m] = notFilltered[i];
                    m++;
                }
            }
            return filltered;
        }

        private void discordbot_Click(object sender, EventArgs e)
        {
            TextBox[] Textboxes = { textBox1, Tagline1, textBox2, Tagline2, textBox3, Tagline3, textBox4, Tagline4, textBox5, Tagline5, textBox6, Tagline6, textBox7, Tagline7, textBox8, Tagline8, textBox9, Tagline9, textBox10, Tagline10 };

            int count = 0;
            try
            {


                while (true)
                {
                    using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("Pipe1", PipeDirection.In))
                    {
                        if (!pipeServer.IsConnected)
                        {
                            pipeServer.WaitForConnection();
                        }

                        using (StreamReader sr = new StreamReader(pipeServer))
                        {
                            string playername = sr.ReadLine();
                            string tagline = sr.ReadLine();
                            if (playername != null && tagline != null)
                            {
                                Textboxes[count].Text = playername;
                                count++;
                                Textboxes[count].Text = tagline;
                                count++;
                                Console.WriteLine("Received message from Discord bot: " + playername + tagline);

                            }

                            if (count == 20)
                            {
                                pipeServer.Close();
                                break;
                            }
                        }
                    }

                }

            }
            catch (IOException ex)
            {
                Console.WriteLine("IOException: " + ex.Message);
            }
            finally
            {

            }
        }
    }
}