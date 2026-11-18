using System;

namespace TransConnect
{
    public class Salarie : Personne
    {
        private DateTime dateEntree;
        private string poste;
        private double salaire;
        private double tarifHoraire;
        private List<Commande> commandes;

        public Salarie(string nss, string nom, string prenom, DateTime dateNaissance, string adresse, string ville, string email, string telephone, DateTime dateEntree, string poste, double salaire)
            : base(nss, nom, prenom, dateNaissance, adresse, ville, email, telephone)
        {
            this.dateEntree = dateEntree;
            this.poste = poste;
            this.salaire = salaire;
            this.tarifHoraire = CalculerTarifHoraire();
            this.commandes = new List<Commande>();
        }

        public DateTime DateEntree
        {
            get { return dateEntree; }
            set { dateEntree = value; }
        }

        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }

        public double Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }

        public double TarifHoraire
        {
            get { return tarifHoraire; }
            private set { tarifHoraire = value; }
        }

        public int CalculerAnciennete()
        {
            return DateTime.Now.Year - dateEntree.Year;
        }

        private double CalculerTarifHoraire()
        {
            int anciennete = CalculerAnciennete();
            return 20 + anciennete * 25; // 20€ de base + 25€ par année d'ancienneté
        }

        public override string Details()
        {
            return $"{nom} {prenom}, {adresse}, {ville}, {email}, {telephone}, Poste: {poste}, Salaire: {salaire}, Tarif Horaire: {tarifHoraire}, Date d'entrée: {dateEntree.ToShortDateString()}, Nombre de commandes: {commandes.Count}";
        }


    }
}
