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
    public partial class Cd : Form
    { 
        //Nouvelle connexion
        String parametres = "SERVER=127.0.0.1; DATABASE=library; UID=root; PASSWORD=";

        public Cd()
        {
            InitializeComponent();
            // affet de blur
            this.EnableBlur();
            BackColor = Color.Azure;
            TransparencyKey = Color.Azure;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // cree la connexion
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            string Nom = textBox1.Text;
            string Type = textBox2.Text;
            string Date = dateTimePicker1.Text;
            
            String type = "cd";

            // envoie vers la tablee cd
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into CD(Nom,Type,Date) values(@Nom,@Type,@Date)";
            cmd.Parameters.AddWithValue("@Nom", Nom);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Date", Date);

            cmd.ExecuteNonQuery();

            //envoi vers table emprunt
            MySqlCommand cmdE = connection.CreateCommand();
            cmdE.CommandText = "insert into emprunt(type,Nom) values(@type,@nom)";
            cmdE.Parameters.AddWithValue("@type", type);
            cmdE.Parameters.AddWithValue("@Nom", Nom);
            cmdE.ExecuteNonQuery();

            connection.Close();

            textBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Affciher dans le datagrid
            DataTable data = new DataTable();
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            String request = "select * from CD";
            MySqlCommand cmd = new MySqlCommand(request, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(data);
            dataGridView1.DataSource = data;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home H = new Home();
            H.Show();
        }

        private void Cd_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}