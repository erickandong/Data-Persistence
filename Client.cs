using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_des_données
{
    internal class Client
    {

        //Attributs
        public string _nom;
        public string _prenom;


        //Propriétés
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }


        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }


        //Constructeur
        public Client(string nom, string prenom)
        {
            this._nom = nom;
            this._prenom = prenom;
        }

        //Constructeur par défaut qui va permettre d'extancier un objet sans valeur
        public Client() { }

        //Methode
        public void Information()
        {
            Console.WriteLine("Bonjour je suis " + _nom + " " + _prenom);
        }

    }
}
