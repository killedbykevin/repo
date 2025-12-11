namespace BestelBuddy.Models
{
    public class Bezoeker
    {
        public int BezoekerId { get; set; }   
        public string Naam { get; set; }
        public string EmailAdres { get; set; }
        public List<Bestelling> Bestellingen { get; set; } = new();

        public Bezoeker() { }
        public Bezoeker(int bezoekerId, string naam, string emailAdres, List<Bestelling>? bestellingen = null)
        {
            BezoekerId = bezoekerId;
            Naam = naam;
            EmailAdres = emailAdres;
            Bestellingen = bestellingen ?? new List<Bestelling>();
        }

        public void PlaatsBestelling(Bestelling bestelling)
        {
            Bestellingen.Add(bestelling);
        }
    }
}
