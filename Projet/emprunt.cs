using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet
{

    public partial class emprunt : Form
    {
        String parametres = "SERVER=127.0.0.1; DATABASE=library; UID=root; PASSWORD=";
        public emprunt()
        {
            InitializeComponent();        

           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void emprunt_Load(object sender, EventArgs e)
        {
            // afficher dans le DateGrid
            DataTable data = new DataTable();
            MySqlConnection grid = new MySqlConnection(parametres);
            grid.Open();
            String request = "select * from emprunt";
            MySqlCommand cmd1 = new MySqlCommand(request, grid);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd1);
            adapter.Fill(data);
            dataGridView1.DataSource = data;
            grid.Close();



            //afficher les infos du user
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM log ;";

            MySqlDataReader reader = cmd.ExecuteReader();
            
            string password;
            if (reader.Read())
            {
                username.Text = reader[1].ToString();
              
            }
            reader.Close();

            MySqlCommand cmde = connection.CreateCommand();
            cmde.CommandText = "SELECT num_emp FROM user WHERE nom= '" + username.Text + "';";
            MySqlDataReader reader1 = cmde.ExecuteReader();

            if (reader1.Read())
            {
                nombre.Text = reader1[0].ToString();
            }
            reader1.Close();
            connection.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection connection1 = new MySqlConnection(parametres);
            connection1.Open();
            MySqlCommand cmd = connection1.CreateCommand();
            cmd.CommandText = "SELECT num_emp FROM user WHERE nom= '" + username.Text + "';";
            MySqlDataReader reader1 = cmd.ExecuteReader();
            int i; 
            if (reader1.Read())
            {
                nombre.Text = reader1[0].ToString();
                i = int.Parse(nombre.Text)-1;

                if (i < 0) { }

                
                
            }
            reader1.Close();
            connection1.Close();

            //emprunter
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            MySqlCommand cmde = connection.CreateCommand();
            cmde.CommandText = "DELETE FROM emprunt where nom ='" + textBox1.Text+"' && type ='"+ textBox2.Text+"';";
            connection.close();
        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home Home = new Home();
            Home.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
