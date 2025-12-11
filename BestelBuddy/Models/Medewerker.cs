namespace BestelBuddy.Models
{
    public class Medewerker
    {
        public int MedewerkerId { get; set; }  
        public string Naam { get; set; }
        public string Rol { get; set; }
        public int FoodtruckId { get; set; }
        public Foodtruck? Foodtruck { get; set; }

        public Medewerker() { }

        public Medewerker(int medewerkerId, string naam, string rol)
        {
            MedewerkerId = medewerkerId;
            Naam = naam;
            Rol = rol;
        }

        public void StartDienst()
        {
            // Dienst gestart
        }

        public void EindigDienst()
        {
            // Dienst beëindigd
        }
    }
}
