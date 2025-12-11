namespace BestelBuddy.Models
{
    public class Foodtruck
    {
        public int FoodtruckId { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string Specialiteit { get; set; } = string.Empty;

        public List<Medewerker> Medewerkers { get; set; } = new();
        public List<MenuItem> MenuItems { get; set; } = new();
        public MenuKaart? Menukaart { get; set; }

        public bool IsBeschikbaar { get; set; } = false;

        public List<Bestelling> Bestellingen { get; set; } = new();

        public Foodtruck() { }

        public Foodtruck(int id, string naam, string specialiteit)
        {
            FoodtruckId = id;
            Naam = naam;
            Specialiteit = specialiteit;
        }

        public Foodtruck(int id, string naam, string specialiteit, MenuKaart menukaart, List<Medewerker>? medewerkers = null)
        {
            FoodtruckId = id;
            Naam = naam;
            Specialiteit = specialiteit;
            Menukaart = menukaart;
            Medewerkers = medewerkers ?? new List<Medewerker>();
        }

        public void Open() => IsBeschikbaar = true;
        public void Sluit() => IsBeschikbaar = false;
    }
}
