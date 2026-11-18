using System;

namespace TransConnect
{
    public class Commande
    {
        private string numeroCommande;
        private Client client;
        private Salarie chauffeur;
        private IVehicule vehicule;
        private string villeDepart;
        private string villeArrivee;
        private DateTime date;
        private double prix;
        private double temps;

        public Commande(string numeroCommande, Client client, Salarie chauffeur, IVehicule vehicule, string villeDepart, string villeArrivee, DateTime date, Graph graph)
        {
            this.numeroCommande = numeroCommande;
            this.client = client;
            this.chauffeur = chauffeur;
            this.vehicule = vehicule;
            this.villeDepart = villeDepart;
            this.villeArrivee = villeArrivee;
            this.date = date;
            CalculerPrixEtTemps(graph);
        }

        public string NumeroCommande
        {
            get { return numeroCommande; }
            set { numeroCommande = value; }
        }

        public Client Client
        {
            get { return client; }
            set { client = value; }
        }

        public Salarie Chauffeur
        {
            get { return chauffeur; }
            set { chauffeur = value; }
        }

        public IVehicule Vehicule
        {
            get { return vehicule; }
            set { vehicule = value; }
        }

        public string VilleDepart
        {
            get { return villeDepart; }
            set { villeDepart = value; }
        }

        public string VilleArrivee
        {
            get { return villeArrivee; }
            set { villeArrivee = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public double Prix
        {
            get { return prix; }
            private set { prix = value; }
        }

        public double Temps
        {
            get { return temps; }
            private set { temps = value; }
        }

        public void CalculerPrixEtTemps(Graph graph)
        {
            double distance = graph.CalculerDistance(villeDepart, villeArrivee);
            if (distance == double.MaxValue)
            {
                prix = 0;
                temps = 0;
                return;
            }
            temps = distance / 90.0; // km par heure

            double tarifHoraire = chauffeur.TarifHoraire; // Utilisation du tarif horaire du chauffeur basé sur son ancienneté
            prix = temps * tarifHoraire;
        }


        public override string ToString()
        {
            return $"Commande n°{numeroCommande}:\n" +
                   $"- Client: {client.Nom} {client.Prenom}\n" +
                   $"- Chauffeur: {chauffeur.Nom} {chauffeur.Prenom}\n" +
                   $"- Véhicule: {vehicule.Marque} {vehicule.Modele} ({vehicule.Immatriculation})\n" +
                   $"- Trajet: {villeDepart} à {villeArrivee}\n" +
                   $"- Date: {date.ToShortDateString()}\n" +
                   $"- Prix: {prix} + euros\n" +
                   $"- Temps estimé: {temps:F2} heures\n" +
                   $"- Commentaire: {vehicule.Commentaire}";
        }
    }
}
