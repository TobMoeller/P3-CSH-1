using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day12 : Day {
        public Day12() {

        }

        public void Transcript() {

        }

        abstract class AbstrakteKlasse {
            private string meinText;
            // Abstrakte Attribute nicht erlaubt
            //private abstract string meinText2;
            public int MeineProperty { get; set; }
            // property und Methoden dürfen ohne Methodenrumpf abstrakt sein -> Zwingen erben die Methode mit override zu implementieren
            public abstract int MeineProperty2 { get; set; }
            public abstract void MeineMethode();
        }
        class AbstraktErbe : AbstrakteKlasse {
            public override int MeineProperty2 { get; set; }
            public override void MeineMethode() {
                Console.WriteLine("Mit Methodenrumpf");
            }
        }
    }
}
