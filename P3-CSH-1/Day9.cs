using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day9 : Day {
        public Day9() {
            addAufgabe("Tag 9 Mitschrift", Transcript);
        }
        public void Transcript() {
            //Wiederholen();

            HauptKlasse haupt = new HauptKlasse("Ich bleibe in der HauptKlasse");
            Console.WriteLine();
            UnterKlasse unter = new UnterKlasse("Ich bleibe in der UnterKlasse", "Ich gehe zur HauptKlasse");
            Console.WriteLine();

            //haupt.hauptAusgabePublic();
            //unter.unterAusgabePublic();
            //haupt.hauptInt = 5;
            //unter.unterInt = 10 + haupt.hauptInt;
            //Console.WriteLine(unter.unterInt);

            NebenKlasse neben = new NebenKlasse("Ich bleibe in der NebenKlasse",
                                                "Ich gehe zur UnterKlasse", "Ich gehe zur HauptKlasse");
            Console.WriteLine();
            //neben.hauptAusgabePublic();
            //neben.unterAusgabePublic();

            NebenKlasse nebenInt = new NebenKlasse(100);
            Console.WriteLine(nebenInt.universalInt);

            UnterKlasse UnterInt = new UnterKlasse(250);
            Console.WriteLine(UnterInt.universalInt);
        }
        static void Wiederholen() {
            Wiederholung DasObjekt = new Wiederholung(55);
            int erg = DasObjekt.GetmeinInt();
            Console.WriteLine(erg);
            DasObjekt.SetmeinInt(75);

            erg = DasObjekt.GetmeinInt();
            Console.WriteLine(erg);
        }
        class Wiederholung {
            int meinInt;

            public Wiederholung(int wert) {
                SetmeinInt(wert);
            }

            public int GetmeinInt() {
                return meinInt;
            }

            public void SetmeinInt(int param) {
                if (param > 100) {
                    Console.WriteLine("Der Wert ist zu groß");
                } else if (param < 50) {
                    Console.WriteLine("Der Wert ist zu klein");
                } else {
                    meinInt = param;
                }
            }

            public int MeinInt {
                get { return meinInt; }
                set {
                    if (value > 100) {
                        Console.WriteLine("Der Wert ist zu groß");
                    } else if (value < 50) {
                        Console.WriteLine("Der Wert ist zu klein");
                    } else {
                        meinInt = value;
                    }
                }
            }

            private int testvar;
            public int Testvar { get => testvar; set => testvar = value; }

            public int Test { get; set; }
        }

        class HauptKlasse {
            //        public int hauptInt;

            public int universalInt;

            public HauptKlasse(string hauptparam) {
                Console.WriteLine("Konstruktor der HauptKlasse mit dem Parameter " + hauptparam);
            }
            public HauptKlasse(int param) {
                Console.WriteLine("Konstruktor der HauptKlasse mit dem INT-Parameter " + param);
                universalInt = param;
            }
            public void hauptAusgabePublic() {
                Console.WriteLine("Public Grüße aus der HauptKlasse");
            }
            private void hauptAusgabePrivate() {
                Console.WriteLine("Private Grüße aus der HauptKlasse");
            }
            protected void hauptAusgabeProtected() {
                Console.WriteLine("Protected Grüße aus der HauptKlasse");
            }
        }

        class UnterKlasse : HauptKlasse {
            //        public int unterInt;

            public UnterKlasse(string unterparam, string durchreichenHaupt) : base(durchreichenHaupt) {
                Console.WriteLine("Konstruktor der UnterKlasse mit dem Parameter " + unterparam);
            }
            public UnterKlasse(int param) : base(param) {
            }
            public void unterAusgabePublic() {
                hauptAusgabeProtected();
                Console.WriteLine("Grüße aus der UnterKlasse");
            }
        }

        class NebenKlasse : UnterKlasse {
            //        public int nebenInt;

            public NebenKlasse(string nebenparam, string durchreichenUnter, string durchreichenHaupt) :
                                base(durchreichenUnter, durchreichenHaupt) {
                Console.WriteLine("Konstruktor der NebenKlasse mit dem Parameter " + nebenparam);
            }
            public NebenKlasse(int param) : base(param) {
            }
            private void nebenAusgabePrivat() {
                Console.WriteLine("Private Grüße aus der NebenKlasse");
            }
            public void nebenAusgabePublic() {
                hauptAusgabeProtected();
                unterAusgabePublic();
            }
        }
    }
}
