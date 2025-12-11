namespace BestelBuddy.Models
{
	public class Drank : MenuItem
	{
		public string Omschrijving { get; set; } = string.Empty;

		public Drank() { }

		public Drank(int id, string naam, decimal prijs, string status, string omschrijving)
			: base(id, naam, prijs, status)
		{
			Omschrijving = omschrijving;
		}
	}
}
