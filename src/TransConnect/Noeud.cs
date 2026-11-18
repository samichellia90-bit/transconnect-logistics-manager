using System;
using System.Collections.Generic;

namespace TransConnect
{
    
    public class Noeud<T>//classe qui represente le noeud dans mon arbre 
    {

        public T Donnee;

        
        public List<Noeud<T>> Enfants;// Liste des enfants du nœud

        
        public Noeud(T donnee)//init des noeuds
        {
            Donnee = donnee;
            Enfants = new List<Noeud<T>>(); 
        }

        
        public void AjouterEnfant(Noeud<T> enfant)
        {
            Enfants.Add(enfant);
        }

        
        public List<T> FindAll(Predicate<T> critere)
        {
            List<T> resultats = new List<T>(); // Liste pour stocker les résultats
            Queue<Noeud<T>> file = new Queue<Noeud<T>>(); // File pour parcourir l'arbre
            file.Enqueue(this); // Ajoute le nœud actuel à la file

            while (file.Count > 0) // Parcourt l'arbre jusqu'à la fin
            {
                var courant = file.Dequeue(); // Retire un nœud de la file
                if (critere(courant.Donnee)) // Vérifie si les données répondent au critère
                {
                    resultats.Add(courant.Donnee); // Ajoute les données à la liste des résultats
                }

                foreach (var enfant in courant.Enfants) // Ajoute les enfants du nœud à la file
                {
                    file.Enqueue(enfant);
                }
            }
            return resultats;
        }

        
        public void Sort(Comparison<T> comparaison) //trier les éléments de l'arbre en utilisant une comparaison
        {
            List<T> listeNoeuds = new List<T>(); // liste pour stocker les données des nœuds
            Queue<Noeud<T>> file = new Queue<Noeud<T>>(); // file pour parcourir l'arbre
            file.Enqueue(this); // ajoute le nœud actuel à la file

            while (file.Count > 0) 
            {
                var courant = file.Dequeue(); // retire un nœrd dla file
                listeNoeuds.Add(courant.Donnee); // ajt les données du nœud à la liste

                foreach (var enfant in courant.Enfants) // ajt les enfants du nœud à la file
                {
                    file.Enqueue(enfant);
                }
            }

            listeNoeuds.Sort(comparaison); // Trie la liste des données

            int index = 0;
            file.Enqueue(this); // réinitialise la file avec le nœud actuel
            while (file.Count > 0) // parcourt l'arbre pour réassigner les données triées
            {
                var courant = file.Dequeue(); // rtire un nœud de la file
                courant.Donnee = listeNoeuds[index++]; // met à jour les données du nœud

                foreach (var enfant in courant.Enfants) // ajoute les enfants du nœud à la file
                {
                    file.Enqueue(enfant);
                }
            }
        }
    }
}
