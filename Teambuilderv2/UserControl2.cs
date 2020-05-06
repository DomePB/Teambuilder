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
    public partial class UserControl2 : UserControl
    {
        Databaseconnection dbc = new Databaseconnection();
        public UserControl2()
        {
            InitializeComponent();
        }
        public void LoadControl()
        {

            dbc.connection();
            SqlDataAdapter testad = new SqlDataAdapter("SELECT* FROM Players", dbc.cnn);
            DataTable test = new DataTable();
            testad.Fill(test);
            dataGridView1.DataSource = test;
        }
    }
   
}
