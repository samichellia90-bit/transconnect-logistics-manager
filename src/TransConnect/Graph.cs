namespace TransConnect;

public class Graph
{
    private Dictionary<string, Dictionary<string, double>> adjList = new Dictionary<string, Dictionary<string, double>>();    // dictionnaire pour stocker les sommets et leurs voisins avec les distances


    public void AjouterSommet(string sommet)
    {
        // ajoute le sommet seulement s'il n'existe pas déjà
        if (!adjList.ContainsKey(sommet))
        {
            adjList[sommet] = new Dictionary<string, double>();
        }
    }

    public void AjouterArete(string source, string destination, double poids)
    {
        // ajoute l'arête seulement si les deux sommets existent
        if (adjList.ContainsKey(source) && adjList.ContainsKey(destination))
        {
            adjList[source][destination] = poids;
            adjList[destination][source] = poids; // le graphe est non orienté
        }
    }

    // algor de dijkstra 
    public Dictionary<string, double> Dijkstra(string source)
    {
        Dictionary<string, double> distances = new Dictionary<string, double>(); // stocke les distances les plus courtes
        SortedSet<(double distance, string sommet)> priorite = new SortedSet<(double distance, string sommet)>(); // ensemble ordonné pour gérer les sommets à traiter
        Dictionary<string, string> predecesseurs = new Dictionary<string, string>(); // stocke les prédecesseurs des sommets

        // initialise les distances
        foreach (var sommet in adjList.Keys)
        {
            if (sommet == source)
            {
                distances[sommet] = 0; // la distance de la source à elle meme est 0
            }
            else
            {
                distances[sommet] = double.MaxValue; // initialement les distances aux autres sommets sont infinies
            }
            priorite.Add((distances[sommet], sommet)); // ajoute les sommets à l'ensemble prioritaire
        }

        // parcours des sommets
        while (priorite.Count > 0)
        {
            var (dist, sommet) = priorite.Min; // prend le sommet avec la plus petite distance
            priorite.Remove(priorite.Min); // le retire de l'ensemble prioritaire

            // met à jour les distances pour les voisins du sommet actuel
            foreach (var voisin in adjList[sommet])
            {
                double nouvelleDistance = dist + voisin.Value; // calcule la nouvelle distance
                if (nouvelleDistance < distances[voisin.Key])
                {
                    priorite.Remove((distances[voisin.Key], voisin.Key)); // retire l'ancienne distance de l'ensemble
                    distances[voisin.Key] = nouvelleDistance; // met à jour la distance
                    priorite.Add((nouvelleDistance, voisin.Key)); // ajoute la nouvelle distance à l'ensemble
                    predecesseurs[voisin.Key] = sommet; // met à jour le prédecesseur
                }
            }
        }

        return distances; 
    }

    
    public double CalculerDistance(string source, string destination)
    {
        Dictionary<string, double> distances = Dijkstra(source); // exécute dijkstra depuis le sommet source

        // retourne la distance jusqu'au sommet de destination, ou l'infini si elle n'est pas atteignable
        if (distances.ContainsKey(destination))
        {
            return distances[destination];
        }
        else
        {
            return double.MaxValue; // indique que la destination n'est pas atteignable
        }
    }

   
    public IEnumerable<string> GetSommets() //interface avec GetEnumerator()
    {
        return adjList.Keys;
    }

   
    public Dictionary<string, double> GetVoisins(string sommet)
    {
        return adjList[sommet];
    }

    
    public bool ExisteTrajet(string source, string destination)
    {
        return adjList.ContainsKey(source) && adjList[source].ContainsKey(destination);
    }
}
