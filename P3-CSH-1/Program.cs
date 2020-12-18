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
            Day tag1 = new Day1();
            Day tag2 = new Day2();
            Day tag3 = new Day3();
            Day tag4 = new Day4();
            Day tag5 = new Day5();
            Day tag6 = new Day6();
            Day tag7 = new Day7();
            Day tag8 = new Day8();
            Day tag9 = new Day9();
            Day tag10 = new Day10();
            Day tag11 = new Day11();
            Day tag12 = new Day12();
            //Day tag13 = new Day13();
            Day tag14 = new Day14();
            Day tag15 = new Day15();
            Day tag16 = new Day16();
            Day tag19 = new Day19();

            StartProg();
            Console.WriteLine("\n\n--- Ende ---");
            Console.ReadKey();
        }

        static void StartProg() {
            int auswahl;
            do {
                Console.Clear();
                Console.WriteLine("C# Programmieren 3");
                Console.Write("\nWähle einen Tag aus \n(1 - " + Day.Days.Count + ", 0 = Ende)\n ");
                if (Int32.TryParse(Console.ReadLine(), out auswahl)) {
                    if (auswahl <= Day.Days.Count && auswahl > 0) {
                        Day.Days[auswahl - 1].startDay();
                    }
                } else auswahl = 1;
            } while (auswahl != 0);
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
