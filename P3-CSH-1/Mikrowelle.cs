using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Mikrowelle {
        private bool tuerGeschlossen;

        public void toggleTuere() {
            if (tuerGeschlossen) {
                tuerGeschlossen = false;
                Console.WriteLine("Tür geöffnet");
            } else {
                tuerGeschlossen = true;
                Console.WriteLine("Tür geschlossen");
            }
        }

    }
}
