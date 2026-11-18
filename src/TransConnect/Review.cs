using System;
using System.Collections.Generic;
using System.Linq;

namespace TransConnect
{
    public class Review
    {
        public string NssChauffeur { get; } //pas necssaire de set vu qu'il ne change plus
        public DateTime Date { get; }
        public int Note { get; }
        public string Commentaire { get; }

        public Review(string nssChauffeur, DateTime date, int note, string commentaire)
        {
            NssChauffeur = nssChauffeur;
            Date = date;
            Note = note;
            Commentaire = commentaire;
        }

        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()}, Note: {Note}, Commentaire: {Commentaire}";
        }
    }
    public class GestionReviews
    {
        private List<Review> reviews; //collection des reviews 

        public GestionReviews()
        {
            reviews = new List<Review>();
        }

        public void AjouterReview(Review review)
        {
            reviews.Add(review);
        }

        public List<Review> ObtenirReviews(string nssChauffeur)
        {
            return reviews.Where(r => r.NssChauffeur == nssChauffeur).ToList();
        }

        public double ObtenirMoyenneNotes(string nssChauffeur)
        {
            var notes = reviews.Where(r => r.NssChauffeur == nssChauffeur).Select(r => r.Note);
            return notes.Any() ? notes.Average() : 0;
        }
    }

    
}
