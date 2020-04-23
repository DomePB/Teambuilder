using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Teambuilderv2
{
    public partial class UserControl1 : UserControl
    {
        Databaseconnection cnn = new Databaseconnection();
        public UserControl1()
        {
            InitializeComponent();
        }

        public void Loadcontrol()
        {
            cnn.connection();
            SqlDataAdapter testad = new SqlDataAdapter("SELECT Team1Top,Team1Jungle,Team1Mid,Team1Adc,Team1Support,Team2Top,Team2Jungle,Team2Mid,Team2Adc,Team2Support,TeamWin FROM Matchhistory", cnn.cnn);
            DataTable test = new DataTable();
            testad.Fill(test);
            dataGridView1.DataSource = test;

        }
    }


    
}
