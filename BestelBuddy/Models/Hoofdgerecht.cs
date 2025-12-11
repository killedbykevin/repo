namespace BestelBuddy.Models
{
    public class Hoofdgerecht : MenuItem
    {
        public string Omschrijving { get; set; } = string.Empty;

        public Hoofdgerecht() { }

        public Hoofdgerecht(int id, string naam, decimal prijs, string status, string omschrijving)
            : base(id, naam, prijs, status)
        {
            Omschrijving = omschrijving;
        }
    }
}