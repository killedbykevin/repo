using Xunit;
using BestelBuddy.Models;
using System;

public class BestellenTests
{
   
    public void VerwijderItem_ShouldRemoveItem()
    {
        var menuItem = new MenuItem { MenuItemId = 1, Naam = "Loempia", Prijs = 3.0m };
        var bestelling = new Bestelling
        {
            BestellingId = 1,
            Items = new List<BestellingItem> { new BestellingItem { MenuItem = menuItem } }
        };

        bestelling.VerwijderItem(menuItem);

        Assert.Empty(bestelling.Items);
    }

    
    public void WijzigStatus_ShouldUpdateStatus()
    {
        var menuItem = new MenuItem { MenuItemId = 1, Naam = "Loempia", Prijs = 3.0m, Status = "Nieuw" };
        var bestelling = new Bestelling
        {
            BestellingId = 1,
            Items = new List<BestellingItem> { new BestellingItem { MenuItem = menuItem } }
        };

        bestelling.WijzigStatus("Klaar");

        Assert.Equal("Klaar", bestelling.Status);
        Assert.Equal("Klaar", bestelling.Items[0].MenuItem.Status);
    }
}