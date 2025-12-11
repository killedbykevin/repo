namespace BestelBuddy.Models
{
    public class Snack : MenuItem
    {
        public string Omschrijving { get; set; } = string.Empty;

        public Snack() { }

        public Snack(int id, string naam, decimal prijs, string status, string omschrijving)
            : base(id, naam, prijs, status)
        {
            Omschrijving = omschrijving;
        }
    }
}