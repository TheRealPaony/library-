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
    public partial class Chart : Form
    {
        string parametres = "SERVER=127.0.0.1; DATABASE=library; UID=root; PASSWORD=";
        public Chart()
        {

            InitializeComponent();
            chart1.Titles.Add("Dasboard");

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            MySqlCommand select = connection.CreateCommand();
            //select pour le nombre de livre 
            
            MySqlDataReader reader = select.ExecuteReader();
            String livre = reader[0].ToString();
            select.CommandText = "select count(*) from emprunt WHERE type='livre' ;";
            chart1.Series["s1"].Points.AddXY("Livre", livre);
            reader.Close();

            //select pour le nombre de cd
            MySqlCommand select1 = connection.CreateCommand();
            select1.CommandText = "select count(*) from emprunt WHERE type='cd' ;";
            MySqlDataReader reader1 = select1.ExecuteReader();
            String cd = reader1[0].ToString();
            chart1.Series["s1"].Points.AddXY("Cd", cd);
            reader1.Close();

            //select pour le nombre de periodique
            MySqlCommand select2 = connection.CreateCommand();
            MySqlDataReader reader2 = select2.ExecuteReader();
            select2.CommandText = "select count(*) from emprunt WHERE type='peridoque' ;";

            String periodique = reader1[0].ToString();
            chart1.Series["s1"].Points.AddXY("Periodique", periodique);
            reader1.Close();

            select.ExecuteNonQuery();
            select1.ExecuteNonQuery();
            select2.ExecuteNonQuery();

            connection.Close();
        }

        private void Chart_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }
    }
}
