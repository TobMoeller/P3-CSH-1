using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day15 : Day {
        public Day15() {
            addAufgabe("Tag 15 Mitschrift", Transcript);
            addAufgabe("Aufgabe 0", Aufgabe0);
            addAufgabe("Aufgabe 1", Aufgabe1);
            addAufgabe("Aufgabe 2", Aufgabe2);
        }

        delegate string MeinDelegatTyp(string a, string b);

        static string Methode1(string a, string b) {
            Console.WriteLine(a + " " + b);
            return a + " " + b;
        }
        static string Methode2(string a, string b) {
            Console.WriteLine(b + " " + a);
            return b + " " + a;
        }
        public void Transcript() {
            MeinDelegatTyp meinDelegat;
            meinDelegat = Methode1;
            meinDelegat += Methode2; // fügt die Methode2 zum Delegat hinzu
            Console.WriteLine(meinDelegat("Hallo", "Welt")); // Zurückgegeben wird aber nur die letzte Funktion mit return
            // Die andere Funktion wird dennoch ausgeführt, wenn diese eine Console.WriteLine enthielt, würde diese durchgeführt

            Console.WriteLine("\nWeiteres hinzufügen von Methoden");
            meinDelegat += Methode1;
            meinDelegat += Methode2;
            meinDelegat += Methode2;
            meinDelegat("Hallo", "Welt");

            meinDelegat -= Methode1;
            Console.WriteLine("\nNach -="); // Entfernt die zuletzt hinzugefügte Methode
            // Wenn die Methode nicht mehr enthalten ist, wird das -= ignoriert
            meinDelegat("Hallo", "Welt");

            DelegatAufruf(meinDelegat);

        }

        void DelegatAufruf(MeinDelegatTyp del) {
            del("Curry", "Wurst");
        }

        /* Aufgabe 0 (Basics)
        * void Delegate "Aktion" ohne Parameter 
        * Klasse "Sportler" mit void Methode "FühreAktionAus", welche als Parameter eine Aktion erwartet und die Aktion ausführt.
        * In der Klasse "Program":
        * Void Methode "Schwimmen" ohne Parameter: gibt auf der Konsole "Ich schwimme." aus.
        * Void Methode "Laufen" ohne Parameter: gibt auf der Konsole "Ich laufe." aus.
        * In der Main:
        * Erstellen Sie einen Sportler, rufen Sie "FühreAktionAus" auf und übergeben Sie einmal "Schwimmen" und einmal "Laufen".
        */
        public void Aufgabe0() {
            Sportler sportler = new Sportler();
            sportler.FuehreAktionAus(Schwimmen);
            sportler.FuehreAktionAus(Laufen);
        }
        delegate void Aktion();
        class Sportler {
            public void FuehreAktionAus(Aktion aktion) {
                aktion();
            }
        }
        public void Schwimmen() {
            Console.WriteLine("Ich schwimme.");
        }
        public void Laufen() {
            Console.WriteLine("Ich laufe.");
        }

        /*
         *  - Erstellen Sie in der Klasse Program den Delegate "Ausgabe", der als Parameter ein String Array erhält
         *  - Erstellen Sie die drei void Methoden Bildschirm, Datei und Datenbank für den Delegate
         *      (d.h. gleiche Parameter)
         *  - Die drei Methoden sollen jeden String im Array testweise auf der Konsole ausgeben, 
         *      wobei die Methoden zur Unterscheidung auch das Ziel der Ausgabe mit ausgeben sollen
         *      z.B. Console.WriteLine("Schreibe {0} in die Datenbank...", daten[i]);
         *  - Testen Sie die Methoden und den Delegate im Main, indem Sie dort ein String Array anlegen,
         *      dem Delegate die Methoden zuweisen und aufrufen.
         */

        public void Aufgabe1() {
            string[] meinArray = new string[] { "Test1", "Test2", "Test3" };
            Ausgabe meineAusgabe;
            meineAusgabe = Bildschirm;
            meineAusgabe += Datei;
            meineAusgabe += Datenbank;
            meineAusgabe(meinArray);
        }

        delegate void Ausgabe(string[] text);
        public void Bildschirm(string[] text) {
            foreach (string item in text) {
                Console.WriteLine("Schreibe " + item + " auf den Bildschirm");
            }
        }
        public void Datei(string[] text) {
            foreach (string item in text) {
                Console.WriteLine("Schreibe " + item + " in die Datei");
            }
        }
        public void Datenbank(string[] text) {
            foreach (string item in text) {
                Console.WriteLine("Schreibe " + item + " in die Datenbank");
            }
        }

        /*
            - Führen Sie bitte zunächst einen Delegaten namens 'MeinDelegat' ein (übergabewerte: 2 Strings, Rückgabewert: bool)
            - Führen Sie bitte ferner die 4 folgenden Methoden ein:
                a) Name:            A_IstLängerAls_B
                   Übergabewerte:   2 Strings A und B
                   Funktion:        Ermittelt die Länge beider Strings 
                   Rückgabewert:    true, FALLS A länger als B, SONST false 
                b) Name:            A_hatMehrEAls_B
                   Übergabewerte:   2 Strings A und B
                   Funktion:        Ermittelt die Anzahl der (großen oder kleinen) E´s beider Strings 
                   Rückgabewert:    true, FALLS A mehr E´s (bzw. e´s) als B hat, SONST false  
                c) Name:            Sortiere
                   Übergabewerte:   String-Array und eine Delegat vom Typ MeinDelegat
                   Funktion:        Sortiert das Array nach dem Bubblesort-Verfahren bzgl. des übergebenen Delegats [siehe Erläuterung(*)]
                   Rückgabewert:    keiner 
                d) Name:            Ausgabe
                   Übergabewerte:   String-Array
                   Funktion:        Konsolenausgabe aller Felder (wählen Sie selbst ein Layout nach ihren Vorlieben :-)
                   Rückgabewert:    keiner

            Im Main
               Führen Sie bitte zunächst ein String-Array  'arr'  ein, gefüllt mit den folgenden drei Strings: "Beere","Autobahnpolizist","Tee"
               Lassen Sie den aktuellen Inhalt des Arrays bitte auf der Konsole ausgeben
               Führen Sie bitte ferner ein Delegat  d  vom Typ MeinDelegat ein und initialisieren dieses mit dem Verweis auf  A_IstLängerAls_B
               Rufen Sie anschließend bitte die Methode Sortiere auf (Übergabewerte arr und d)
               Lassen Sie bitte erneut den aktuellen Inhalt des Arrays auf der Konsole ausgeben
               Überschreiben Sie daraufhin bitte d mit dem Verweis auf  A_hatMehrEAls_B
               Rufen Sie daraufhin bitte erneut die Methode Sortiere auf (Übergabewerte arr und d)
               Lassen Sie bitte auch diesmal den aktuellen Inhalt des Arrays auf der Konsole ausgeben

            (*)ERLÄUTERUNG:
               Beim Bubblesort wird pro Durchlauf der inneren Schleife entschieden, ob für zwei benachbarte Elemente 'A' und 'B' gilt: A>B ...
               ... A>B ist eine Frage der Betrachtung: Es kann alphabetisch gemeint sein, oder bzgl. der Wortlänge, oder der Anzahl der E´s ...
               Genau dies kann durch den übergebenen Delegaten entschieden werden!

        */

        public void Aufgabe2() {
            //Console.WriteLine(A_IstLaengerAls_B("testi", "testiii") ? "korrekt" : "falsch");
            //Console.WriteLine("Zähler: " + "teset".Count(c => c == 'e'));
            //Console.WriteLine(A_hatMehrEAls_B("testE", "test") ? "korrekt" : "falsch");
            string[] arr = new string[] { "Beere", "Autobahnpolizist", "Tee" };
            Ausgabe2(arr);

            MeinDelegat d = A_IstLaengerAls_B;
            Sortiere(arr, d);
            Ausgabe2(arr);

            d = A_hatMehrEAls_B;
            Sortiere(arr, d);
            Ausgabe2(arr);
        }

        public delegate bool MeinDelegat(string text1, string text2);

        // Teil a)
        public bool A_IstLaengerAls_B(string A, string B) {
            return A.Length > B.Length;
        }

        // Teil b)
        public bool A_hatMehrEAls_B(string A, string B) {
            bool testc(char c) {
                return c == 'e' || c == 'E';
            }
            return A.Count(c => testc(c)) > B.Count(c => testc(c));
        }

        // Teil c)
        public void Sortiere(string[] texte, MeinDelegat delegat) {
            bool weiter = true;
            delegat = (a, b) => { return a.Length > b.Length;  };
            while (weiter) {
                weiter = false;
                for (int i = 0; i < texte.Length - 1; i++) {
                    if (delegat(texte[i], texte[i + 1])) {
                        string temp = texte[i];
                        texte[i] = texte[i + 1];
                        texte[i + 1] = temp;
                        weiter = true;
                    }
                }
            }
        }

        // Teil d)
        public void Ausgabe2(string[] texte) {
            Console.WriteLine();
            for (int i = 0; i < texte.Length; i++) {
                Console.WriteLine("Text" + i + ": " + texte[i]);
            }
        }
    }
}
