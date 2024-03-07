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
    public partial class ManageStudent : UserControl
    {
        public ManageStudent()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into [dbo].[Student] values (@FirstName, @LastName, @Contact, @Email, @RegistrationNumber, @Status)", con);
            //cmd.Parameters.AddWithValue("@Id", textBox7.Text);
            cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
            cmd.Parameters.AddWithValue("@Status", int.Parse(textBox6.Text));

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from dbo.Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Student SET FirstName = @FirstName,LastName = @LastName, Contact = @Contact, Email = @Email, RegistrationNumber = @RegistrationNumber, Status = @Status WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@RegistrationNumber", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@Status", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox7.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox7.Text));

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select FirstName, LastName, Contact, Email, RegistrationNumber, Status FROM Student WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox7.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
