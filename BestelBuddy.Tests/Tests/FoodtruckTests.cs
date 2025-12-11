using Xunit;
using BestelBuddy.Models;
using System.Collections.Generic;

public class FoodtruckTests
{
    [Fact] // zet de foodtruck open
    public void Open_ZetBeschikbaarheidOpTrue()
    {
        var truck = new Foodtruck(1, "PizzaTruck", "Italiaans", new MenuKaart(1));

        truck.Open();

        Assert.True(truck.IsBeschikbaar);
    }

    [Fact] // sluit de foodtruck
    public void Sluit_ZetBeschikbaarheidOpFalse()
    {
        var truck = new Foodtruck(2, "BurgerTruck", "Amerikaans", new MenuKaart(2));
        truck.Open(); // eerst openen

        truck.Sluit();

        Assert.False(truck.IsBeschikbaar);
    }
}
