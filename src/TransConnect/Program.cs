using System;

namespace TransConnect
{
    class Program
    {
        static GestionClients gestionClients = new GestionClients();
        static Organigramme organigramme = new Organigramme();
        static List<Commande> commandes = new List<Commande>();
        static Graph graph = new Graph();
        static Statistiques statistiques;
        static GestionReviews gestionReviews = new GestionReviews();

        static void Main(string[] args)
        {
            statistiques = new Statistiques(commandes, gestionClients.Clients);
            InitialiserOrganigramme();
            InitialiserClients();
            InitialiserTrajets();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== TransConnect ===");
                Console.WriteLine("1. Gestion des Clients");
                Console.WriteLine("2. Gestion des Salariés");
                Console.WriteLine("3. Gestion des Commandes");
                Console.WriteLine("4. Gestion des Trajets");
                Console.WriteLine("5. Statistiques");
                Console.WriteLine("6. Reviews");
                Console.WriteLine("0. Quitter");
                Console.Write("Choisissez un module: ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        MenuClients();
                        break;
                    case "2":
                        MenuSalaries();
                        break;
                    case "3":
                        MenuCommandes();
                        break;
                    case "4":
                        MenuTrajets();
                        break;
                    case "5":
                        MenuStatistiques();
                        break;
                    case "6":
                        MenuReviews();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Choix invalide , appuyez sur une touche pour continuer");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void InitialiserClients()
        {
            gestionClients.AjouterClient(new Client("1", "Dupont", "Jean", new DateTime(1985, 5, 23), "12 rue de la paix", "Paris", "jean.dupont@example.com", "0601234567"));
            gestionClients.AjouterClient(new Client("2", "Martin", "Sophie", new DateTime(1990, 8, 17), "34 avenue des champs", "Lyon", "sophie.martin@example.com", "0609876543"));
            gestionClients.AjouterClient(new Client("3", "Bernard", "Paul", new DateTime(1975, 12, 3), "56 boulevard de marseille", "Marseille", "paul.bernard@example.com", "0604567891"));
            gestionClients.AjouterClient(new Client("4", "Durand", "Alice", new DateTime(2000, 4, 10), "78 rue des Fleurs", "Bordeaux", "alice.durand@example.com", "0606543219"));
        }

        static void InitialiserOrganigramme()
        {
            var directeurGeneral = new Salarie("01", "Dupond", "Pierre", new DateTime(1960, 1, 1), "1 avenue de la république", "Paris", "pierre.dupont@transconnect.com", "0101010101", new DateTime(2000, 1, 1), "Directeur général", 5000);
            var directriceCommerciale = new Salarie("02", "Fiesta", "Marie", new DateTime(1970, 1, 1), "2 rue de la paix", "Paris", "marie.fiesta@transconnect.com", "0202020202", new DateTime(2010, 1, 1), "Directrice commerciale", 4000);
            var directeurOperations = new Salarie("03", "Fetard", "Jacques", new DateTime(1972, 1, 1), "3 rue des lilas", "Lyon", "jacques.fetard@transconnect.com", "0303030303", new DateTime(2012, 1, 1), "Directeur des opérations", 4000);
            var directriceRH = new Salarie("04", "Joyeuse", "Sophie", new DateTime(1975, 1, 1), "4 rue des roses", "Marseille", "sophie.joyeuse@transconnect.com", "0404040404", new DateTime(2015, 1, 1), "Directrice des rh", 4000);
            var directeurFinancier = new Salarie("05", "GripSous", "Paul", new DateTime(1980, 1, 1), "5 rue des violettes", "Bordeaux", "paul.gripsous@transconnect.com", "0505050505", new DateTime(2018, 1, 1), "Directeur financier", 4000);

            organigramme.EmbaucherSalarie(directeurGeneral);
            organigramme.EmbaucherSalarie(directriceCommerciale, organigramme.DirecteurGeneral);
            organigramme.EmbaucherSalarie(directeurOperations, organigramme.DirecteurGeneral);
            organigramme.EmbaucherSalarie(directriceRH, organigramme.DirecteurGeneral);
            organigramme.EmbaucherSalarie(directeurFinancier, organigramme.DirecteurGeneral);

            var forge = new Salarie("06", "Forge", "Alain", new DateTime(1982, 1, 1), "6 rue de la forge", "Paris", "alain.forge@transconnect.com", "0606060606", new DateTime(2019, 1, 1), "Commercial", 3000);
            var fermi = new Salarie("07", "Fermi", "Lucie", new DateTime(1985, 1, 1), "7 rue des fermiers", "Paris", "lucie.fermi@transconnect.com", "0707070707", new DateTime(2020, 1, 1), "Commerciale", 3000);
            organigramme.EmbaucherSalarie(forge, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "02"));
            organigramme.EmbaucherSalarie(fermi, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "02"));

            var royal = new Salarie("08", "Royal", "Henri", new DateTime(1983, 1, 1), "8 rue des rois", "Lyon", "henri.royal@transconnect.com", "0808080808", new DateTime(2017, 1, 1), "Chef Equipe", 3500);
            var prince = new Salarie("09", "Prince", "Charles", new DateTime(1984, 1, 1), "9 rue des princes", "Lyon", "charles.prince@transconnect.com", "0909090909", new DateTime(2016, 1, 1), "Chef d'Equipe", 3500);
            organigramme.EmbaucherSalarie(royal, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "03"));
            organigramme.EmbaucherSalarie(prince, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "03"));

            var romu = new Salarie("010", "Romu", "René", new DateTime(1986, 1, 1), "10 rue des chauffeurs", "Lyon", "rene.romu@transconnect.com", "1010101010", new DateTime(2018, 1, 1), "Chauffeur", 2500);
            var romi = new Salarie("011", "Romi", "Marie", new DateTime(1987, 1, 1), "11 Rue des chauffeurs", "Lyon", "marie.romi@transconnect.com", "1111111111", new DateTime(2019, 1, 1), "Chauffeur", 2500);
            var roma = new Salarie("012", "Roma", "Pierre", new DateTime(1988, 1, 1), "12 rue des chauffeurs", "Lyon", "pierre.roma@transconnect.com", "1212121212", new DateTime(2020, 1, 1), "Chauffeur", 2500);
            organigramme.EmbaucherSalarie(romu, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "08"));
            organigramme.EmbaucherSalarie(romi, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "08"));
            organigramme.EmbaucherSalarie(roma, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "08"));

            var rome = new Salarie("013", "Rome", "Paul", new DateTime(1989, 1, 1), "13 rue des chauffeurs", "Lyon", "paul.rome@transconnect.com", "1313131313", new DateTime(2017, 1, 1), "Chauffeur", 2500);
            var rimou = new Salarie("014", "Rimou", "Claire", new DateTime(1990, 1, 1), "14 rue des chauffeurs", "Lyon", "claire.rimou@transconnect.com", "1414141414", new DateTime(2016, 1, 1), "Chauffeur", 2500);
            organigramme.EmbaucherSalarie(rome, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "09"));
            organigramme.EmbaucherSalarie(rimou, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "09"));

            var couleur = new Salarie("015", "Couleur", "Anne", new DateTime(1991, 1, 1), "15 rue des rh", "Marseille", "anne.couleur@transconnect.com", "1515151515", new DateTime(2019, 1, 1), "Formation", 3000);
            var toutlemonde = new Salarie("016", "Toutlemonde", "Emilie", new DateTime(1992, 1, 1), "16 rue des RH", "Marseille", "emilie.toutlemonde@transconnect.com", "1616161616", new DateTime(2020, 1, 1), "Contrats", 3000);
            organigramme.EmbaucherSalarie(couleur, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "04"));
            organigramme.EmbaucherSalarie(toutlemonde, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "04"));

            var picsou = new Salarie("017", "Picsou", "Donald", new DateTime(1981, 1, 1), "17 rue des comptes", "Bordeaux", "donald.picsou@transconnect.com", "1717171717", new DateTime(2015, 1, 1), "Direction comptable", 3500);
            var grossous = new Salarie("018", "GrosSous", "Mamie", new DateTime(1983, 1, 1), "18 rue des comptes", "Bordeaux", "mamie.grossous@transconnect.com", "1818181818", new DateTime(2017, 1, 1), "Contrôle de Gestion", 3500);
            organigramme.EmbaucherSalarie(picsou, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "05"));
            organigramme.EmbaucherSalarie(grossous, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "05"));

            var fournier = new Salarie("019", "Fournier", "Lucie", new DateTime(1994, 1, 1), "19 rue des comptes", "Bordeaux", "lucie.fournier@transconnect.com", "1919191919", new DateTime(2018, 1, 1), "Comptable", 3000);
            var gautier = new Salarie("020", "Gautier", "Marie", new DateTime(1995, 1, 1), "20 rue des comptes", "Bordeaux", "marie.gautier@transconnect.com", "2020202020", new DateTime(2019, 1, 1), "Comptable", 3000);
            organigramme.EmbaucherSalarie(fournier, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "017"));
            organigramme.EmbaucherSalarie(gautier, organigramme.TrouverSalarie(organigramme.DirecteurGeneral, "017"));
        }

        static void InitialiserTrajets()
        {
            graph.AjouterSommet("paris");
            graph.AjouterSommet("lyon");
            graph.AjouterArete("paris", "lyon", 465);
            graph.AjouterSommet("marseille");
            graph.AjouterArete("lyon", "marseille", 315);
            graph.AjouterSommet("bordeaux");
            graph.AjouterArete("paris", "bordeaux", 584);
        }

        #region Module Client 


        static void MenuClients()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gestion des Clients ===");
                Console.WriteLine("1. Ajouter un Client");
                Console.WriteLine("2. Enlever un Client");
                Console.WriteLine("3. Modifier les informations d'un Client");
                Console.WriteLine("4. Afficher tous les Clients");
                Console.WriteLine("5. Afficher les Clients par Nom(A-Z)");
                Console.WriteLine("6. Afficher les Clients par Ville(A-Z)");
                Console.WriteLine("7. Afficher les Clients par Montant des Achats");
                Console.WriteLine("0. Retour au Menu Principal");
                Console.Write("Choisissez une action: ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterClient();
                        break;
                    case "2":
                        SupprimerClient();
                        break;
                    case "3":
                        ModifierClient();
                        break;
                    case "4":
                        AfficherTousLesClients();
                        break;
                    case "5":
                        AfficherClientsParNom();
                        break;
                    case "6":
                        AfficherClientsParVille();
                        break;
                    case "7":
                        AfficherClientsParMontantAchats();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Appuyer sur une touche svp");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AjouterClient()
        {
            Console.Clear();
            Console.WriteLine("Ajouter un Client");
            Console.Write("NSS: ");
            string nss = Console.ReadLine();
            Console.Write("Nom: ");
            string nom = Console.ReadLine();
            Console.Write("Prenom: ");
            string prenom = Console.ReadLine();
            Console.Write("Date de Naissance (JJ/MM/AAAA): ");
            DateTime dateNaissance = DateTime.Parse(Console.ReadLine());
            Console.Write("Adresse: ");
            string adresse = Console.ReadLine();
            Console.Write("Ville: ");
            string ville = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Téléphone: ");
            string telephone = Console.ReadLine();

            Client client = new Client(nss, nom, prenom, dateNaissance, adresse, ville, email, telephone);
            gestionClients.AjouterClient(client);

            Console.WriteLine("Client inscrit !");
            Console.ReadKey();
        }

        static void SupprimerClient()
        {
            Console.Clear();
            Console.WriteLine("Supprimer un client");
            Console.Write("NSS: ");
            string nss = Console.ReadLine();

            gestionClients.SupprimerClient(nss);

            Console.WriteLine("Client supprimé !");
            Console.ReadKey();
        }

        static void ModifierClient()
        {
            Console.Clear();
            Console.WriteLine("Modifier un client");
            Console.Write("NSS: ");
            string nss = Console.ReadLine();

            Client client = gestionClients.Clients.Find(c => c.NSS == nss);
            if (client != null)
            {
                Console.Write("Nom ({0}): ", client.Nom);
                string nom = Console.ReadLine();
                if (!string.IsNullOrEmpty(nom)) client.Nom = nom;

                Console.Write("Prenom ({0}): ", client.Prenom);
                string prenom = Console.ReadLine();
                if (!string.IsNullOrEmpty(prenom)) client.Prenom = prenom;

                Console.Write("Date de Naissance ({0}) (JJ/MM/AAAA): ", client.DateNaissance.ToShortDateString());
                string dateNaissanceStr = Console.ReadLine();
                if (DateTime.TryParse(dateNaissanceStr, out DateTime dateNaissance)) client.DateNaissance = dateNaissance;

                Console.Write("Adresse ({0}): ", client.Adresse);
                string adresse = Console.ReadLine();
                if (!string.IsNullOrEmpty(adresse)) client.Adresse = adresse;

                Console.Write("Ville ({0}): ", client.Ville);
                string ville = Console.ReadLine();
                if (!string.IsNullOrEmpty(ville)) client.Ville = ville;

                Console.Write("Email ({0}): ", client.Email);
                string email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) client.Email = email;

                Console.Write("Téléphone ({0}): ", client.Telephone);
                string telephone = Console.ReadLine();
                if (!string.IsNullOrEmpty(telephone)) client.Telephone = telephone;

                gestionClients.ModifierClient(client);

                Console.WriteLine("Client modifié !");
            }
            else
            {
                Console.WriteLine("Client inexistant");
            }
            Console.ReadKey();
        }

        static void AfficherTousLesClients()
        {
            Console.Clear();
            Console.WriteLine("Liste de tous les clients:");
            foreach (var client in gestionClients.Clients)
            {
                Console.WriteLine(client);
            }
            Console.ReadKey();
        }

        static void AfficherClientsParNom()
        {
            Console.Clear();
            Console.WriteLine("Liste de tous les clients par nom:");
            foreach (var client in gestionClients.AfficherClientsParNom())
            {
                Console.WriteLine(client);
            }
            Console.ReadKey();
        }

        static void AfficherClientsParVille()
        {
            Console.Clear();
            Console.WriteLine("Liste de tous les clients par ville:");
            foreach (var client in gestionClients.AfficherClientsParVille())
            {
                Console.WriteLine(client);
            }
            Console.ReadKey();
        }

        static void AfficherClientsParMontantAchats()
        {
            Console.Clear();
            Console.WriteLine("Liste de tous les clients par montant des achats:");
            foreach (var client in gestionClients.AfficherClientsParMontantAchats())
            {
                Console.WriteLine(client);
            }
            Console.ReadKey();
        }

        #endregion 

        #region Module Salarié

        static void MenuSalaries()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gestion des Salariés ===");
                Console.WriteLine("1. Embaucher un Salarié");
                Console.WriteLine("2. Licencier un Salarié");
                Console.WriteLine("3. Afficher l'Organigramme");
                Console.WriteLine("0. Retour au Menu Principal");
                Console.Write("Choisissez une action: ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        EmbaucherSalarie();
                        break;
                    case "2":
                        LicencierSalarie();
                        break;
                    case "3":
                        AfficherOrganigramme();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Choix invalide. Appuyez sur une touche pour réessayer");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void EmbaucherSalarie()
        {
            Console.Clear();
            Console.WriteLine("Embaucher un Salarié");
            Console.Write("NSS: ");
            string nss = Console.ReadLine();
            Console.Write("Nom: ");
            string nom = Console.ReadLine();
            Console.Write("Prenom: ");
            string prenom = Console.ReadLine();
            Console.Write("Date de Naissance (JJ/MM/AAAA): ");
            DateTime dateNaissance = DateTime.Parse(Console.ReadLine());
            Console.Write("Adresse: ");
            string adresse = Console.ReadLine();
            Console.Write("Ville: ");
            string ville = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Téléphone: ");
            string telephone = Console.ReadLine();
            Console.Write("Date d'Entrée (JJ/MM/AAAA): ");
            DateTime dateEntree = DateTime.Parse(Console.ReadLine());
            Console.Write("Poste: ");
            string poste = Console.ReadLine();
            Console.Write("Salaire: ");
            double salaire = double.Parse(Console.ReadLine());

            Salarie salarie = new Salarie(nss, nom, prenom, dateNaissance, adresse, ville, email, telephone, dateEntree, poste, salaire);

            Console.Write("NSS du Supérieur (laisser vide si c'est le directeur général): ");
            string nssSuperieur = Console.ReadLine();

            Noeud<Salarie> superieur = null;
            if (!string.IsNullOrEmpty(nssSuperieur))
            {
                superieur = organigramme.TrouverSalarie(organigramme.DirecteurGeneral, nssSuperieur);
                if (superieur == null)
                {
                    Console.WriteLine("Supérieur non trouvé, le salarié sera donc ajouté en tant que directeur général.");
                }
            }

            organigramme.EmbaucherSalarie(salarie, superieur);

            Console.WriteLine("Salarié embauché avec succès!");
            Console.ReadKey();
        }


        static void LicencierSalarie()
        {
            Console.Clear();
            Console.WriteLine("Licencier un Salarié");
            Console.Write("NSS: ");
            string nss = Console.ReadLine();

            organigramme.LicencierSalarie(organigramme.DirecteurGeneral, nss);

            Console.WriteLine("Salarié licencié avec succès!");
            Console.ReadKey();
        }

        static void AfficherOrganigramme()
        {
            Console.Clear();
            Console.WriteLine("Organigramme de l'Entreprise:");
            organigramme.AfficherOrganigramme();
            Console.ReadKey();
        }

        #endregion

        #region Module Commandes

        static void MenuCommandes()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gestion des Commandes ===");
                Console.WriteLine("1. Créer une Commande");
                Console.WriteLine("2. Modifier une Commande");
                Console.WriteLine("3. Afficher toutes les Commandes");
                Console.WriteLine("0. Retour au Menu Principal");
                Console.Write("Choisissez une action: ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        CreerCommande();
                        break;
                    case "2":
                        ModifierCommande();
                        break;
                    case "3":
                        AfficherToutesLesCommandes();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Choix invalide. Appuyez sur une touche pour réessayer.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void CreerCommande()
        {
            Console.Clear();
            Console.WriteLine("Créer une Commande");

            // générer un numéro de commande unique
            string numeroCommande = (commandes.Count + 1).ToString("D6");
            Console.WriteLine($"Numéro de Commande: {numeroCommande}");

            Console.Write("NSS du Client: ");
            string nssClient = Console.ReadLine();
            Client client = gestionClients.Clients.Find(c => c.NSS == nssClient);
            if (client == null)
            {
                Console.WriteLine("Client non trouvé.");
                Console.ReadKey();
                return;
            }

            Console.Write("NSS du Chauffeur: ");
            string nssChauffeur = Console.ReadLine();
            Noeud<Salarie> chauffeurNode = organigramme.TrouverSalarie(organigramme.DirecteurGeneral, nssChauffeur);
            if (chauffeurNode == null)
            {
                Console.WriteLine("Chauffeur non trouvé.");
                Console.ReadKey();
                return;
            }
            Salarie chauffeur = chauffeurNode.Donnee;

            Console.Write("Immatriculation du Véhicule: ");
            string immatriculation = Console.ReadLine();
            Console.Write("Marque du Véhicule: ");
            string marque = Console.ReadLine();
            Console.Write("Modèle du Véhicule: ");
            string modele = Console.ReadLine();
            Console.Write("Commentaire (usage spécifique du véhicule): ");
            string commentaire = Console.ReadLine();

            IVehicule vehicule = new Vehicule(immatriculation, marque, modele, 2022, 0.5, commentaire);

            Console.Write("Ville de Départ: ");
            string villeDepart = Console.ReadLine();
            Console.Write("Ville d'Arrivée: ");
            string villeArrivee = Console.ReadLine();
            Console.Write("Date (JJ/MM/AAAA): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            if (!graph.ExisteTrajet(villeDepart, villeArrivee))
            {
                Console.WriteLine("Le trajet spécifié n'existe pas. Veuillez ajouter le trajet d'abord.");
                Console.ReadKey();
                return;
            }

            Commande commande = new Commande(numeroCommande, client, chauffeur, vehicule, villeDepart, villeArrivee, date, graph);
            commandes.Add(commande);

            Console.WriteLine("Commande créée avec succès!");
            Console.ReadKey();
        }

        static void ModifierCommande()
        {
            Console.Clear();
            Console.WriteLine("Modifier une Commande");
            Console.Write("Numéro de Commande: ");
            string numeroCommande = Console.ReadLine();

            Commande commande = commandes.Find(c => c.NumeroCommande == numeroCommande);
            if (commande != null)
            {
                Console.Write("NSS du Client ({0}): ", commande.Client.NSS);
                string nssClient = Console.ReadLine();
                if (!string.IsNullOrEmpty(nssClient))
                {
                    Client client = gestionClients.Clients.Find(c => c.NSS == nssClient);
                    if (client != null) commande.Client = client;
                }

                Console.Write("NSS du Chauffeur ({0}): ", commande.Chauffeur.NSS);
                string nssChauffeur = Console.ReadLine();
                if (!string.IsNullOrEmpty(nssChauffeur))
                {
                    Noeud<Salarie> chauffeurNode = organigramme.TrouverSalarie(organigramme.DirecteurGeneral, nssChauffeur);
                    if (chauffeurNode != null) commande.Chauffeur = chauffeurNode.Donnee;
                }

                Console.Write("Immatriculation du Véhicule ({0}): ", commande.Vehicule.Immatriculation);
                string immatriculation = Console.ReadLine();
                if (!string.IsNullOrEmpty(immatriculation))
                {
                    Console.Write("Marque du Véhicule: ");
                    string marque = Console.ReadLine();
                    Console.Write("Modèle du Véhicule: ");
                    string modele = Console.ReadLine();
                    Console.Write("Commentaire (usage spécifique du véhicule): ");
                    string commentaire = Console.ReadLine();
                    commande.Vehicule = new Vehicule(immatriculation, marque, modele, 2022, 0.5, commentaire);
                }

                Console.Write("Ville de Départ ({0}): ", commande.VilleDepart);
                string villeDepart = Console.ReadLine();
                if (!string.IsNullOrEmpty(villeDepart)) commande.VilleDepart = villeDepart;

                Console.Write("Ville d'Arrivée ({0}): ", commande.VilleArrivee);
                string villeArrivee = Console.ReadLine();
                if (!string.IsNullOrEmpty(villeArrivee)) commande.VilleArrivee = villeArrivee;

                Console.Write("Date ({0}) (JJ/MM/AAAA): ", commande.Date.ToShortDateString());
                string dateStr = Console.ReadLine();
                if (DateTime.TryParse(dateStr, out DateTime date)) commande.Date = date;

                commande.CalculerPrixEtTemps(graph);

                Console.WriteLine("Commande modifiée avec succès!");
            }
            else
            {
                Console.WriteLine("Commande non trouvée.");
            }
            Console.ReadKey();
        }

        static void AfficherToutesLesCommandes()
        {
            Console.Clear();
            Console.WriteLine("Liste de toutes les Commandes:");
            foreach (var commande in commandes)
            {
                Console.WriteLine(commande);
            }
            Console.ReadKey();
        }

        #endregion

        #region Module Statistiques

        static void MenuStatistiques()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Statistiques ===");
                Console.WriteLine("1. Afficher le nombre de livraisons par chauffeur");
                Console.WriteLine("2. Afficher les commandes par période");
                Console.WriteLine("3. Afficher la moyenne des prix des commandes");
                Console.WriteLine("4. Afficher la moyenne des comptes clients");
                Console.WriteLine("5. Afficher les commandes par client");
                Console.WriteLine("0. Retour au Menu Principal");
                Console.Write("Choisissez une action: ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        statistiques.AfficherLivraisonsParChauffeur();
                        break;
                    case "2":
                        AfficherCommandesParPeriode();
                        break;
                    case "3":
                        statistiques.AfficherMoyennePrixCommandes();
                        break;
                    case "4":
                        statistiques.AfficherMoyenneComptesClients();
                        break;
                    case "5":
                        AfficherCommandesParClient();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Choix invalide. Appuyez sur une touche pour réessayer.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AfficherCommandesParPeriode()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Commandes par Période:");
                Console.Write("Date de début (JJ/MM/AAAA): ");
                DateTime dateDebut;
                if (!DateTime.TryParse(Console.ReadLine(), out dateDebut))
                {
                    Console.WriteLine("Format de date invalide. Veuillez réessayer.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Date de fin (JJ/MM/AAAA): ");
                DateTime dateFin;
                if (!DateTime.TryParse(Console.ReadLine(), out dateFin))
                {
                    Console.WriteLine("Format de date invalide. Veuillez réessayer.");
                    Console.ReadKey();
                    return;
                }

                statistiques.AfficherCommandesParPeriode(dateDebut, dateFin);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur est survenue: {ex.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        static void AfficherCommandesParClient()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Commandes par Client:");
                Console.Write("NSS du Client: ");
                string nssClient = Console.ReadLine();

                statistiques.AfficherCommandesParClient(nssClient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur est survenue: {ex.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        #endregion

        #region Module Reviews

        static void MenuReviews()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Reviews ===");
                Console.WriteLine("1. Ajouter une Review");
                Console.WriteLine("2. Afficher les Reviews par Chauffeur");
                Console.WriteLine("3. Afficher la Moyenne des Notes par Chauffeur");
                Console.WriteLine("0. Retour au Menu Principal");
                Console.Write("Choisissez une action: ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterReview();
                        break;
                    case "2":
                        AfficherReviewsParChauffeur();
                        break;
                    case "3":
                        AfficherMoyenneNotesParChauffeur();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Choix invalide. Appuyez sur une touche pour réessayer.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AjouterReview()
        {
            Console.Clear();
            Console.WriteLine("Ajouter une Review");
            Console.Write("NSS du Chauffeur: ");
            string nssChauffeur = Console.ReadLine();
            Console.Write("Date (JJ/MM/AAAA): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Note (1 à 5): ");
            int note = int.Parse(Console.ReadLine());
            Console.Write("Commentaire: ");
            string commentaire = Console.ReadLine();

            Review review = new Review(nssChauffeur, date, note, commentaire);
            gestionReviews.AjouterReview(review);

            Console.WriteLine("Review ajoutée avec succès!");
            Console.ReadKey();
        }

        static void AfficherReviewsParChauffeur()
        {
            Console.Clear();
            Console.WriteLine("Afficher les Reviews par Chauffeur");
            Console.Write("NSS du Chauffeur: ");
            string nssChauffeur = Console.ReadLine();

            var reviews = gestionReviews.ObtenirReviews(nssChauffeur);
            if (reviews.Count > 0)
            {
                foreach (var review in reviews)
                {
                    Console.WriteLine(review);
                }
            }
            else
            {
                Console.WriteLine("Aucune review trouvée pour ce chauffeur.");
            }
            Console.ReadKey();
        }

        static void AfficherMoyenneNotesParChauffeur()
        {
            Console.Clear();
            Console.WriteLine("Afficher la Moyenne des Notes par chauffeur");
            Console.Write("NSS du Chauffeur: ");
            string nssChauffeur = Console.ReadLine();

            double moyenne = gestionReviews.ObtenirMoyenneNotes(nssChauffeur);
            if (moyenne > 0)
            {
                Console.WriteLine($"Moyenne des notes pour le chauffeur {nssChauffeur}: {moyenne}/5");
            }
            else
            {
                Console.WriteLine("Aucune note trouvée pour ce chauffeur.");
            }
            Console.ReadKey();
        }

        #endregion

        #region Module Trajets

        static void MenuTrajets()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gestion des Trajets ===");
                Console.WriteLine("1. Ajouter un Trajet");
                Console.WriteLine("2. Afficher les Trajets");
                Console.WriteLine("0. Retour au Menu Principal");
                Console.Write("Choisissez une action: ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterTrajet();
                        break;
                    case "2":
                        AfficherTrajets();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Choix invalide. Appuyez sur une touche pour réessayer.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AjouterTrajet()
        {
            Console.Clear();
            Console.WriteLine("Ajouter un Trajet");
            Console.Write("Ville de Départ: ");
            string villeDepart = Console.ReadLine();
            graph.AjouterSommet(villeDepart);
            Console.Write("Ville d'Arrivée: ");
            string villeArrivee = Console.ReadLine();
            graph.AjouterSommet(villeArrivee);
            Console.Write("Distance entre les villes (km): ");
            double distance = double.Parse(Console.ReadLine());
            graph.AjouterArete(villeDepart, villeArrivee, distance);

            Console.WriteLine("Trajet ajouté avec succès!");
            Console.ReadKey();
        }

        static void AfficherTrajets()
        {
            Console.Clear();
            Console.WriteLine("Liste de tous les Trajets:");
            foreach (var sommet in graph.GetSommets())
            {
                foreach (var voisin in graph.GetVoisins(sommet))
                {
                    Console.WriteLine($"{sommet} à {voisin.Key} - {voisin.Value} km");
                }
            }
            Console.ReadKey();
        }

        #endregion
    }
}