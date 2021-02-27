using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    struct Aufgabe {
        public string aufgabe;
        public Action method;
    }
    class Program {
        
        static void Main(string[] args) {
            new Day1();
            new Day2();
            new Day3();
            new Day4();
            new Day5();
            new Day6();
            new Day7();
            new Day8();
            new Day9();
            new Day10();
            new Day11();
            new Day12();
            new Day14();
            new Day15();
            new Day16();
            new Day19();

            Day.StartProg();
            Console.WriteLine("\n\n--- Ende ---");
            Console.ReadKey();
        }
    }

    class Day {
        protected int dayNumber;
        protected static List<Day> days = new List<Day>();
        protected List<Aufgabe> aufgaben = new List<Aufgabe>();

        public static List<Day> Days {
            get { return days; }
        }

        public List<Aufgabe> Aufgaben {
            get { return aufgaben; }
        }

        // Konstruktor
        public Day() {
            days.Add(this);
            dayNumber = days.Count;
        }

        public static void StartProg() {
            int auswahl;
            do {
                Console.Clear();
                Console.WriteLine("C# Programmieren 3");
                Console.Write("\nWähle einen Tag aus \n(1 - " + Days.Count + ", 0 = Ende)\n ");
                if (Int32.TryParse(Console.ReadLine(), out auswahl)) {
                    if (auswahl <= Days.Count && auswahl > 0) {
                        Days[auswahl - 1].startDay();
                    }
                } else auswahl = 1;
            } while (auswahl != 0);
        }

        public void startDay() {
            int auswahl;
            do {
                Console.Write(this + " ");
                if (Int32.TryParse(Console.ReadLine(), out auswahl)) {
                    Console.WriteLine();
                    if (auswahl <= aufgaben.Count && auswahl > 0) aufgaben[auswahl - 1].method();
                } else auswahl = 1;
            } while (auswahl != 0);
        }

        public override string ToString() {
            Console.WriteLine("\n\n\nTag " + dayNumber);
            string temp = "Bitte wählen (0 = Zurück / Beenden)\n";
            int zaehler = 1;
            foreach (Aufgabe item in aufgaben) {
                temp += "(" + zaehler + ") " + item.aufgabe + "\n";
                zaehler++;
            }
            return temp;
        }

        public void addAufgabe(string beschreibung, Action methode) {
            Aufgabe temp;
            temp.aufgabe = beschreibung;
            temp.method = methode;
            aufgaben.Add(temp);
        }
    }
}
