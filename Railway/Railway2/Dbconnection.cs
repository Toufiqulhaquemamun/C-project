using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway2
{
    class Dbconnection
    {
        SqlConnection connector;
        SqlCommand command;
        //SqlDataReader reader;
        //public int fare;

        public Dbconnection()
        {
            try
            {
                connector = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\C#\Railway2\Dbconnection.mdf;Integrated Security=True;Connect Timeout=30");
            }

            catch (Exception e)
            {
                MessageBox.Show("Connection error" + e);
            }
        }
        public void login(string name, string pass)
        {

        }



        public DataTable Route(string query)
        {

            try
            {
                DataTable dt = null;
                connector.Open();
                //command = new SqlCommand(query,connector);
                //reader = command.ExecuteReader();
                using (SqlCommand cmd = new SqlCommand(query, connector))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable a = new DataTable())
                        {
                            sda.Fill(a);
                            dt=a;
                            connector.Close();
                            return dt;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                connector.Close();
                return null;
            }
            
        }

        //create a new schedule in flight table and a new table with plane name and date
        public void createSchedule(string traiName, string destination, string start,
            DateTime departingDate,string time,int Acseat,int Nonseat,int AcPrice,int NonacPrice)
        {

            string trainId = (traiName) + "-" + (departingDate.Date.ToString("dd-MM-yy"));
            
            //inserting new plane shadule in flight
            string quary = "insert into Routes (Trainno, Trainname,Departuretime,Date,Start,Destination,nonacprice,Acticket,nonac,acprice,countAc,nonACCount) Values (" +
                "'" + trainId + "','" + traiName + "','" + time + "','" + departingDate +
                "','" + start + "','" + destination + "'," + NonacPrice+ ","+ Acseat+ ","+ Nonseat+ ","+ AcPrice+",0,0)";

            executeQuarry(quary);

            //creating new table with plane name and date
            quary = "Create Table " + "\"" + trainId + "\"" + "( name VARCHAR(20) NULL,contactNo VARCHAR(20) NULL,email VARCHAR(20) NULL,seatBooked INT NULL)";
            executeQuarry(quary);
        }


        public void executeQuarry(string quary)
        {
            try
            {
                command = new SqlCommand(quary, connector);
                connector.Open();
                command.ExecuteNonQuery();
                connector.Close();
            }
            catch (Exception e) { MessageBox.Show("Error in executeQuarry\n" + quary + e.ToString()); }
        }
    }
}
