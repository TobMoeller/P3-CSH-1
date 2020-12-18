using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day7 : Day {
        public Day7() {
            addAufgabe("Tag 7 Mitschrift", Transcript);
        }
        public void Transcript() {
            MeineMethode();
            Console.WriteLine(wert);
            MeineKlasse.MeinInt += 1000;
            MeineKlasse.StarteMich();

            Console.WriteLine("\n\n");

            //MeinKonto.Einzahlen(50, "Walter", "Test");
            //MeinKonto.Abheben(150, "Fred", "Fred123");

            MeinKonto.LogIn("Fred", "Fred123");
        }
        static int wert = 5;

        static List<int> MeineListe;

        static void MeineMethode() {
            int InDerMethode = 12;
            Console.WriteLine("In der Methode steht eine " + InDerMethode);
        }
        class MeinKonto {
            static int MeinGeld = 500;
            static int Dispo = 2500;

            static string user = "Fred";
            static string pw = "Fred123";

            static void Einzahlen(int wert) {
                if (wert >= 0) {
                    MeinGeld += wert;
                    KontoStand();
                } else {
                    Console.WriteLine("Das ist ein negativer Wert.");
                }
            }

            static void Abheben(int wert) {
                if ((wert < MeinGeld + Dispo) && wert >= 0) {
                    MeinGeld -= wert;
                    KontoStand();
                } else {
                    Console.WriteLine("Dispo überschritten. Gibt kein Geld.");
                }
            }
            static void KontoStand() {
                Console.WriteLine("Aktueller Kontostand: " + MeinGeld);
                Console.ReadKey(true);
            }
            public static void LogIn(string benutzer, string pass) {
                if (user == benutzer && pw == pass) {
                    string eingabe;
                    do {
                        Console.Clear();
                        Console.WriteLine("Kontostand = 0");
                        Console.WriteLine("Abheben = 1");
                        Console.WriteLine("Einzahlen = 2");
                        Console.WriteLine("Ende = x");
                        eingabe = Console.ReadLine();

                        switch (eingabe) {
                            case "0":
                                KontoStand();
                                break;
                            case "1":
                                Abheben(150);
                                break;
                            case "2":
                                Einzahlen(200);
                                break;
                        }
                    } while (eingabe != "x");
                } else {
                    Console.WriteLine("Falsches Login");
                }

                // Aufgabe: Wir brauchen für unsere Bank eine Anmeldung
                // Der Benutzer gibt Name und Passwort ein
                // Es wird geprüft, ob Name und Passwort ok sind
                // Erst DANN darf er einzahlen und abheben
            }
        }


        class MeineKlasse {
            public static int MeinInt = 5;
            private static void MeineKlasseMethode() {
                Console.WriteLine("Grüße aus der Klasse MeineKlasse");
                Console.WriteLine("MeinInt hat den Wert " + MeinInt);
            }

            public static void StarteMich() {
                MeinInt += 10;
                MeineKlasseMethode();
                WeitereKlasse.WeitereKlasseMethode();
            }
        }
        class WeitereKlasse {
            public static void WeitereKlasseMethode() {
                Console.WriteLine("Grüße aus der Klasse WeitereKlasse");
            }
        }
    }
}
