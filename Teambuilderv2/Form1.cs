using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Teambuilderv2
{
    public partial class Form1 : Form
    {
         //string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\dome2\Documents\GitHub\Teambuilder\Teambuilderv2\Database1.mdf; Integrated Security = True"; //F:\Visual Studios Projects\Teambuilderv2\Teambuilderv2\Database1.mdf
       //  SqlConnection cnn;
       
        Databaseconnection dbc = new Databaseconnection();
        String[] team1 = new String[5];
        String[] team2 = new String[5];
        String[] players = new String[10];
        PictureBox[] pictureboxesarr = new PictureBox[10];
        bool matchhistoryvis = true;
        bool statsvis = true;
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
                    players[m] = ausfüllen[m];
                }
                else 
                {
                    team2[m - 5] = ausfüllen[m];
                    players[m] = ausfüllen[m];
                }
            }
            Ausfüllenranks();
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
       

        //Team1 Win Button
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

            SqlCommand match = new SqlCommand($"INSERT INTO Matchhistory(Team1Top,Team1jungle,Team1Mid,Team1Adc,Team1Support,Team2Top,Team2Jungle,Team2Mid,Team2Adc,Team2Support,TeamWin) VALUES('{team1[0]}','{team1[1]}','{team1[2]}','{team1[3]}','{team1[4]}','{team2[0]}','{team2[1]}','{team2[2]}','{team2[3]}','{team2[4]}','Team1Win')", dbc.cnn);
            match.ExecuteNonQuery();
   
           
            dbc.close();
        }

        // Team2Win button
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

            SqlCommand match = new SqlCommand($"INSERT INTO Matchhistory(Team1Top,Team1jungle,Team1Mid,Team1Adc,Team1Support,Team2Top,Team2Jungle,Team2Mid,Team2Adc,Team2Support,TeamWin) VALUES('{team1[0]}','{team1[1]}','{team1[2]}','{team1[3]}','{team1[4]}','{team2[0]}','{team2[1]}','{team2[2]}','{team2[3]}','{team2[4]}','Team2Win')", dbc.cnn);
            match.ExecuteNonQuery();

           
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
            Ausfüllenranks();
        }

        // Matchhistory anzeigen

        //Matchhistory
        private void button7_Click(object sender, EventArgs e)
        {

            

            if(matchhistoryvis)
            {
                matchhistoryvis = false;
                userControl11.Show();
                userControl11.BringToFront();
                userControl11.LoadControl();
                

            }
            else
            {
               
                matchhistoryvis = true;
                userControl11.Hide();
               if(!statsvis)
                {
                    userControl21.Hide();
                    statsvis = true;
                }
               
            }
            
        }

        // Stats
        private void button8_Click(object sender, EventArgs e)
        {
            if (statsvis)
            {
                statsvis = false;
                userControl21.Show();
                userControl21.BringToFront();
                userControl21.LoadControl();


            }
            else
            {

               statsvis = true;
                userControl21.Hide();
                if (!matchhistoryvis)
                {
                    userControl11.Hide();
                    matchhistoryvis = true;
                }

            }
        }

        private void test_Click(object sender, EventArgs e)
        {
            Ausfüllenranks();
           /*
                LolClientApi lc = new LolClientApi();
                Member[] result = lc.GetMembers();
              MessageBox.Show(" "+result[0].summonerId);
                Console.WriteLine(result[0].summonerId);
                */
            

            
        }

        private double getrank(string playername)
        {
            Matchmaking m = new Matchmaking();
            double rank = m.rank(playername);
            
            return rank;
        }
        
        private string rankToFile(int i)
        {
            double rank = getrank(players[i]);
            switch(rank)
                {
                case double n when n < 400:
                  
                    return Path.GetFullPath("iron.jpg");
                case double n when 400<=n && n<800:
                    return Path.GetFullPath("bronze.jpg");
                case double n when 800<=n && n<1200:
                    return Path.GetFullPath("silber.jpg");
                case double n when 1200<=n && n<1600:
                    return Path.GetFullPath("gold.jpg");
                case double n when 1600 <= n && n < 2000:
                    return Path.GetFullPath("platin.jpg");
                case double n when 2000 <= n && n < 2400:
                    Console.WriteLine(Path.GetFullPath("diamond.jpg"));
                    return Path.GetFullPath("diamond.jpg");
                case double n when 2400 <= n && n < 2800:
                    Console.WriteLine("master:", Path.GetFullPath("master.jpg"));
                    return Path.GetFullPath("master.jpg");
                case double n when 2800 <= n && n < 3200:
                    return Path.GetFullPath("grandmaster.jpg");
                case double n when 3200 <=n:
                    return Path.GetFullPath("challenger.jpg");
                default:
                    return null;

            }

        }

        public void Ausfüllenranks()
        {
            pictureboxesarr[0] = pictureBox1;
            pictureboxesarr[1] = pictureBox2;
            pictureboxesarr[2] = pictureBox3;
            pictureboxesarr[3] = pictureBox4;
            pictureboxesarr[4] = pictureBox5;
            pictureboxesarr[5] = pictureBox6;
            pictureboxesarr[6] = pictureBox7;
            pictureboxesarr[7] = pictureBox8;
            pictureboxesarr[8] = pictureBox9;
            pictureboxesarr[9] = pictureBox10;

            for (int i = 0; i < 10; i++)
            {
                string path = rankToFile(i);
                if(path != null)
                {
                    pictureboxesarr[i].Image = Image.FromFile(path);
                    pictureboxesarr[i].SizeMode = PictureBoxSizeMode.Zoom;
                    pictureboxesarr[i].SizeMode = PictureBoxSizeMode.CenterImage;
                }
                
            }
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
