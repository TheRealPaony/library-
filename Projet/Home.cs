using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet
{
    public partial class Home : Form
    {
        String parametres = "SERVER=127.0.0.1; DATABASE=library; UID=root; PASSWORD=";

        public Home()
        {


            InitializeComponent();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM log ;";
            MySqlDataReader reader = cmd.ExecuteReader();

            
             if (reader.Read())
            { 
                if(reader[3].ToString() == "user")
                    button6.Visible = true;



            }
          

            reader.Close();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PageLivre livre = new PageLivre();
            livre.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            users users = new users();
            users.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Perio perio = new Perio();
            perio.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cd CD = new Cd() ;
            CD.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Process.Start("file:///C:/Users/hp/source/repos/Projet/req/book1.pdf");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("file:///C:/Users/hp/source/repos/Projet/req/book1.pdf");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start("file:///C:/Users/hp/source/repos/Projet/req/book3.pdf");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            emprunt emprunt = new emprunt();
            this.Hide();
            emprunt.Show();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chart chart = new Chart();
            chart.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
    }

