namespace BestelBuddy.Models
{
    public class Planner
    {
        public int PlannerId { get; set; }   
        public string Naam { get; set; }
        public string EmailAdres { get; set; }
        public List<Evenement> Evenementen { get; set; } = new();

        public Planner() { }
        public Planner(int plannerId, string naam, string emailAdres)
        {
            PlannerId = plannerId;
            Naam = naam;
            EmailAdres = emailAdres;
        }

        public void PlanFoodtruckEvent(Evenement evenement, Foodtruck truck)
        {
            if (truck == null)
                throw new ArgumentNullException(nameof(truck));

            if (!truck.IsBeschikbaar)
                throw new InvalidOperationException($"Foodtruck '{truck.Naam}' is niet beschikbaar.");

            if (truck.Medewerkers.Count == 0)
                throw new InvalidOperationException($"Foodtruck '{truck.Naam}' heeft geen medewerkers toegewezen.");

            if (truck.Medewerkers.Count > 2)
                throw new InvalidOperationException($"Foodtruck '{truck.Naam}' heeft te veel medewerkers (maximaal 2).");

            evenement.VoegFoodtruckToe(truck);
        }
    }
}
