using System;
using System.Collections.Generic;
using System.Linq;

namespace TransConnect
{
    public class GestionClients
    {
        public List<Client> Clients { get; set; }

        public GestionClients()
        {
            Clients = new List<Client>();
        }

        public void AjouterClient(Client client)
        {
            Clients.Add(client);
        }

        public void SupprimerClient(string nss)
        {
            Clients.RemoveAll(c => c.NSS == nss);
        }

        public void ModifierClient(Client client)
        {
            var index = Clients.FindIndex(c => c.NSS == client.NSS);
            if (index >= 0)
            {
                Clients[index] = client;
            }
        }

        public List<Client> AfficherClientsParNom()
        {
            return Clients.OrderBy(c => c.Nom).ToList();
        }

        public List<Client> AfficherClientsParVille()
        {
            return Clients.OrderBy(c => c.Ville).ToList();
        }

        public List<Client> AfficherClientsParMontantAchats()
        {
            return Clients.OrderByDescending(c => c.Commandes.Sum(cmd => cmd.Prix)).ToList();
        }
    }
}
