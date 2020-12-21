using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day19 : Day {
        public Day19() {
            addAufgabe("BSP Übung 1", bausteinPruefung1);
            addAufgabe("BSP Übung 2", bausteinPruefung2);
            addAufgabe("BSP Übung 3", bausteinPruefung3);
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


        /*
         * 
         *      BSP Übungen 2
         *      CSHG2, Nr. 3b)
         */

        public void bausteinPruefung2() {
            ColorChanger colorChanger = new ColorChanger();
            UserInput userInput = new UserInput();
            userInput.KeyPressed += colorChanger.SetColor;
            Console.WriteLine("Text in StandardFarbe");
            userInput.StartInput();
        }

        class ColorChanger {
            public ConsoleColor ForegroundColor { get; set; }
            public ColorChanger() {
                ForegroundColor = Console.ForegroundColor;
            }
            public void SetColor(ConsoleKeyInfo k) {
                switch (k.Key) {
                    case ConsoleKey.B:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case ConsoleKey.C:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case ConsoleKey.G:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case ConsoleKey.M:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case ConsoleKey.R:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    default:
                        Console.ForegroundColor = ForegroundColor;
                        break;
                }
            }
        }

        class UserInput {
            public delegate void KeyPressedEventHandler(ConsoleKeyInfo k);
            public event KeyPressedEventHandler KeyPressed;

            public void StartInput() {
                ConsoleKeyInfo temp;
                while (true) {
                    temp = Console.ReadKey(true);
                    KeyPressed?.Invoke(temp);
                    Console.WriteLine("Text in neuer Farbe");
                }
            }
        }

        /*
         * 
         *      BSP Übungen 3
         *      CSHG2 3a)
         * 
         */

        public void bausteinPruefung3() {
            Möbel möbel = new Möbel();
            Werkzeug werkzeug = new Werkzeug();
            Console.WriteLine("Möbel Guid: " + möbel.Inventarnummer + "\nWerkzeug Guid: " + werkzeug.Inventarnummer);
        }

        interface IInventar {
            Guid Inventarnummer { get; set; }
            void Aufnahme();
        }

        static class Inventarverwaltung {
            public static void Aufnahme(IInventar obj) {
                obj.Inventarnummer = Guid.NewGuid();
            }
        }

        abstract class Gebrauchsgut : IInventar {
            public Guid Inventarnummer { get; set; }
            public void Aufnahme() {
                Inventarverwaltung.Aufnahme(this);
            }
            public Gebrauchsgut() {
                Aufnahme();
            }
        }

        class Möbel : Gebrauchsgut {

        }

        class Werkzeug : Gebrauchsgut {

        }
    }
}
