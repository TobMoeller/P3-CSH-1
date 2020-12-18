using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day19 : Day {
        public Day19() {
            addAufgabe("BSP Übung 1", bausteinPruefung1);
        }

        public void bausteinPruefung1() {
            for (int i = 0; i < 20; i++) {
                Schaf.scheren.Add(new Schaf("Schaf-" + (i + 1)));
                Console.WriteLine("Erzeugt: " + Schaf.scheren[i].Name);
            }
            Schaefer schaefer = new Schaefer();
            Schafscherer schafscherer = new Schafscherer();
            Random zuf = new Random();
            //schaefer.SchafKannGeschorenWerden += schafscherer.SchafScheren;
            //schafscherer.SchafKannAufDieWeide += schaefer.SchafAufDieWeide;
            Schaf.scheren = Schaf.scheren.OrderBy(x => zuf.Next()).ToList();
            for (int i = 0; i < 20; i++) {
                Console.WriteLine("Erzeugt: " + Schaf.scheren[i].Name);
            }
        }

        class Schaf {
            public string Name { get; set; }
            public static List<Schaf> scheren = new List<Schaf>();
            public static List<Schaf> geschoren = new List<Schaf>();

            public Schaf(string name) {
                Name = name;
            }

            public void SchafeMischen() {
                Random zufall = new Random();
            }
            public void AusgabeGeschoren() {
                Console.WriteLine("Bereits geschoren:");
                foreach (Schaf schaf in geschoren) {
                    Console.WriteLine(schaf.Name);
                }
            }
        }

        class Schaefer {
            public delegate void SchafBereit(int schafNummer);
            public event SchafBereit SchafKannGeschorenWerden;

            public void SchafEinfangen(int schafNummer) {

                SchafKannGeschorenWerden?.Invoke(schafNummer);
            }

            public void SchafAufDieWeide(int schafNummer) {

            }
        }

        class Schafscherer {
            public delegate void SchafGeschoren();
            public event SchafGeschoren SchafKannAufDieWeide;

            public void SchafScheren() {

            }
        }

    }
}
