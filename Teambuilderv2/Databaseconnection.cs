using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Teambuilderv2
{
    class Databaseconnection
    {
        public SqlConnection cnn;
        private string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =F:\Teambuilder\Teambuilderv2\Database1.mdf; Integrated Security = True"; //F:\Visual Studios Projects\Teambuilderv2\Teambuilderv2\Database1.mdf

        public void connection()
        {

            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                Console.WriteLine("CONNECTION OPEN");
            }
            catch
            {
                //  MessageBox.Show("Connections failed");
            }
        }

        public void close() 
        {
            try
            {
                cnn.Close();
                Console.WriteLine("Closed Connection");
            }
            catch 
            {

            }
        }
    }
}
