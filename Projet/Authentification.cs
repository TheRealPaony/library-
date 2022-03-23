using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet
{

 public partial class Authentification : Form
    {
        String parametres = "SERVER=127.0.0.1; DATABASE=library; UID=root; PASSWORD=";
        public Authentification()
        {
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            MySqlCommand reset = connection.CreateCommand();
            reset.CommandText = "Truncate log;";
            reset.ExecuteNonQuery();
            connection.Close();

        }


        private void Authentification_Load(object sender, EventArgs e)
        {

        }
        public Boolean connection()
        {
            //crée une connexion
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            String nom = textBox1.Text;
            String password = textBox2.Text;
            MySqlCommand cmd = connection.CreateCommand();

            // testez si user existe dans table user
            cmd.CommandText = "select * from user WHERE nom='" +nom + "' AND password='" + password +"';";

            //lire le resultat de la requete
            cmd.ExecuteNonQuery();

            // TEST SI LE READER EST VRAI ---> USER EXISTE 
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
                

            }
            connection.Close();


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
                
            }
            else if(connection()==false)
            {
                errorMsg.Visible = true;
                errorMsg2.Visible = true;
            }
            else 
            {
                this.Hide();
                Home H = new Home();

                String nom = textBox1.Text;
                String password = textBox2.Text;
                H.Show();

                //crée une trace de user dans la table log
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                //chercher si user est admin 
                MySqlCommand admin =  connection.CreateCommand();
                admin.CommandText = "select * from user WHERE nom='" + nom + "' AND password='" + password + "';";
                MySqlDataReader reader = admin.ExecuteReader();


                if (reader.Read())
                {
                    if (reader[4].ToString() == "admin")
                    {
                        String variable = reader[4].ToString();
                        MySqlCommand insert = connection.CreateCommand();
                        insert.CommandText = "INSERT INTO log(role) values(@variable);";
                    }
                      

                }

                // envoi ver la table log
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO log(nom,password) values (@nom,@password);";
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@password",password );

                reader.Close();
                cmd.ExecuteNonQuery();
                
                connection.Close();


            }
                 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // boutton de retour
            this.Hide();
            
        }
       
       



        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.AliceBlue;
            errorMsg.Visible = false;
            errorMsg2.Visible = false;

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        { 
            textBox2.BackColor = Color.AliceBlue;
            errorMsg.Visible = false;
            errorMsg2.Visible = false;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked.Equals(true))
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else textBox2.UseSystemPasswordChar = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        
            Application.Exit();
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Signup S = new Signup();
            S.Show();
        }
    }


    //blur EFFECT CODE ********
    public static class WindowExtension
    {
        [DllImport("user32.dll")]
        static internal extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        public static void EnableBlur(this Form @this)
        {
            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;
            var accentStructSize = Marshal.SizeOf(accent);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);
            var Data = new WindowCompositionAttributeData();
            Data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            Data.SizeOfData = accentStructSize;
            Data.Data = accentPtr;
            SetWindowCompositionAttribute(@this.Handle, ref Data);
            Marshal.FreeHGlobal(accentPtr);
        }

    }
    enum AccentState
    {
        ACCENT_ENABLE_BLURBEHIND = 3
    }

    struct AccentPolicy
    {
        public AccentState AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    enum WindowCompositionAttribute
    {
        WCA_ACCENT_POLICY = 19
    }
}
