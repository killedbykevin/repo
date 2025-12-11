using Xunit;
using BestelBuddy.Models;
using System;
using System.IO;

public class MenuItemTests
{
    [Fact] // Een item met prijs toevoegen en dan wijzigen naar 7.5  
    public void wijzigprijs_ValidPrijs_WordtCorrectIngesteld()
    {
        var item = new MenuItem(1, "Loempia", 5.0m, "Beschikbaar");
        item.WijzigPrijs(7.5m);

        Assert.Equal(7.5m, item.Prijs);
    }

    [Fact] // Item toevoegen en dan item laten tonen  
    public void ToonDetails_PrintsCorrectFormat()
    {
        var item = new MenuItem(1, "Loempia", 3.0m, "Beschikbaar");

        using var sw = new StringWriter();
        Console.SetOut(sw);

        item.ToonDetails();

        var output = sw.ToString().Trim();
        Assert.Equal("Item: 1, Naam: Loempia, Prijs: 3", output);
    }
}
