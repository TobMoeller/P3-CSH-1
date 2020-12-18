using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day4 : Day {
        public Day4() {
            addAufgabe("Tag 4 Mitschrift", Transcript);
        }

        public void Transcript() {
            /*
            Unsere Agenten haben der Gegenseite folgenden Code geklaut.

            Der chiffrierte Text
            --------------------
            185 147 152 208 146 153 158 208 149 153 158 208 147 159 148 153 149 130 132 149 130 208 164 149 136 132 208
            133 158 148 208 158 153 149 157 145 158 148 208 135 153 130 148 208 154 149 157 145 156 131 208 152 149 130
            145 133 131 150 153 158 148 149 158 220 208 135 153 149 208 157 145 158 208 157 153 147 152 208 149 158 132
            131 147 152 156 12 131 131 149 156 132 222 208 190 153 149 157 145 156 131 208 158 153 147 152 132

            Leider konnten unsere Agenten nix mit dem Code anfangen. Auch eine Befragung des gegnerischen
            Agenten, der den Code bei sich trug, brachte keine Erkenntnisse.Da die Lage ERNST ist, wurde
            der gegnerische Agent gefoltert, um ihn gesprächig zu machen. Aber es war ein eisenharter Bursche.
            Erst der Einsatz von Nacktfotos von Angela Merkel in Kombination mit Bildern von Heino ohne Sonnenbrille
            hatte den gewünschten Effekt. Kurz bevor er dem Wahnsinn verfiel brabbelte er:
            "3-stellige Zahl, deren *röchel* Quersumme 6 ist, *stammel* *stotter* XOR *hüstel*".
            Danach aß er die Fotos auf, sprach fortan kein Wort mehr und schaukelte in seinem Stuhl vor- und zurück.

            Da unsere Agenten zwar gewaltbereit, aber dumm wie Brot sind, haben Sie beschlossen, die Informationen
            an das Intelligence-Team (EUCH) weiter zu geben, weil sie weder mit dem Code, noch mit den Informationen
            des feindlichen Agenten irgendwie klar kamen.
            */
            Quersumme();

            Console.WriteLine("Die Quersummen:");
            foreach (int element in Quersummen) {
                Console.Write(element + " ");
            }

            Console.WriteLine("\n\n");

            for (int aussen = 0; aussen < Quersummen.Count; aussen++) {
                Console.WriteLine("Durchlauf mit der ersten Quersummenzahl: " + Quersummen[aussen]);
                for (int innen = 0; innen < chiffreEinzeln.Length; innen++) {
                    int.TryParse(chiffreEinzeln[innen], out int chiffreInt);
                    int ergebnis = chiffreInt ^ Quersummen[aussen];
                    Console.Write((char)ergebnis);
                }
                Console.WriteLine("\n");
            }
        }
            
        static string chiffre = "185 147 152 208 146 153 158 208 149 153 158 208 147 159 148 153 149 130 132 149 130 208 164 149 136 132 208 133 158 148 208 158 153 149 157 145 158 148 208 135 153 130 148 208 154 149 157 145 156 131 208 152 149 130 145 133 131 150 153 158 148 149 158 220 208 135 153 149 208 157 145 158 208 157 153 147 152 208 149 158 132 131 147 152 156 12 131 131 149 156 132 222 208 190 153 149 157 145 156 131 208 158 153 147 152 132";
        static string[] chiffreEinzeln = chiffre.Split(' ');
        static List<int> Quersummen = new List<int>();

        static void Quersumme() {
            int quersum = 0;
            int probe = 0;
            for (int index = 100; index < 1000; index++) {
                probe = index;
                quersum = 0;
                while (probe > 0) {
                    quersum += probe % 10;
                    probe = probe / 10;
                }
                if (quersum == 6) {
                    Quersummen.Add(index);
                }
            }
        }
    }
}
