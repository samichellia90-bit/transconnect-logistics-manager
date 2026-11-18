namespace TransConnect;

public interface IVehicule//interface
{
    string Immatriculation { get; set; }
    string Marque { get; set; }
    string Modele { get; set; }
    int Annee { get; set; }
    string Commentaire { get; set; }
}
