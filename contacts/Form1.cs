using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace contacts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string connectin = @"Data Source=ABHILASH\SQLEXPRESS;Initial Catalog=phonebook;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connectin);
        private void Btn_save_Click(object sender, EventArgs e)
        {
           
            string SqlCommand = "INSERT INTO tbl_Contacts(Firstname, Lastname, Phone) VALUES('" + txt_Fname.Text + "','" + txt_Lname.Text + "','" + txt_Mobile.Text + "')";
            conn.Open();
            SqlDataAdapter dtAP = new SqlDataAdapter(SqlCommand,conn);
            DataSet dtSet = new DataSet();
            dtAP.Fill(dtSet);
            MessageBox.Show("data saved");
            conn.Close();
            loading_grid();
    }


        public void loading_grid()
        {
            string SqlCommand = "SELECT * FROM tbl_Contacts";
            conn.Open();
            SqlDataAdapter dtAP = new SqlDataAdapter(SqlCommand, conn);
            DataTable dtTab = new DataTable();
            dtAP.Fill(dtTab);
            dtGrid.DataSource = dtTab;
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            loading_grid();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string SqlCommand = "UPDATE tbl_Contacts SET Firstname='" + txt_Fname.Text + "', Lastname='" + txt_Lname.Text + "', Phone='" + txt_Mobile.Text + "'WHERE id='"+txt_id.Text+"' ";
            conn.Open();
            SqlDataAdapter dtAP = new SqlDataAdapter(SqlCommand, conn);
            DataSet dtSet = new DataSet();
            dtAP.Fill(dtSet);
            MessageBox.Show("data updated");
            conn.Close();
            loading_grid();
            txt_id.Clear();
            txt_Fname.Clear();
            txt_Lname.Clear();
            txt_Mobile.Clear();

        }

        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dtGrid.CurrentRow.Cells[0].Value.ToString();
            txt_Fname.Text = dtGrid.CurrentRow.Cells[1].Value.ToString();
            txt_Lname.Text = dtGrid.CurrentRow.Cells[2].Value.ToString();
            txt_Mobile.Text = dtGrid.CurrentRow.Cells[3].Value.ToString();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            string SqlCommand = "DELETE FROM tbl_Contacts WHERE id='" + txt_id.Text + "' ";
            conn.Open();
            SqlDataAdapter dtAP = new SqlDataAdapter(SqlCommand, conn);
            DataSet dtSet = new DataSet();
            dtAP.Fill(dtSet);
            MessageBox.Show("DELETED");
            conn.Close();
            loading_grid();
            txt_id.Clear();
            txt_Fname.Clear();
            txt_Lname.Clear();
            txt_Mobile.Clear();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            string SqlCommand = "SELECT * FROM tbl_Contacts WHERE(Firstname LIKE '" + txt_search.Text+"%') OR (Lastname LIKE '" + txt_search.Text+ "%') OR (Phone LIKE '" + txt_search.Text + "%')";
            conn.Open();
            SqlDataAdapter dtAP = new SqlDataAdapter(SqlCommand, conn);
            DataTable dtTab = new DataTable();
            dtAP.Fill(dtTab);
            dtGrid.DataSource = dtTab;
            conn.Close();
          
        }

       
    }
}




