using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectB
{
    public partial class StudentAttendance : Form
    {
        public StudentAttendance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into [dbo].[StudentAttendance] values (@AttendanceId, @StudentId, @AttendanceStatus)", con);
            //cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@AttendanceId", textBox1.Text);
            cmd.Parameters.AddWithValue("@StudentId", textBox2.Text);
            cmd.Parameters.AddWithValue("@AttendanceStatus", textBox3.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }
    }
}
