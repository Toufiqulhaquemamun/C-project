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
    public partial class Createschedule : Form
    {
        Dbconnection db;
        public Createschedule()
        {
            InitializeComponent();
            db = new Dbconnection();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string trnName = textBox1.Text;
            string start = comboBox2.SelectedItem.ToString();
            string destination = comboBox1.SelectedItem.ToString();
            string time = textBox7.Text;
            int seat= Int32.Parse( textBox8.Text.ToString() );
            int Acseat = Int32.Parse(textBox8.Text.ToString());
            int Nonseat = Int32.Parse(textBox11.Text.ToString());
            int AcPrice = Int32.Parse(textBox9.Text.ToString());
            int NonacPrice = Int32.Parse(textBox10.Text.ToString());
            DateTime date = dateTimePicker1.Value.Date;
            db.createSchedule(trnName, destination, start, date, time, Acseat,Nonseat,AcPrice,NonacPrice);
            MessageBox.Show("Schedule Successfully Created");

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Dispose();
            f1.Show();
        }
    }
}