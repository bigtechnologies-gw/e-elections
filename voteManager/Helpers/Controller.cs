﻿using System;
using System.Collections.Generic;

namespace EElections.Helpers
{
    // note: this is the base class for all "Partidos"
    public abstract class Controller // TODO: Rename to match the context of  super/base class
    {
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        private List<Region> _regions;

        public Controller()
        {
            // TODO: THIS SHOULD ONLY RUN ONCE WHEN NO DATA HAS BEEN BUILD ALREADY.
            _regions = new List<Region>(BuildRegions());

            // create regions

            // tombali ce-1(catio, komo) ce-2((bedanda, cacine, quebo)
            // quinara ce-3(buba, empada) ce-4(fulacunda)
            // oio  ce-5( bissora), ce-6 (farim), ce7(mansaba), ce-06
            // biombo
            // bolama/bijagos
            // bafata
            // gabu
            // cacheu
            // SAB
        }

        private static IList<Region> BuildRegions()
        {
            throw new NotFiniteNumberException();
            //var listRegions = new List<Region>(9);

            //listRegions.Add(new Region("Tombali", new List<Sector>() { new Sector(1, "Catio"),
            //    new Sector(1, "Komo") , new Sector(2, "Bedanda"), new Sector(2, "Cacine"), new Sector(2, "Quebo")}));

            //listRegions.Add(new Region("Quinara", new List<Sector>() { new Sector("Catio"), new Sector("Komo") }));
            //listRegions.Add(new Region("Oio", new List<Sector>() { new Sector("Catio"), new Sector("Komo") }));
            //listRegions.Add(new Region("Biombo", new List<Sector>() { new Sector("Catio"), new Sector("Komo") }));
            //listRegions.Add(new Region("Bolama/Bijagos", new List<Sector>() { new Sector("Catio"), new Sector("Komo") }));
            //listRegions.Add(new Region("Bafata*", new List<Sector>() { new Sector("Catio"), new Sector("Komo") }));
            //listRegions.Add(new Region("Tombali", new List<Sector>() { new Sector("Catio"), new Sector("Komo") }));

            // todo: use inheritance since bissau isn't a *region?
            //listRegions.Add(new Region("SA", new List<Sector>() { new Sector("Catio"), new Sector("Komo") }));
            //return listRegions;
        }
    }
}
