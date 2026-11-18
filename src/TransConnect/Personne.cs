using System;

namespace TransConnect
{
    public abstract class Personne //Classe abstraite mere de salarie et client
    {
        protected string nss;
        protected string nom;
        protected string prenom;
        protected DateTime dateNaissance;
        protected string adresse;
        protected string ville;
        protected string email;
        protected string telephone;

        public Personne(string nss, string nom, string prenom, DateTime dateNaissance, string adresse, string ville, string email, string telephone)
        {
            this.nss = nss;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance;
            this.adresse = adresse;
            this.ville = ville;
            this.email = email;
            this.telephone = telephone;
        }

        public string NSS
        {
            get { return nss; }
            set { nss = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public DateTime DateNaissance
        {
            get { return dateNaissance; }
            set { dateNaissance = value; }
        }

        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public override string ToString()
        {
            return $"{nom} {prenom}, {adresse}, {ville}, {email}, {telephone}";
        }
        public abstract string Details();//methode abstraite
    }
}
