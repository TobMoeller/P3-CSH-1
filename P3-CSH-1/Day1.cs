using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day1 : Day {
        public Day1() {
            addAufgabe("Testbeschreibung", Transcript);
            addAufgabe("Diesdas", Transcript);
        }

        
        public void Transcript() {
            int hugo = 5;
            string MeinText = "Hallo Welt";
            bool MeinBool = true;
            double MeinDouble = 1.234;

            Console.WriteLine("Hugo hat den Wert " + hugo + "Und mein Bool ist " + MeinBool);
            Console.WriteLine("MeinBool hat den Wert " + MeinBool);
            Console.WriteLine("MeinDouble hat den Wert " + MeinDouble);

            Console.WriteLine();
            Console.WriteLine("Bitte gib irgendwas ein!");
            string MeineEingabe = Console.ReadLine();
            Console.WriteLine("MeinEingabe hat den Wert " + MeineEingabe);

            Console.WriteLine();
            Console.WriteLine("Bitte gib eine ganze Zahl ein!");

            string MeineEingabe2 = Console.ReadLine();

            int Wert = 8;
            int Ergebnis_Convert = Convert.ToInt32(MeineEingabe2) + Wert;
            Console.WriteLine("Ergebnis_Convert hat den Wert " + Ergebnis_Convert);

            int Ergebnis_Parse = Int32.Parse(MeineEingabe2) + Wert;
            Console.WriteLine("Ergebnis_Parse hat den Wert " + Ergebnis_Parse);

            bool Ergebnis_TryParse = Int32.TryParse(MeineEingabe2, out int geparst);
            if (Ergebnis_TryParse == true) {
                Console.WriteLine("Ergebnis_TryParse hat den Wert " + geparst);
            } else {
                Console.WriteLine("GEHT NICHT!");
                Console.WriteLine("Ergebnis_TryParse hat den Wert " + geparst);
            }

            //string MeineEingabe_Cast = Console.ReadLine();
            //int erg = (int)MeineEingabe_Cast; // String kann NICHT in int gecasted werden

            double MDouble = 123.999;
            int erg = (int)MDouble;
            Console.WriteLine("erg ist " + erg);

            int Iwert = 123;
            double Derg = Iwert; // INT ist in DOUBLE enthalten. Daher keine Konvertierung erforderlich

            int w1 = 123;
            int w2 = 123;
            string s1 = " Hallo ";
            Console.WriteLine(s1 + w1 + w2); //startet mit String, dann ist der Rest auch string
            Console.WriteLine(w1 + s1 + w2); //erst int, dann string, Gesamtausdruck string
            Console.WriteLine(w1 + w2 + s1); //int, int, string führt erst eine Addition, dann eine Verkettung aus
            Console.WriteLine(w1 + "" + w2 + s1); //hier wird ein string mit "" eingebaut. Ergebnis: string
            Console.WriteLine(s1 + (w1 + w2));//Klammer-Regel greift. Erst Addition in der Klammer, dann string

            Console.WriteLine();
            Console.WriteLine("Bitte gib eine Kommazahl ein (mit , nicht mit .)!");
            string MeineEingabe3 = Console.ReadLine();
            int Wert1 = 8;
            double Ergebnis1 = Convert.ToDouble(MeineEingabe3) + Wert1;

            Console.WriteLine("Ergebnis hat den Wert " + Ergebnis1);

            Console.ReadKey(); //Am Ende immer ein Readkey
        }
    }
}
