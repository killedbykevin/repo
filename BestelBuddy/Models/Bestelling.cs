namespace BestelBuddy.Models
{
    public class Bestelling
    {
        public int BestellingId { get; set; }
        public DateTime Tijdstip { get; set; }
        public DateTime TijdstipKlaar { get; set; }
        public decimal TotaalBedrag { get; set; }
        public Bezoeker? Bezoeker { get; set; }
        public Foodtruck? Foodtruck { get; set; }
        public DateTime AangemaaktOp { get; set; } = DateTime.Now;
        public int BezoekerId { get; set; }
        public int FoodtruckId { get; set; }
        public string Status { get; set; } = "Nieuw";
        public List<BestellingItem> Items { get; set; } = new();

        public Bestelling() { }

        // Constructor die BestellingItems maakt uit MenuItems
        public Bestelling(int bestellingId, DateTime tijdstip, DateTime tijdstipKlaar, List<MenuItem> items, double totaalBedrag)
        {
            BestellingId = bestellingId;
            Tijdstip = tijdstip;
            TijdstipKlaar = tijdstipKlaar;
            Items = items.Select(mi => new BestellingItem { MenuItem = mi, Aantal = 1 }).ToList();
            TotaalBedrag = TotaalBedrag;
        }

        public void VerwijderItem(MenuItem item)
        {
            var bestellingItem = Items.FirstOrDefault(i => i.MenuItem == item);
            if (bestellingItem != null)
            {
                Items.Remove(bestellingItem);
            }
        }

        public void WijzigStatus(string nieuweStatus)
        {
            Status = nieuweStatus;
            foreach (var item in Items)
            {
                if (item.MenuItem != null)
                {
                    item.MenuItem.Status = nieuweStatus;
                }
            }
        }
    }

    public class BestellingItem
    {
        public int BestellingItemId { get; set; }
        public int BestellingId { get; set; }
        public Bestelling? Bestelling { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }
        public int Aantal { get; set; } = 1;
    }
}