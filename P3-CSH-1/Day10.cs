using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day10 : Day {
        public Day10() {
            addAufgabe("Tag 10 Mitschrift", Transcript);
        }
        public void Transcript() {
            Hund hund = new Hund("Hektor");
            hund.AusgabeName();
            hund.GibLaut();

            Console.WriteLine();

            Katze katze = new Katze("Bruno");
            katze.AusgabeName();
            katze.GibLaut();

            Console.WriteLine();
            Console.WriteLine();

            Tier hund2 = new Hund("Hundeli");
            hund2.AusgabeName();
            hund2.GibLaut();

            Console.WriteLine();

            Tier katze2 = new Katze("Miezi");
            katze2.AusgabeName();
            katze2.GibLaut();

            List<Tier> MeineTiere = new List<Tier>();

            MeineTiere.Add(hund);
            MeineTiere.Add(katze);
            MeineTiere.Add(hund2);
            MeineTiere.Add(katze2);

            Console.WriteLine();

            foreach (Tier element in MeineTiere) {
                element.GibLaut();
            }

            Tier katze3 = katze;
        }

        class Tier {
            int alter;
            public int gewicht;

            public int Alter {
                get { return alter; }
                set {
                    if (value < 1 || value > 50) {
                        Console.WriteLine("Das Tier hat ein merkwürdiges Alter");
                    } else {
                        alter = value;
                    }
                }
            }
            public string Name { get; set; }

            public Tier() {

            }

            public Tier(string name) {
                Name = name;
            }

            public virtual void AusgabeName() {
                Console.WriteLine("Das Tier hat den Namen: " + Name);
            }

            public virtual void GibLaut() {
                Console.WriteLine("GERÄUSCH");
            }
        }

        class Hund : Tier {
            public int HundeMerkmal { get; set; }

            public Hund(string name) {
                Name = name;
            }
            public new void AusgabeName() {
                Console.WriteLine("Der Hund hat den Namen: " + Name);
            }

            public void PureHundeMethod() {
                Console.WriteLine("Alles für den Hund");
            }

            public new void GibLaut() {
                Console.WriteLine("Wau Wau Wuff");
            }
        }

        class Katze : Tier {
            public int KatzenMerkmal { get; set; }
            public Katze(string name) {
                Name = name;
                KatzenMerkmal = 123;
            }
            public override void AusgabeName() {
                Console.WriteLine("Die Katze hat den Namen: " + Name);
                Console.WriteLine("Das Katzenmerkmal: " + KatzenMerkmal);
                PureKatzenMethode();
            }

            public void PureKatzenMethode() {
                Console.WriteLine("Alles für die Katz!");
            }

            public override void GibLaut() {
                Console.WriteLine("Miau Miau");
            }
        }

        class Sonstiges {
            public Sonstiges(string name) {

            }
        }
    }
}
