using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day5 : Day {
        public Day5() {
            addAufgabe("Tag 5 Mitschrift", Transcript);
        }
        public void Transcript() {
            // Klassisch als Array
            string[] einkauf = new string[5];
            einkauf[0] = "Butter";
            einkauf[1] = "Eier";
            einkauf[2] = "Milch";
            einkauf[3] = "Brot";
            einkauf[4] = "Wurst";

            //DieListe();
            DasDictionary();
        }
        static void AufDenSchirm(List<string> einkaufsliste) {
            for (int index = 0; index < einkaufsliste.Count; index++) {
                Console.WriteLine(einkaufsliste[index]);
            }
            Console.WriteLine();

            foreach (string element in einkaufsliste) {
                Console.WriteLine(element);
            }
            Console.WriteLine();
        }

        static void DieListe() {
            string meineVariable = "Wurst";
            // Neu als Liste
            List<string> einkaufsliste = new List<string>();
            einkaufsliste.Add("Butter");
            einkaufsliste.Add("Eier");
            einkaufsliste.Add("Milch");
            einkaufsliste.Add("Brot");
            einkaufsliste.Add(meineVariable);
            einkaufsliste.Add("Ketchup");
            einkaufsliste.Add("Wasser");
            einkaufsliste.Add("Salz");

            AufDenSchirm(einkaufsliste);

            einkaufsliste.Remove("Brot");
            Console.WriteLine("Brot aus Liste entfernt\n");

            AufDenSchirm(einkaufsliste);

            einkaufsliste.RemoveAt(2);
            Console.WriteLine("Element 2 (Milch) aus Liste entfernt\n");

            AufDenSchirm(einkaufsliste);


            Console.WriteLine("Element 3 (Wurst?) ersetzen durch Tomaten\n");

            for (int index = 0; index < einkaufsliste.Count; index++) {
                if (einkaufsliste[index] == meineVariable) {
                    einkaufsliste[index] = "Tomaten";
                }
            }
            Console.WriteLine();

            AufDenSchirm(einkaufsliste);

            Console.WriteLine("Einkaufsliste alphabetisch sortieren\n");
            einkaufsliste.Sort();

            AufDenSchirm(einkaufsliste);

            Console.WriteLine("Ist Wasser in der Liste enthalten?\n");
            if (einkaufsliste.Contains("Wasser")) {
                Console.WriteLine("Wasser steht in der Liste");
            }

            AufDenSchirm(einkaufsliste);

            Console.WriteLine("Ein Element ersetzen durch Bier\n");
            Console.WriteLine("Ist so machbar, aber viel zu aufwändig. Besser mit einfacher For-Schleife\n");
            int zaehler = 0;
            int meinMerker = 0;
            foreach (string element in einkaufsliste) {
                if (element == "Ketchup") {
                    meinMerker = zaehler;
                }
                zaehler++;
            }
            einkaufsliste[meinMerker] = "Bier";

            AufDenSchirm(einkaufsliste);
        }

        static void DasDictionary() {
            Dictionary<string, string> WoerterBuch = new Dictionary<string, string>();
            WoerterBuch.Add("Cat", "Katze");
            WoerterBuch.Add("Dog", "Hund");
            WoerterBuch.Add("Bread", "Brot");
            WoerterBuch.Add("Beer", "Bier");

            Console.WriteLine("Auf ein bestimmtes Element im Dictionary zugreifen");
            Console.WriteLine(WoerterBuch["Bread"] + "\n");

            foreach (string key in WoerterBuch.Keys) {
                Console.WriteLine(key + " = " + WoerterBuch[key]);
            }

            string MeineSuche = "Dog";
            if (WoerterBuch.Keys.Contains(MeineSuche)) {
                WoerterBuch[MeineSuche] = "Hundeli";
            }

            foreach (string key in WoerterBuch.Keys) {
                Console.WriteLine(key + " = " + WoerterBuch[key]);
            }

            Console.WriteLine();

            foreach (KeyValuePair<string, string> paare in WoerterBuch) {
                Console.WriteLine("Key: " + paare.Key + " | Value: " + paare.Value);
            }

        }
    }
}
