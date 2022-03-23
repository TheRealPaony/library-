using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Projet
{
    class ouvrage
    {
        private String auteur;
        private String titre;
        private String cote;
        private String dateEmprunt;

        public string Auteur { get => auteur; set => auteur = value; }
        public string Titre { get => titre; set => titre = value; }
        public string DateEmprunt { get => dateEmprunt; set => dateEmprunt = value; }
        public string Cote { get => cote; set => cote = value; }



        private ouvrage(String auteur, String titre, String cote, String dateEmprunt)
        {
            this.auteur = auteur;
            this.titre = titre;
            this.cote = cote;
            this.dateEmprunt = DateEmprunt;

        }

        void toString()
        {
            Console.Out.WriteLine("L'auteur : " + auteur + " Titre :" + titre + " cote :" + cote + " date d'emprunt :" + DateEmprunt);
        }
    }
}