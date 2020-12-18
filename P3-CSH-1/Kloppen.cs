using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Kloppen {
        public static void vermoebeln() {
            bool weiter = true;
            Krieger guenther = new Krieger(1000, "Günther", 700);
            Magier luise = new Magier(1200, "Luise", 600);
            do {
                luise.Feuerball(guenther);
                guenther.Anturm(luise);
                if (guenther.HP <= 0 || luise.HP <= 0) {
                    Console.WriteLine("Der Kampf ist vorbei");
                    weiter = false;
                } else if (guenther.Wut <= 0 && luise.MP <= 0) {
                    Console.WriteLine("Der Kampf ist vorbei, Unentschieden.");
                    weiter = false;
                }
            } while (weiter);
        }
    }

    class Charakter {
        protected int hp;
        protected string name;

        public Charakter(int hp) {
            this.hp = hp;
        }
        public void Bewegen() {
            Console.WriteLine("Move b*§%!, get out the way!");
        }

        public string Name {
            get { return name; }
        }

        public void SchadenErhalten(int schaden) {
            this.hp -= schaden;
            if (this.hp > 0) Console.WriteLine(this.name + "hat " + schaden + " genommen und ist bei " + this.hp + " Leben.");
            else Console.WriteLine(this.name + " ist gestorben.");
        }
        public int HP { get { return hp; } }
    }

    class Krieger : Charakter {
        public int Wut { get; set; }
        public Krieger(int hp, string name, int wut) : base(hp) {
            this.name = name;
            this.Wut = wut;
        }

        public void Anturm(Charakter ziel) {
            int schaden = 80;
            int kosten = 20;
            this.Wut -= kosten;
            if (this.Wut > 0) {
                Console.WriteLine("Angriff mit " + schaden + " Schaden auf " + ziel.Name);
                ziel.SchadenErhalten(schaden);
            } else {
                Console.WriteLine("Nicht genügend Wut");
            }
        }
    }

    class Magier : Charakter {
        public int MP { get; set; }
        public Magier(int hp, string name, int mp) : base(hp) {
            this.name = name;
            this.MP = mp;
        }

        public void Feuerball(Charakter ziel) {
            int schaden = 70;
            int kosten = 40;
            this.MP -= kosten;
            if (this.MP > 0) {
                Console.WriteLine("Angriff mit " + schaden + " Schaden auf " + ziel.Name);
                ziel.SchadenErhalten(schaden);
            } else {
                Console.WriteLine("Nicht genügend Mana");
            }
        }
    }
}
