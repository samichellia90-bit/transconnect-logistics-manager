using System;
using System.Collections.Generic;

namespace TransConnect
{
    
    public class Organigramme
    {
        
        public Noeud<Salarie> DirecteurGeneral;//prop pour stocker le directeur (root)

       
        public void AfficherOrganigramme()
        {
            if (DirecteurGeneral != null)
            {
                AfficherSalarie(DirecteurGeneral, 0);
            }
            else
            {
                Console.WriteLine("L'organigramme est vide.");
            }
        }

        
        private void AfficherSalarie(Noeud<Salarie> noeud, int niveau)// méthode recursive avec l'indentation pour representer l'arbre
        {
            if (noeud == null) return;

            // affiche le salarié avec une indentation correspondant à son niveau dans l'arbre
            Console.WriteLine(new string(' ', niveau * 2) + noeud.Donnee.Nom + " - " + noeud.Donnee.Poste);
            foreach (var enfant in noeud.Enfants)
            {
                AfficherSalarie(enfant, niveau + 1);
            }
        }
        public void EmbaucherSalarie(Salarie salarie, Noeud<Salarie> superieur = null)
        {
            var noeud = new Noeud<Salarie>(salarie);
            if (superieur == null)
            {
                DirecteurGeneral = noeud;
            }
            else
            {
                superieur.AjouterEnfant(noeud);
            }
        }

        public void LicencierSalarie(Noeud<Salarie> noeud, string nss)
        {
            if (noeud == null) return;

            foreach (var enfant in noeud.Enfants)
            {
                if (enfant.Donnee.NSS == nss)
                {
                    noeud.Enfants.Remove(enfant);
                    return;
                }
                LicencierSalarie(enfant, nss);
            }
        }

        public Noeud<Salarie> TrouverSalarie(Noeud<Salarie> noeud, string nss)
        {
            if (noeud == null) return null;

            if (noeud.Donnee.NSS == nss) return noeud;

            foreach (var enfant in noeud.Enfants)
            {
                var result = TrouverSalarie(enfant, nss);
                if (result != null) return result;
            }

            return null;
        }
    }
}
