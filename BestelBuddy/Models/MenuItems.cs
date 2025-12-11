namespace BestelBuddy.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }   
        public string Naam { get; set; } = string.Empty;
        public decimal Prijs { get; set; }
        public string Status { get; set; } = string.Empty;
        public int FoodtruckId { get; set; }
        public Foodtruck? Foodtruck { get; set; }

        public MenuItem() { }

        public MenuItem(int id, string naam, decimal prijs, string status)
        {
            MenuItemId = id;
            Naam = naam;
            Prijs = prijs;
            Status = status;
        }

        public virtual void ToonDetails()
        {
            Console.WriteLine($"Item: {MenuItemId}, Naam: {Naam}, Prijs: {Prijs}");
        }

        public void WijzigPrijs(decimal nieuwePrijs) => Prijs = nieuwePrijs;
    }
}
