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
    public partial class Clo : UserControl
    {
        public Clo()
        {
            InitializeComponent();
        }

        private void Clo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into [dbo].[Clo] values (@Name, @DateCreated, @DateUpdated)", con);
            //cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@DateCreated", textBox3.Text);
            cmd.Parameters.AddWithValue("@DateUpdated", textBox4.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from dbo.Clo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Clo SET Name = @Name,DateCreated = @DateCreated, DateUpdated = @DateUpdated WHERE Id = @Id", con);

            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@DateCreated", textBox3.Text);
            cmd.Parameters.AddWithValue("@DateUpdated", textBox4.Text);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Clo WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name, DateCreated, DateUpdated FROM Clo WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
