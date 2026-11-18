using System;

namespace TransConnect
{
    public class Vehicule : IVehicule
    {
        private string immatriculation;
        private string marque;
        private string modele;
        private int annee;
        private double tarifKilometre;
        private string commentaire; 

        public Vehicule(string immatriculation, string marque, string modele, int annee, double tarifKilometre, string commentaire)
        {
            this.immatriculation = immatriculation;
            this.marque = marque;
            this.modele = modele;
            this.annee = annee;
            this.commentaire = commentaire ?? "Pas de commentaire";
        }

        public string Immatriculation
        {
            get { return immatriculation; }
            set { immatriculation = value; }
        }

        public string Marque
        {
            get { return marque; }
            set { marque = value; }
        }

        public string Modele
        {
            get { return modele; }
            set { modele = value; }
        }

        public int Annee
        {
            get { return annee; }
            set { annee = value; }
        }
        public string Commentaire
        {
            get { return commentaire; }
            set { commentaire = value ?? "Pas de commentaire"; }
        }

        public override string ToString()
        {
            return $"{marque} {modele} ({annee}), Immatriculation: {immatriculation}, Tarif par km: {tarifKilometre}€, Commentaire: {commentaire}";
        }
    }
}
