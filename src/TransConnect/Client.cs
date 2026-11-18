using System;
using System.Collections.Generic;

namespace TransConnect
{
    public class Client : Personne
    {
        private List<Commande> commandes;//liste des commandes des clients

        public Client(string nss, string nom, string prenom, DateTime dateNaissance, string adresse, string ville, string email, string telephone)
            : base(nss, nom, prenom, dateNaissance, adresse, ville, email, telephone)
        {
            commandes = new List<Commande>();
        }

        public List<Commande> Commandes
        {
            get { return commandes; }
            set { commandes = value; }
        }

        public override string Details()
        {
            return $"{nom} {prenom}, {adresse}, {ville}, {email}, {telephone}, Nombre de commandes: {commandes.Count}";
        }
    }
}
