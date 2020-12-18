using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day8 : Day {
        public Day8() {
            addAufgabe("Tag 8 Mitschrift", Transcript);
        }
        public void Transcript() {
            // Konstruktorenüberladung:
            // Die Überladung eines Konstruktors unterscheidet sich in 1) Typ, 2) Anzahl, 3) Reihenfolge der Parameter
            MeineKlasse ob1 = new MeineKlasse();
            MeineKlasse ob2 = new MeineKlasse(123);
            MeineKlasse ob3 = new MeineKlasse("Hallo");
            MeineKlasse ob4 = new MeineKlasse(123, "Hallo");
            MeineKlasse ob5 = new MeineKlasse("Hallo", 123);

            Console.WriteLine("\n" + MeineKlasse.MeineObjekte.Count + "\n");

            MeineKlasse.AusgabeObjekte();

            ob3.MeinString = "Currywurst";

            MeineKlasse.AusgabeObjekte();

            for (int index = 0; index < MeineKlasse.MeineObjekte.Count; index++) {
                Console.WriteLine(MeineKlasse.MeineObjekte[index].MeinInt + "  |  "
                                    + MeineKlasse.MeineObjekte[index].MeinString);
                if (MeineKlasse.MeineObjekte[index].MeinString == "Currywurst") {
                    MeineKlasse.MeineObjekte[index].MeinString = "Lecker mit Käse";
                }
            }

            Console.WriteLine(ob3.MeinInt + "  |  " + ob3.MeinString);

            Console.WriteLine("\n\n");
            Console.WriteLine("Mikrowelle");
            // Param 1: Watt   Param2: Zeit in sec   Param 3: Gewicht in gramm
            Mikrowelle MeineMikro = new Mikrowelle(600, 100, 800);

            Console.WriteLine(MeineMikro.GetWatt());
            MeineMikro.SetWatt(750);
            Console.WriteLine(MeineMikro.GetWatt());

            MeineMikro.Watt = 1000;
            MeineMikro.Watt -= 500;
            Console.WriteLine(MeineMikro.Watt);

            Console.WriteLine("Dauer :" + MeineMikro.Dauer);
            MeineMikro.Dauer = 123;
            Console.WriteLine("Dauer :" + MeineMikro.Dauer);



            //MeineMikro.Erhitzen();
        }
        class MeineKlasse {
            public int MeinInt;
            public string MeinString;

            public static List<MeineKlasse> MeineObjekte = new List<MeineKlasse>();

            public MeineKlasse() {
                Console.WriteLine("Du hast ein Objekt ohne Übergabeparameter erstellt");
                MeineObjekte.Add(this);
            }
            public MeineKlasse(int wert) {
                MeinInt = wert;
                Console.WriteLine("Du hast ein Objekt erstellt und den INT " + wert + " übergeben");
                MeineObjekte.Add(this);
            }
            public MeineKlasse(string wort) {
                MeinString = wort;
                Console.WriteLine("Du hast ein Objekt erstellt und den STRING " + wort + " übergeben");
                MeineObjekte.Add(this);
            }
            public MeineKlasse(int wert, string wort) {
                MeinInt = wert;
                MeinString = wort;
                Console.WriteLine("Du hast ein Objekt erstellt und den INT "
                                    + wert + " und den STRING " + wort + " übergeben");
                MeineObjekte.Add(this);
            }
            public MeineKlasse(string wort, int wert) {
                MeinInt = wert;
                MeinString = wort;
                Console.WriteLine("Du hast ein Objekt erstellt und den STRING "
                                    + wort + " und den INT " + wert + " übergeben");
                MeineObjekte.Add(this);
            }

            public static void AusgabeObjekte() {
                foreach (MeineKlasse element in MeineObjekte) {
                    Console.WriteLine(element.MeinInt + "  |  " + element.MeinString);
                }
            }
        }

        class Mikrowelle {
            int watt;
            //Variante 2: Verwendung einer Property (kürzeste Form)
            public int Dauer { get; set; }
            public int MwSt { get; }

            int gewicht; // gemeint ist das Gewicht in gramm des zu kochenden Essens

            // Variante 1: Setter und Getter als eigene kleine Methoden
            public int GetWatt() { // Getter (holt einen Wert aus einer privaten Variablen
                return watt;
            }

            public void SetWatt(int wattuebergabe) { // Setter (schreibt einen Wert in eine private Variable)
                if (wattuebergabe > 200 && wattuebergabe < 900) {
                    watt = wattuebergabe;
                } else {
                    Console.WriteLine("Diesen Wert kann ich nicht verwenden");
                }
            }

            //Variante 2: Verwendung einer Property
            public int Watt {
                get { return watt; }
                set {
                    if (value > 200 && value < 900) {
                        watt = value;
                    } else {
                        Console.WriteLine("Diesen Wert kann ich nicht verwenden");
                    }
                }
            }

            public Mikrowelle(int Watt, int dauerEingegeben, int Gewicht) {
                watt = Watt;
                Dauer = dauerEingegeben;
                gewicht = Gewicht;
            }
            public void Erhitzen() {

            }

            public void Auftauen() {

            }

            public void Grillen() {

            }
        }
    }
}
