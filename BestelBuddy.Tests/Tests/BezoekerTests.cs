using Xunit;
using BestelBuddy.Models;
using System;
using System.Collections.Generic;

public class BezoekerTests
{
    [Fact] // een bestelling plaatsen
    public void PlaatsBestelling_ValidBestelling_WordtToegevoegd()
    {
        var bezoeker = new Bezoeker(1, "Kevin", "kevin@example.com");
        var bestelling = new Bestelling(5001, DateTime.Now, DateTime.Now.AddMinutes(15), new List<MenuItem>(), 0);

        bezoeker.PlaatsBestelling(bestelling);

        Assert.Contains(bestelling, bezoeker.Bestellingen);
    }

    [Fact] // meerdere bestellingen plaatsen en opslaan
    public void PlaatsBestelling_MultipleBestellingen_WordenCorrectOpgeslagen()
    {
        var bezoeker = new Bezoeker(2, "Lisa", "lisa@example.com");

        var bestelling1 = new Bestelling(5002, DateTime.Now, DateTime.Now.AddMinutes(10), new List<MenuItem>(), 0);
        var bestelling2 = new Bestelling(5003, DateTime.Now, DateTime.Now.AddMinutes(20), new List<MenuItem>(), 0);

        bezoeker.PlaatsBestelling(bestelling1);
        bezoeker.PlaatsBestelling(bestelling2);

        Assert.Equal(2, bezoeker.Bestellingen.Count);
    }
}
