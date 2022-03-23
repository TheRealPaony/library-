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
    public partial class captcha : Form
    {
        int aleatoire=0;
        public captcha()
        {
            InitializeComponent();
            this.EnableBlur();
            BackColor = Color.Gray;
            TransparencyKey = Color.Gray;
            loadCaptcha();
        }
        private void loadCaptcha()
        {
            Random random = new Random();
            aleatoire = random.Next(1000,9999);
            var img = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("Calibri", 30, FontStyle.Regular, GraphicsUnit.Point);
            var graphics = Graphics.FromImage(img);
            graphics.DrawString(aleatoire.ToString(),font, Brushes.Black, new Point(50,20));
            pictureBox1.Image = img;
        }
        private void captcha_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox3.Text != aleatoire.ToString())
            {
                loadCaptcha();
            }
            else
            {
                Authentification authentification = new Authentification();
                this.Hide();
                authentification.Hide();
                Home home = new Home();
                home.Show();
            }
            

        }
    }
}
