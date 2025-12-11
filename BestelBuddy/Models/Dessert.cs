namespace BestelBuddy.Models
{
    public class Dessert : MenuItem
    {
        public string Omschrijving { get; set; } = string.Empty;

        public Dessert() { }

        public Dessert(int id, string naam, decimal prijs, string status, string omschrijving)
            : base(id, naam, prijs, status)
        {
            Omschrijving = omschrijving;
        }
    }
}