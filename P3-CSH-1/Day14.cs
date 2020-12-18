using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day14 : Day {
        public Day14() {

        }

        public void Transcript() {

        }

        interface IInterface {
            // Interface werden mit einem großen i beginnend benannt
            // Interface schreibt vor, was man zu implementieren hat
            // Interfaces können keine Instanzfelder (wie Konstrukturen, Attribute etc.) enthalten
            int MyInt { get; set; }

            void MeineInterfaceMethode(); // ähnlich abstrakter Methode
            int MeineInterfaceMethode2();
        }

        class MeineKlasse : IInterface {
            private int einWert;
            public int MyInt { get; set; }
            public MeineKlasse() {

            }
            public void MeineInterfaceMethode() {

            }
            public int MeineInterfaceMethode2() {
                return 0;
            }
        }
    }
}
