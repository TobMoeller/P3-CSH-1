using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day3 : Day {
        public Day3() {
            addAufgabe("Tag 3 Mitschrift", Transcript);
        }

        public void Transcript() {
            //Klassisch();
            //EinDimArray();
            //MehrDimArrays();
            //MehrDimSymArrays();
            //MehrDimAsymArrays();
            CBR_CBV();

            Console.WriteLine("\n\n");

            Console.ReadKey();
        }

        static void Klassisch() {
            Random zufall;
            zufall = new Random();
            //Aufgabe: Es soll gewürfelt werden (Zahlen: 1 bis 6)
            // 5000 Durchgänge
            // In jedem Durchgang wird eine Zufallszahl erzeugt.
            // Es soll die Häufigkeit jeder einzelnen Zufallszahl ermittelt werden
            // Ergebnis (Beispiel)  1 = 500, 2 = 1000, 3 = 750, 4 = ...

            int anzahl = 10000;
            Console.WriteLine("Zufallszahlen zwischen 1 und 6");
            Console.WriteLine(anzahl + " Durchgänge");

            int gerollt;
            int eins = 0, zwei = 0, drei = 0, vier = 0, fuenf = 0, sechs = 0;
            for (int index = 0; index < anzahl; index++) {
                gerollt = zufall.Next(1, 7);

                switch (gerollt) {
                    case 1:
                        eins++;
                        break;
                    case 2:
                        zwei++;
                        break;
                    case 3:
                        drei++;
                        break;
                    case 4:
                        vier++;
                        break;
                    case 5:
                        fuenf++;
                        break;
                    case 6:
                        sechs++;
                        break;
                }
            }

            Console.WriteLine("Die 1 kam " + eins + " mal. Das sind " + (double)eins / anzahl * 100 + " Prozent");
            Console.WriteLine("Die 2 kam " + zwei + " mal. Das sind " + (double)zwei / anzahl * 100 + " Prozent");
            Console.WriteLine("Die 3 kam " + drei + " mal. Das sind " + (double)eins / anzahl * 100 + " Prozent");
            Console.WriteLine("Die 4 kam " + vier + " mal");
            Console.WriteLine("Die 5 kam " + fuenf + " mal");
            Console.WriteLine("Die 6 kam " + sechs + " mal");
        }
        static void EinDimArray() {
            Random zufall;
            zufall = new Random();
            int anzahl = 10000;
            int gerollt;

            int[] werte = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Die Werte im Array");
            for (int index = 0; index < werte.Length; index++) {
                Console.WriteLine("Wert " + index + " = " + werte[index]);
            }

            Console.WriteLine("\n\n");

            int[] werte1 = new int[6];

            for (int index = 0; index < anzahl; index++) {
                gerollt = zufall.Next(1, 7);
                werte1[gerollt - 1]++;
            }

            for (int index = 0; index < werte1.Length; index++) {
                Console.WriteLine("Würfel " + (index + 1) + " = " + werte1[index]);
            }

            int[] werte3 = { 3, 5, 7, 1, 2, 4, 6, 9, 8 };
            Array.Sort(werte3);

            for (int index = 0; index < werte3.Length; index++) {
                Console.WriteLine("Wwert " + (index + 1) + " = " + werte3[index]);
            }

            Console.WriteLine("\n\n");

            for (int index = 0; index < werte3.Length; index++) {
                if (werte3[index] == 5) {
                    Console.WriteLine("Wwert " + (index + 1) + " = " + werte3[index]);
                }
            }

        }
        static void MehrDimArrays() {
            Random zufall;
            zufall = new Random(); // Erzeugt eine beliebige Zufallszahlenfolge

            int[][] MD_Array = new int[][] {
                new int[] {1,2,3,4,5},
                new int[] {2,4,6,8,10},
                new int[] {3,6,9,12,15},
                new int[] {4,8,12,16,20},
                new int[] {5,10,15,20,25}
            };
            Console.WriteLine("Länge des Arrays: " + MD_Array.Length + "\n");
            for (int aussen = 0; aussen < MD_Array.Length; aussen++) {
                for (int innen = 0; innen < MD_Array[aussen].Length; innen++) {
                    Console.WriteLine("Element " + aussen + "-" + innen + " : " + MD_Array[aussen][innen]);
                }
                Console.WriteLine();
            }

            // Array mit 25 Zeilen und 50 Spalten
            int[][] MD_Array1 = new int[25][];

            for (int zeile = 0; zeile < MD_Array1.Length; zeile++) {
                MD_Array1[zeile] = new int[50];
                for (int spalte = 0; spalte < MD_Array1[zeile].Length; spalte++) {
                    MD_Array1[zeile][spalte] = zufall.Next(1, 101);
                }
            }

            for (int aussen = 0; aussen < MD_Array1.Length; aussen++) {
                for (int innen = 0; innen < MD_Array1[aussen].Length; innen++) {
                    Console.Write(MD_Array1[aussen][innen] + " ");
                }
                Console.WriteLine();
            }
        }
        static void MehrDimSymArrays() {
            Random zufall;
            zufall = new Random(); // Erzeugt eine beliebige Zufallszahlenfolge

            // Array per Hand befüllen (WICHTIG: Keine Dimensionen bei der Deklaration)
            string[,] MeineStrings = new string[,] {
                {"Hugo", "Fred" },
                { "Susi", "Sabine" }
            };

            int zeilen = 3;
            int spalten = 5;
            int[,] MeinArray = new int[zeilen, spalten];

            Console.WriteLine(MeinArray.Length); // Gesamtlänge (Anz. Elemente) im Array = 15
            Console.WriteLine(MeinArray.GetLength(0)); // Anzahl Elemente in Zeilen = 3
            Console.WriteLine(MeinArray.GetLength(1)); // Anzahl Elemente in Spalten = 5
            Console.WriteLine(MeinArray.Length / MeinArray.GetLength(1)); // Errechnete Anzahl Zeilen = 3
            Console.WriteLine(MeinArray.Length / MeinArray.GetLength(0)); // Errechnete Anzahl Spalten = 5

            for (int zeile = 0; zeile < zeilen; zeile++) {
                for (int spalte = 0; spalte < spalten; spalte++) {
                    MeinArray[zeile, spalte] = zufall.Next(1, 101);
                }
            }

            for (int zeile = 0; zeile < zeilen; zeile++) {
                for (int spalte = 0; spalte < spalten; spalte++) {
                    Console.Write(MeinArray[zeile, spalte] + " ");
                }
                Console.WriteLine();
            }
        }
        static void MehrDimAsymArrays() {
            int[][] MD_Array = new int[][] {
                new int[] {1,2,3,4,5,6,7},
                new int[] {2,4,6,8,10},
                new int[] {3,6,9},
                new int[] {4,8,12,16,20,1,2,3,4,5},
                new int[4],
                new int[9],
                new int[2]
            };

            for (int aussen = 0; aussen < MD_Array.Length; aussen++) {
                for (int innen = 0; innen < MD_Array[aussen].Length; innen++) {
                    Console.Write(MD_Array[aussen][innen] + " ");
                }
                Console.WriteLine();
            }
        }

        static void ByValue(int MeinWert) {
            MeinWert = MeinWert + 1;
            Console.WriteLine("MeinWert IN der Methode: " + MeinWert);
        }
        static void ByReference(ref int MeinWert) {
            MeinWert = MeinWert + 1;
            Console.WriteLine("MeinWert IN der Methode: " + MeinWert);
        }
        static void ByReferenceArray(int[] MeinArray) {
            MeinArray[0] = MeinArray[0] + 1;
            Console.WriteLine("MeinWert IN der Methode: " + MeinArray[0]);
        }
        static void ByReferenceOut(out int MeinWert) {
            MeinWert = 5;
            MeinWert += 1;
            Console.WriteLine("MeinWert IN der Methode: " + MeinWert);
        }
        static void ByReferenceOutBeispiel(out int Summe, out int Quadrat, out int Differenz, int Basis = 5) {
            Summe = Basis + Basis;
            Quadrat = Basis * Basis;
            Differenz = Basis - Basis;
        }
        static void WasMitString(string MeinWert) {
            MeinWert = MeinWert + " Welt";
            Console.WriteLine("String IN der Methode: " + MeinWert);
        }

        //Call By Reference vs. Call By Value
        static void CBR_CBV() {
            int MeinWert = 1;

            Console.WriteLine("BY VALUE!");
            ByValue(MeinWert);
            Console.WriteLine("MeinWert IN der Main: " + MeinWert);

            Console.WriteLine("\nBY REFERENCE!");
            ByReference(ref MeinWert);
            Console.WriteLine("MeinWert IN der Main: " + MeinWert);

            Console.WriteLine("\nEIN ARRAY BY REFERENCE!");
            int[] MeinArray = { 1, 2, 3, 4 };
            ByReferenceArray(MeinArray);
            Console.WriteLine("MeinWert IN der Main: " + MeinArray[0]);

            Console.WriteLine("\nBY REFERENCE mit OUT");
            int MeinInt;
            ByReferenceOut(out MeinInt);
            Console.WriteLine("MeinWert IN der Main: " + MeinInt);

            Console.WriteLine("\nBY REFERENCE mit OUT Beispiel");
            int Basis = 15;
            int Summe, Quadrat, Differenz;

            ByReferenceOutBeispiel(out Summe, out Quadrat, out Differenz, Basis);
            Console.WriteLine("Die Summe: " + Summe);
            Console.WriteLine("Das Quadrat: " + Quadrat);
            Console.WriteLine("Die Differenz: " + Differenz);

            Console.WriteLine("\nWas ist mit Strings???");
            string MeinString = "Hallo";
            WasMitString(MeinString);
            Console.WriteLine(MeinString);
        }
    }
}
