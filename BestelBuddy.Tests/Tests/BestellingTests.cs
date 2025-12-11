using Xunit;
using BestelBuddy.Models;
using System;
using System.Collections.Generic;

public class BestellingTests
{
    [Fact] // item aan lijst toevoegen en dan weer verwijderen    
    public void VerwijderItem_ItemInLijst_ItemWordtVerwijderd()
    {
        var item = new MenuItem { MenuItemId = 1, Naam = "Loempia", Prijs = 5.0m, Status = "Actief" };
        var bestelling = new Bestelling(5001, DateTime.Now, DateTime.Now.AddMinutes(15), new List<MenuItem> { item }, 5.0m);

        bestelling.VerwijderItem(item);

        Assert.DoesNotContain(bestelling.Items, bi => bi.MenuItem == item);
    }

    [Fact] // item verwijderen dat niet in de lijst staat    
    public void VerwijderItem_ItemNietInLijst_GeenFout()
    {
        var item = new MenuItem { MenuItemId = 2, Naam = "Sushi", Prijs = 6.0m, Status = "Actief" };
        var bestelling = new Bestelling(5002, DateTime.Now, DateTime.Now.AddMinutes(15), new List<MenuItem>(), 0.0m);

        var exception = Record.Exception(() => bestelling.VerwijderItem(item));

        Assert.Null(exception);
        Assert.Empty(bestelling.Items);
    }

    [Fact] // items toevoegen en dan status wijzigen van behandeling naar klaar    
    public void WijzigStatus_AlleItemsKrijgenNieuweStatus()
    {
        var item1 = new MenuItem { MenuItemId = 3, Naam = "Burger", Prijs = 7.0m, Status = "In behandeling" };
        var item2 = new MenuItem { MenuItemId = 4, Naam = "Fries", Prijs = 3.0m, Status = "In behandeling" };
        var bestelling = new Bestelling(5003, DateTime.Now, DateTime.Now.AddMinutes(15), new List<MenuItem> { item1, item2 }, 10.0m);

        bestelling.WijzigStatus("Klaar");

        Assert.All(bestelling.Items, bi => Assert.Equal("Klaar", bi.MenuItem?.Status));
    }
}
