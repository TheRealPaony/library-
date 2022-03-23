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
    public partial class PageLivre : Form
    {
        String parametres = "SERVER=127.0.0.1; DATABASE=library; UID=root; PASSWORD=";

        public object Livre { get; private set; }

        public PageLivre()
        {

            InitializeComponent();
            this.EnableBlur();
            BackColor = Color.Gray;
            TransparencyKey = Color.Gray;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ouverture de connexion
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            string Auteur = textBox1.Text;
            string Nom = textBox2.Text;
            string Date = dateTimePicker1.Text;
            String type = "livre";

            // envoi vers table livre 
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into Livre(Auteur,Nom,Date) values(@Auteur,@Nom,@Date)";
            cmd.Parameters.AddWithValue("@Auteur", Auteur);
            cmd.Parameters.AddWithValue("@Nom", Nom);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.ExecuteNonQuery();

            //envoi vers table emprunt
            MySqlCommand cmdE = connection.CreateCommand();
            cmdE.CommandText = "insert into emprunt(type,Nom,date_ajout) values(@type,@nom,@Date)";
            cmdE.Parameters.AddWithValue("@type",type);
            cmdE.Parameters.AddWithValue("@Nom", Nom);
            cmdE.Parameters.AddWithValue("@Date",Date);

            // execution
            
            cmdE.ExecuteNonQuery();

            //fermer la connection
            connection.Close();

            // vider les champs
            textBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            // button de retour
            this.Hide();
            Home H = new Home();
            H.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // afficher dans le DateGrid
            DataTable data = new DataTable();
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            String request = "select * from Livre";
            MySqlCommand cmd = new MySqlCommand(request, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(data);
            dataGridView1.DataSource = data;
            connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PageLivre_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int item = 0; item <= dataGridView1.Rows.Count - 1; item++)
            {
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "Update livre set Auteur=@Auteur,Nom=@Nom,Date=@Date where id=@id";


                cmd.Parameters.AddWithValue("@Auteur", dataGridView1.Rows[item].Cells[1].Value);
                cmd.Parameters.AddWithValue("@Nom", dataGridView1.Rows[item].Cells[2].Value);
                cmd.Parameters.AddWithValue("@Date", dataGridView1.Rows[item].Cells[3].Value);

                cmd.Parameters.AddWithValue("id", dataGridView1.Rows[item].Cells[0].Value);

                cmd.ExecuteNonQuery();

                connection.Close();

            }
        }
    }
}
