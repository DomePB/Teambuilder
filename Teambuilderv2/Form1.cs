﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Teambuilderv2
{
    public partial class Form1 : Form
    {
        // string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =F:\Teambuilder\Teambuilderv2\Database1.mdf; Integrated Security = True"; //F:\Visual Studios Projects\Teambuilderv2\Teambuilderv2\Database1.mdf
        // SqlConnection cnn;
        Databaseconnection dbc = new Databaseconnection();
        String[] team1 = new String[5];
        String[] team2 = new String[5];
        public Form1()
        {
            InitializeComponent();
            //Connectionst();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            var RollenForm = new Form2();
            RollenForm.Show();
            this.Hide();
        }
        public void AusfüllendergerolltenNamen(String[] ausfüllen)
        {
          
            Console.WriteLine("aufüllenwirdausgeführt");
            for (int forx = 0; forx < ausfüllen.Length; forx++)
            {
                Console.WriteLine(ausfüllen[forx]);
            }
            Ausgabe1.Text = Convert.ToString(ausfüllen[0]);
            Ausgabe2.Text = Convert.ToString(ausfüllen[1]);
            Ausgabe3.Text = Convert.ToString(ausfüllen[2]);
            Ausgabe4.Text = Convert.ToString(ausfüllen[3]);
            Ausgabe5.Text = Convert.ToString(ausfüllen[4]);
            Ausgabe6.Text = Convert.ToString(ausfüllen[5]);
            Ausgabe7.Text = Convert.ToString(ausfüllen[6]);
            Ausgabe8.Text = Convert.ToString(ausfüllen[7]);
            Ausgabe9.Text = Convert.ToString(ausfüllen[8]);
            Ausgabe10.Text = Convert.ToString(ausfüllen[9]);

            for (int m = 0; m < 10; m++)
            {
                if (m < 5)
                {
                    team1[m] = ausfüllen[m];
                }
                else 
                {
                    team2[m - 5] = ausfüllen[m];
                }
            }
        }
      /*  private void Connectionst()
        {
            
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connections succesfull");
            }
            catch
            {
              //  MessageBox.Show("Connections failed");
            }
        }*/
        //Ausgabe button der Datenbank
        private void Button2_Click(object sender, EventArgs e)
        {


            dbc.connection();
            SqlDataAdapter testad = new SqlDataAdapter("SELECT* FROM Players", dbc.cnn);
            DataTable test = new DataTable();
            testad.Fill(test);
            dataGridView1.DataSource = test;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            dbc.connection();
            MessageBox.Show("Team1 Win");
           
            for(int m = 0; m < 5; m++) 
            {
                SqlCommand players = new SqlCommand("SELECT COUNT(Playername) FROM Players WHERE Playername =@team1playername", dbc.cnn);
                players.Parameters.Add("@team1playername", team1[m]);
                int x = (int)players.ExecuteScalar();
                if (x == 1)
                {
                    SqlCommand updatewins = new SqlCommand($"UPDATE Players SET TotalWins=TotalWins+1 WHERE Playername='{team1[m]}'", dbc.cnn);
                    updatewins.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand filltest = new SqlCommand($"INSERT INTO Players(PlayerName,TotalWins,TotalLooses) VALUES('{team1[m]}',1,0)", dbc.cnn);
                    filltest.ExecuteNonQuery();
                }
            }

            for (int m = 0; m < 5; m++)
            {
                SqlCommand players = new SqlCommand("SELECT COUNT(Playername) FROM Players WHERE Playername =@team2playername", dbc.cnn);
                players.Parameters.Add("@team2playername", team2[m]);
                int x = (int)players.ExecuteScalar();
                if (x == 1)
                {
                    SqlCommand updatewins = new SqlCommand($"UPDATE Players SET TotalLooses=TotalLooses+1 WHERE Playername='{team2[m]}'", dbc.cnn);
                    updatewins.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand filltest = new SqlCommand($"INSERT INTO Players(PlayerName,TotalWins,TotalLooses) VALUES('{team2[m]}',0,1)", dbc.cnn);
                    filltest.ExecuteNonQuery();
                }
            }

            SqlDataAdapter testad = new SqlDataAdapter("SELECT* FROM Players", dbc.cnn);
            DataTable test = new DataTable();
            testad.Fill(test);
            dataGridView1.DataSource = test;
            dbc.close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            dbc.connection();
            MessageBox.Show("Team2 Win");

            for (int m = 0; m < 5; m++)
            {
                SqlCommand players = new SqlCommand("SELECT COUNT(Playername) FROM Players WHERE Playername =@team2playername", dbc.cnn);
                players.Parameters.Add("@team2playername", team2[m]);
                int x = (int)players.ExecuteScalar();
                if (x == 1)
                {
                    SqlCommand updatewins = new SqlCommand($"UPDATE Players SET TotalWins=TotalWins+1 WHERE Playername='{team2[m]}'", dbc.cnn);
                    updatewins.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand filltest = new SqlCommand($"INSERT INTO Players(PlayerName,TotalWins,TotalLooses) VALUES('{team2[m]}',1,0)", dbc.cnn);
                    filltest.ExecuteNonQuery();
                }
            }

            for (int m = 0; m < 5; m++)
            {
                SqlCommand players = new SqlCommand("SELECT COUNT(Playername) FROM Players WHERE Playername =@team1playername", dbc.cnn);
                players.Parameters.Add("@team1playername", team1[m]);
                int x = (int)players.ExecuteScalar();
                if (x == 1)
                {
                    SqlCommand updatewins = new SqlCommand($"UPDATE Players SET TotalLooses=TotalLooses+1 WHERE Playername='{team1[m]}'", dbc.cnn);
                    updatewins.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand filltest = new SqlCommand($"INSERT INTO Players(PlayerName,TotalWins,TotalLooses) VALUES('{team1[m]}',0,1)", dbc.cnn);
                    filltest.ExecuteNonQuery();
                }
            }

            SqlDataAdapter testad = new SqlDataAdapter("SELECT* FROM Players", dbc.cnn);
            DataTable test = new DataTable();
            testad.Fill(test);
            dataGridView1.DataSource = test;
            dbc.close();
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {

            dbc.connection();
            SqlDataAdapter playersearch = new SqlDataAdapter("SELECT* FROM Players WHERE Playername =@playername", dbc.cnn);
            playersearch.SelectCommand.Parameters.Add("@playername", search1.Text);
            // playersearch.SelectCommand.Parameters.Add("@playername",searchbutton.Text);
           
            DataTable test = new DataTable();
            playersearch.Fill(test);
            dataGridView1.DataSource = test;

            dbc.close();
        }

        private void send_Click(object sender, EventArgs e)
        {
            capture(Screen.PrimaryScreen,"teams.png");
            using (dWebHook dcWeb = new dWebHook())
            
            {
                dcWeb.ProfilePicture = "";
                dcWeb.UserName = "Mannfred";
                dcWeb.WebHook = "https://discordapp.com/api/webhooks/681283305647505423/HV3ZJaij4ZpXDuU_iHw53mrDufLcSG_RXluqhInfterjjVRk1_jibh_MPSWLS984CNhw";
                //  dcWeb.SendMessage(i);
                dcWeb.SendPicture();
            }
        }

        private static void capture(Screen window,string file)
        {
            /* try
            {
                Rectangle s_rect = Screen.GetBounds(Point.Empty);
                using (Bitmap bmp = new Bitmap(s_rect.Width, s_rect.Height))
                {
                    using (Graphics gScreen = Graphics.FromImage(bmp))
                        gScreen.CopyFromScreen(Point.Empty, Point.Empty, s_rect.Size);
                    bmp.Save(file, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch (Exception) { /*TODO: Any exception handling. /} */
        
             var frm = Form.ActiveForm;
            using (var bmp = new Bitmap(frm.Width, frm.Height))
            {
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(file, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        // REROLL BUTTON
        private void button6_Click(object sender, EventArgs e)
        {
            String[] playernames = new String[10];

            for (int i = 0; i < 5; i++) 
            {
                playernames[i] = team1[i];
            }
            for (int m = 5; m < 10; m++) 
            {
                playernames[m] = team2[m-5];
            }
            Matchmaking matchmaking = new Matchmaking();

            String[] teams = matchmaking.matchmake(playernames);
            AusfüllendergerolltenNamen(teams);
        }

        /*  private void button5_Click(object sender, EventArgs e)
          {
              Summoner_V4 summoner = new Summoner_V4();
              long x = summoner.GetSummonerByName("ItsArtMom").SummonerLevel;
              string id = summoner.GetSummonerByName("ItsArtMom").Id;
             // MessageBox.Show("lvl:"+x);

              League_V4 league = new League_V4();
              string tier = league.GetLeagueByName(id).FirstOrDefault().tier;
              string rank = league.GetLeagueByName(id).FirstOrDefault().rank;
              int lp = league.GetLeagueByName(id).FirstOrDefault().leaguePoints;

              MessageBox.Show("lvl: " + x +" tier: "+ tier + rank+" lp: "+lp);
          }
          */
    }
    
}
