namespace BestelBuddy.Models
{
    public class Evenement
    {
        public int EvenementId { get; set; }   
        public string Naam { get; set; }
        public DateTime Datum { get; set; }
        public string Locatie { get; set; }
        public List<Foodtruck> Foodtrucks { get; set; } = new();

        public Evenement() { }
        public Evenement(int evenementId, string naam, DateTime datum, string locatie, List<Foodtruck>? foodtrucks = null)
        {
            EvenementId = evenementId;
            Naam = naam;
            Datum = datum;
            Locatie = locatie;
            Foodtrucks = foodtrucks ?? new List<Foodtruck>();
        }

        public void VoegFoodtruckToe(Foodtruck truck)
        {
            Foodtrucks.Add(truck);
        }
    }
}
