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
    public partial class Assessments : UserControl
    {
        public Assessments()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into [dbo].[Assessment] values (@Title, @DateCreated, @TotalMarks, @TotalWeightage)", con);
            //cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@DateCreated", textBox3.Text);
            cmd.Parameters.AddWithValue("@TotalMarks", textBox4.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", textBox5.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from dbo.Assessment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Assessment SET Title = @title,DateCreated = @DateCreated, TotalMarks = @TotalMarks, TotalWeightage = @TotalWeightage WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@DateCreated", textBox3.Text);
            cmd.Parameters.AddWithValue("@TotalMarks", textBox4.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", textBox5.Text);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Assessment WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Title, DateCreated, TotalMarks, TotalWeightage FROM Assessment WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
