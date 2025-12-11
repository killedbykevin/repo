namespace BestelBuddy.Models
{
    public class MenuKaart
    {
        public int MenuKaartId { get; set; }  
        public List<MenuItem> Items { get; set; } = new();
        public int FoodtruckId { get; set; }
        public Foodtruck? Foodtruck { get; set; }

        public MenuKaart() { }

        public MenuKaart(int menuKaartId, List<MenuItem>? items = null)
        {
            MenuKaartId = menuKaartId;
            Items = items ?? new List<MenuItem>();
        }

        public void ToonItems()
        {
            foreach (var item in Items)
            {
                item.ToonDetails();
            }
        }

        public void VoegItemToe(MenuItem item)
        {
            Items.Add(item);
        }
    }
}
