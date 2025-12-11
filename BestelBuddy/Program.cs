using System;
using System.Collections.Generic;
using System.Linq;
using BestelBuddy.Models;
using BestelBuddy.Data;
using BestelBuddy.Repositories;

class Program
{
    static void Main(string[] args)
    {
        // --- Demo scenario ---
        var planner = new Planner { PlannerId = 1, Naam = "Kevin", EmailAdres = "kevin@gmail.com" };
        var evenement = new Evenement { EvenementId = 101, Naam = "Ei Festival", Datum = DateTime.Today, Locatie = "Barneveld" };

        var menukaart = new MenuKaart { MenuKaartId = 1 };
        menukaart.Items.Add(new Drank { MenuItemId = 1, Naam = "Jasmijnthee", Prijs = 2.5m, Status = "Beschikbaar", Omschrijving = "Groene thee" });
        menukaart.Items.Add(new Snack { MenuItemId = 2, Naam = "Loempia", Prijs = 3.0m, Status = "Beschikbaar", Omschrijving = "Knapperig" });
        menukaart.Items.Add(new Hoofdgerecht { MenuItemId = 3, Naam = "Kung Pao Kip", Prijs = 9.5m, Status = "Beschikbaar", Omschrijving = "Pittig" });
        menukaart.Items.Add(new Dessert { MenuItemId = 4, Naam = "Lychee ijs", Prijs = 4.0m, Status = "Beschikbaar", Omschrijving = "Fris" });

        var wokTruck = new Foodtruck { FoodtruckId = 1, Naam = "Golden Wok", Specialiteit = "Chinees", Menukaart = menukaart, IsBeschikbaar = true };
        wokTruck.Medewerkers.Add(new Medewerker { MedewerkerId = 1, Naam = "Sophie", Rol = "Kok" });
        wokTruck.Medewerkers.Add(new Medewerker { MedewerkerId = 2, Naam = "Ali", Rol = "Hulp" });
        wokTruck.Open();

        planner.Evenementen.Add(evenement);

        var bezoeker = new Bezoeker { BezoekerId = 1, Naam = "Lisa", EmailAdres = "lisa@gmail.com" };
        var bestelling = new Bestelling
        {
            BestellingId = 5001,
            AangemaaktOp = DateTime.Now,
            Bezoeker = bezoeker,
            Foodtruck = wokTruck,
            Items = new List<BestellingItem>
            {
                new BestellingItem { MenuItem = menukaart.Items[1], Aantal = 1 },
                new BestellingItem { MenuItem = menukaart.Items[2], Aantal = 1 }
            }
        };
        bestelling.TotaalBedrag = bestelling.Items.Sum(i => i.MenuItem?.Prijs ?? 0m);
        bestelling.Status = "Klaar";

        Console.WriteLine($"Planner {planner.Naam} plant '{wokTruck.Naam}' voor '{evenement.Naam}' in {evenement.Locatie}.");
        Console.WriteLine($"\nBezoeker {bezoeker.Naam} bestelt:");
        foreach (var item in bestelling.Items)
        {
            Console.WriteLine($"- {item.MenuItem?.Naam} (€{item.MenuItem?.Prijs})");
        }
        Console.WriteLine($"Totaal: €{bestelling.TotaalBedrag}\nStatus: {bestelling.Status}");

        // --- EF Core repositories ---
        var context = new BestelBuddyContextFactory().CreateDbContext(args);
        var bezoekerRepo = new GenericRepository<Bezoeker>(context);
        var truckRepo = new GenericRepository<Foodtruck>(context);

        var newBezoeker = new Bezoeker { Naam = "Kevin", EmailAdres = "kevin@example.com" };
        bezoekerRepo.Add(newBezoeker);
        bezoekerRepo.Save();

        var pizzaTruck = new Foodtruck { Naam = "Pizza Express", Specialiteit = "Italiaans", IsBeschikbaar = true };
        truckRepo.Add(pizzaTruck);
        truckRepo.Save();
    }
}