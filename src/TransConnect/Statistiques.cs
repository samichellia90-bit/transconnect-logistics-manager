using System;
using System.Collections.Generic;
using System.Linq;

namespace TransConnect
{
    public class Statistiques
    {
        private List<Commande> commandes;
        private List<Client> clients;

        public Statistiques(List<Commande> commandes, List<Client> clients)
        {
            this.commandes = commandes;
            this.clients = clients;
        }

        public void AfficherLivraisonsParChauffeur()
        {
            var livraisonsParChauffeur = commandes.GroupBy(c => c.Chauffeur)
                                                  .Select(g => new { Chauffeur = g.Key, Count = g.Count() });

            foreach (var item in livraisonsParChauffeur)
            {
                Console.WriteLine($"{item.Chauffeur.Nom} {item.Chauffeur.Prenom} a effectué {item.Count} livraisons.");
            }
        }

        public void AfficherCommandesParPeriode(DateTime dateDebut, DateTime dateFin)
        {
            var commandesParPeriode = commandes.Where(c => c.Date >= dateDebut && c.Date <= dateFin).ToList();

            foreach (var commande in commandesParPeriode)
            {
                Console.WriteLine(commande);
            }
        }

        public void AfficherMoyennePrixCommandes()
        {
            if (commandes.Count > 0)
            {
                double moyennePrix = commandes.Average(c => c.Prix);
                Console.WriteLine($"Moyenne des prix des commandes: {moyennePrix}€");
            }
            else
            {
                Console.WriteLine("Aucune commande disponible pour calculer la moyenne.");
            }
        }

        public void AfficherMoyenneComptesClients()
        {
            if (clients.Count > 0)
            {
                double moyenneComptes = clients.Average(c => c.Commandes.Sum(cmd => cmd.Prix));
                Console.WriteLine($"Moyenne des comptes clients: {moyenneComptes}€");
            }
            else
            {
                Console.WriteLine("Aucun client disponible pour calculer la moyenne.");
            }
        }

        public void AfficherCommandesParClient(string nssClient)
        {
            var client = clients.Find(c => c.NSS == nssClient);
            if (client != null)
            {
                if (client.Commandes.Count > 0)
                {
                    foreach (var commande in client.Commandes)
                    {
                        Console.WriteLine(commande);
                    }
                }
                else
                {
                    Console.WriteLine("Aucune commande trouvée pour ce client.");
                }
            }
            else
            {
                Console.WriteLine("Client non trouvé.");
            }
        }
    }
}
