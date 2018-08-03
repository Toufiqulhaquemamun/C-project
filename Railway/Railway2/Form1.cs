using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway2
{
    public partial class Form1 : Form
    {
        List<Panel> listpanel = new List<Panel>();
        int seatNumber=0;
        string classPrice="";
        string clas = "";
        Dbconnection db = new Dbconnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
                  
            
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            string start = comboBox2.SelectedItem.ToString();
            string destination = comboBox3.SelectedItem.ToString();
            int adult = Int32.Parse(comboBox5.SelectedItem.ToString());
            string clas = comboBox4.SelectedItem.ToString();
            int price;
            if(clas.Equals("AC"))
            {
                price = adult * 600;
            }
            else
            {
                price = adult * 480;
            }

            //string thedate = bunifuDatepicker1.Value.Date.ToString("mm/dd/yyyy");
            //string query = "select routes.trainno,trainname,destination,start,departuretime,date from routes where destination='" + destination +
            //    "' and start='" + start + "' and date ='" + thedate +
            //    "' ";

            textBox1.Text = price.ToString();
            //MessageBox.Show(start+clas+destination+thedate);
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            string start = comboBox1.SelectedItem.ToString();
            string destination = comboBox6.SelectedItem.ToString();
            DateTime thedate = bunifuDatepicker2.Value.Date;//ToString("mm/dd/yyyy");
            seatNumber=Int32.Parse(comboBox11.SelectedItem.ToString());
            clas = comboBox7.SelectedItem.ToString();
            string maxClass="";

            if(clas.Equals("AC"))
            {
                clas = "countAc";
                maxClass = "Acticket";
                classPrice = "acprice";
            }
            else if (clas.Equals("Non Ac"))
            {
                clas = "nonACCount";
                maxClass = "nonac";
                classPrice = "nonacprice";
            }

            //string clas = comboBox7.SelectedItem.ToString();
            string query = "select routes.trainno,trainname,nonacprice,acprice,destination,start,departuretime,date from routes where destination='" + destination +
                "' and start='" + start + "' and date ='" + thedate + "' and " + clas + " + " + seatNumber + "<" + maxClass+" " ;
            dataGridView1.DataSource = db.Route(query);

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Createschedule cs = new Createschedule();
            cs.Show();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            int ticketPrice = Int32.Parse(row.Cells[classPrice].Value.ToString());
            label22.Text += ticketPrice;
            tabControl1.SelectTab(tabPage4);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            String name = row.Cells["Trainno"].Value.ToString();

            string cusName = textBox5.Text;
            string contact = textBox6.Text;
            string email = textBox8.Text;

            try
            {
                string quaryforTicket = "update routes set " + clas + "= " + clas + "+ " + seatNumber + " WHERE Trainno='" + name + "'";
                db.executeQuarry(quaryforTicket);

                string quaryForPassenger = "insert into " + "\"" + name + "\"" + "(name,contactNo,email,seatBooked) Values (" +
                    "'" + cusName + "'," + "'" + contact + "'," + "'" + email + "'," + seatNumber + " )";
                db.executeQuarry(quaryForPassenger);
                MessageBox.Show("Ticket succesfully Purchased");
                tabControl1.Refresh();
                tabControl1.SelectTab(tabPage3);
                label22.Text = "";
            }
            catch (Exception exc) { MessageBox.Show("Ticket purchasing Failed"); }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            label22.Text = "";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            string query = "select * from Routes;";
            dataGridView2.DataSource = db.Route(query);
        }

    }
}
