using Xunit;
using BestelBuddy.Models;
using System;
using System.Collections.Generic;

public class EvenementTests
{
    [Fact] // voegt 1 truck toe aan evenement
    public void VoegFoodtruckToe_ValidTruck_AddsToList()
    {
        var menukaart = new MenuKaart(1);
        var evenement = new Evenement(101, "FoodFest", DateTime.Today, "Amsterdam");
        var truck = new Foodtruck(1, "PizzaTruck", "Italiaans", menukaart);

        evenement.VoegFoodtruckToe(truck);

        Assert.Contains(truck, evenement.Foodtrucks);
    }

    [Fact] // meerdere trucks toevoegen
    public void VoegFoodtruckToe_MultipleTrucks_AllAdded()
    {
        var menukaart = new MenuKaart(2);
        var evenement = new Evenement(102, "Truck Parade", DateTime.Today, "Utrecht");

        var truck1 = new Foodtruck(2, "BurgerTruck", "Amerikaans", menukaart);
        var truck2 = new Foodtruck(3, "SushiTruck", "Japans", menukaart);

        evenement.VoegFoodtruckToe(truck1);
        evenement.VoegFoodtruckToe(truck2);

        Assert.Equal(2, evenement.Foodtrucks.Count);
    }
    [Fact] 
    public void falendetest()
    {
        Assert.True(false);
    }
}
