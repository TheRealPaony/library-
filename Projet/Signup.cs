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
    public partial class Signup : Form
    {
        

        String parametres = "SERVER=127.0.0.1; DATABASE=library; UID=root; PASSWORD=";
        public Signup()
        {
            InitializeComponent();
        }
        public void insertion()
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();        
            String Nom = textBox1.Text;
            String password = textBox2.Text;
            MySqlCommand cmd   = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO user(nom,password) VALUES(@nom,@password)";  
            cmd.Parameters.AddWithValue("@nom", Nom);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery(); 
            connection.Close();
        }

        private bool test()
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            string Nom = textBox1.Text;
            string password = textBox2.Text;
            
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select nom from user where nom=@nom";

            if (cmd.CommandText.Equals(false)) return true;

            return false;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.BackColor = Color.Pink;
            }
            else if (textBox2.Text == "")
            {
                textBox2.BackColor = Color.Pink;
                textBox3.BackColor = Color.Pink;
            }
            else if (textBox2.Text != textBox3.Text)
            {
                textBox2.BackColor = Color.Pink;
                textBox3.BackColor = Color.Pink;
            }
            else if (test() == true)
            {
                errorMsg.Visible = true;
            }
            else
            {
                insertion();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                errorMsg.Visible = false;
                Home h = new Home();
                this.Hide();
                captcha captcha = new captcha();
                captcha.Show();
               
               
            }
            //insere dans la table log pour recuperer l'id de user 
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            String Nom = textBox1.Text;
            String password = textBox2.Text;
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO log(nom,password) VALUES(@Nom,@password)";
            cmd.Parameters.AddWithValue("@nom", Nom);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            connection.Close();

        }

       

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked.Equals(true))
            {
                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;

            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;
            }
        }

     
       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;


        
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Authentification a = new Authentification();
            a.Show();
        }
    }
}
