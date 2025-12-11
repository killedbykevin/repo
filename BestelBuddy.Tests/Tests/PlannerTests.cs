using Xunit;
using BestelBuddy.Models;
using System;
using System.Collections.Generic;

namespace Bestelbuddy.Tests
{
    public class PlannerTests
    {
        [Fact] // een truck wordt toegevoegd
        public void PlanFoodtruckEvent_FoodtruckIsToegevoegd()
        {
            var planner = new Planner(1, "Kevin", "kevin@mail.com");
            var evenement = new Evenement(1, "Festival", DateTime.Today, "Utrecht");
            var menukaart = new MenuKaart(1);
            var truck = new Foodtruck(1, "PizzaTruck", "Pizza", menukaart);
            truck.Medewerkers.Add(new Medewerker(1, "Ali", "Kok"));
            truck.Open();

            planner.PlanFoodtruckEvent(evenement, truck);

            Assert.Contains(truck, evenement.Foodtrucks);
        }

        [Fact] // tweede truck met geldige status wordt ook toegevoegd
        public void PlanFoodtruckEvent_VariatieAndereTruck_WordtOokToegevoegd()
        {
            var planner = new Planner(2, "Lisa", "lisa@mail.com");
            var evenement = new Evenement(2, "Vegan Parade", DateTime.Today, "Amsterdam");
            var menukaart = new MenuKaart(2);
            var truck = new Foodtruck(2, "VeganTruck", "Vegan", menukaart);
            truck.Medewerkers.Add(new Medewerker(2, "Sophie", "Chef"));
            truck.Open();

            planner.PlanFoodtruckEvent(evenement, truck);

            Assert.Contains(truck, evenement.Foodtrucks);
        }

        [Fact] // truck is niet beschikbaar 
        public void PlanFoodtruckEvent_FoodtruckNietBeschikbaar_ThrowsException()
        {
            var planner = new Planner(3, "Tom", "tom@mail.com");
            var evenement = new Evenement(3, "Burger Bash", DateTime.Today, "Rotterdam");
            var menukaart = new MenuKaart(3);
            var truck = new Foodtruck(3, "BurgerTruck", "Burger", menukaart);
            truck.Medewerkers.Add(new Medewerker(3, "Tom", "Grillmaster"));
            // truck blijft gesloten

            Assert.Throws<InvalidOperationException>(() => planner.PlanFoodtruckEvent(evenement, truck));
        }

        [Fact] // truck heeft geen medewerkers 
        public void PlanFoodtruckEvent_GeenMedewerkers_ThrowsException()
        {
            var planner = new Planner(4, "Eva", "eva@mail.com");
            var evenement = new Evenement(4, "Wraps & More", DateTime.Today, "Den Haag");
            var menukaart = new MenuKaart(4);
            var truck = new Foodtruck(4, "WrapTruck", "Wraps", menukaart);
            truck.Open(); // maar geen medewerkers

            Assert.Throws<InvalidOperationException>(() => planner.PlanFoodtruckEvent(evenement, truck));
        }

        [Fact] // truck heeft te veel medewerkers
        public void PlanFoodtruckEvent_TeVeelMedewerkers_ThrowsException()
        {
            var planner = new Planner(5, "Noa", "noa@mail.com");
            var evenement = new Evenement(5, "Sushi Sunday", DateTime.Today, "Leiden");
            var menukaart = new MenuKaart(5);
            var truck = new Foodtruck(5, "SushiTruck", "Sushi", menukaart);
            truck.Medewerkers.Add(new Medewerker(6, "A", "Chef"));
            truck.Medewerkers.Add(new Medewerker(7, "B", "Sous-chef"));
            truck.Medewerkers.Add(new Medewerker(8, "C", "Hulp"));
            truck.Open();

            Assert.Throws<InvalidOperationException>(() => planner.PlanFoodtruckEvent(evenement, truck));
        }
    }
}
