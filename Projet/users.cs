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
    
    public partial class users : Form

    {
        private static int cmp = 0;


        String parametres = "SERVER=127.0.0.1; DATABASE=library; UID=root; PASSWORD=";

        public object Livre { get; private set; }
        public users()
        {
          
            InitializeComponent();
            this.EnableBlur();
            BackColor = Color.Azure;
            TransparencyKey = Color.Azure;
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();


           

            int id = cmp++;
            string Nom = textBox2.Text;
            string Cin = textBox3.Text;

            
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "insert into User(id,Nom,Cin) values(@id,@Nom,@Cin)";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Nom",Nom);
            cmd.Parameters.AddWithValue("@Cin",Cin);




            cmd.ExecuteNonQuery();

            connection.Close();

            
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            String request = "select * from User";
            MySqlCommand cmd = new MySqlCommand(request, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(data);
            dataGridView1.DataSource = data;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home Home = new Home();
            Home.Show();
        }

        private void users_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
