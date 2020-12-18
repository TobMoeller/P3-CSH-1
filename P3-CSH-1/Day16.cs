using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day16 : Day {
        public Day16() {
            addAufgabe("Einschub Func/Action/Predicate", Einschub);
            addAufgabe("Tag 16 Mitschrift", Transcript);
            addAufgabe("Aufgabe 0", Aufgabe0);
            addAufgabe("Aufgabe 2", Aufgabe2);
            addAufgabe("Aufgabe 3", Aufgabe3);
            addAufgabe("Aufgabe 4", Aufgabe4);
        }

        // -------------------------------
        // Einschub: Func / Action / Predicate
        // -------------------------------

        public void Einschub() {
            List<string> MeineStrings = new List<string>();
            MeineStrings.Add("Anton");
            MeineStrings.Add("Susi");
            MeineStrings.Add("Fred");
            MeineStrings.Add("Anna");

            Predicate<string> SuchMich = param => param == "Anna";
            //SuchMich = Suche;
            string erg0 = MeineStrings.Find(SuchMich);
            string erg1 = MeineStrings.Find(Suche);
            string erg2 = MeineStrings.Find(item => item == "Anna");

            Console.WriteLine(erg0 + "      " + erg1 + "     " + erg2 + "\n");

            Funktion = Rechne;
            Console.WriteLine(Funktion("Hallo") + "\n");

            Aktion = Addiere;
            Aktion(3, 5);

            Console.WriteLine();

            Praedikat = TrueFalse;
            Console.WriteLine(Praedikat(5));

            Console.WriteLine("\n");
            Console.WriteLine(Zeichen('+')(2, 7));
            Console.WriteLine("\n");
            Console.WriteLine(Zeichen('-')(2, 7));
            Console.WriteLine("\n");
            Console.WriteLine(Zeichen('*')(2, 7));
            Console.WriteLine("\n");
            Console.WriteLine(Zeichen('/')(2, 7));
        }
        // Ein Func<> kann ziemlich viele Typen aufnehmen (bis zu 16). Der LETZTE Typ ist der Rückgabewert
        public static Func<string, int> Funktion;

        // Eine Action<> kann ziemlich viele Typen aufnehmen (bis zu 16) und hat KEINEN Rückgabewert
        public static Action<int, int> Aktion;

        // Ein Predicate<> nimmt EINEN Typ als Parameter an und gibt einen bool zurück.
        public static Predicate<int> Praedikat;

        public static int Rechne(string wert) {

            return wert.Length;
        }
        public static void Addiere(int wert1, int wert2) {
            Console.WriteLine(wert1 + wert2);
        }

        public static bool TrueFalse(int wert) {
            if (wert > 10) {
                return true;
            } else {
                return false;
            }
        }

        public static bool Suche(string wert) {
            if (wert == "Anna") {
                return true;
            } else {
                return false;
            }
        }

        public static Func<int, int, double> Zeichen(char z) {
            switch (z) {
                case '+': return ((int var1, int var2) => var1 + var2);
                case '-': return ((int var1, int var2) => var1 - var2);
                case '*': return ((int var1, int var2) => var1 * var2);
                case '/': return ((int var1, int var2) => (var2 != 0 ? (double)var1 / var2 : 0));
                default: return ((int var1, int var2) => 0);
            }
        }

        // -------------------------------
        // Mitschrift
        // -------------------------------
        public void Transcript() {
            Sender MeinSender = new Sender();
            Empfaenger MeinEmpfaenger = new Empfaenger(MeinSender);

            MeinSender.Arbeite();
        }

        
        class Sender {
            public delegate void MeinHandler();
            public event MeinHandler ZeigerAufFunktion;

            // Kürzere Schreibweise mit Systemfunktion "EventHandler"
            // benötigt object sender und EventArgs (kommt noch)
            // public event EventHandler ZeigerAufFunktion;
            
            public Sender() {
                // die eigene Klasse darf direkt dem Event zuweisen
                ZeigerAufFunktion = RufMichAuf;
            }
            public void RufMichAuf() {
                Console.WriteLine("Ich werde intern im Sender aufgerufen");
            }
            public void Arbeite() {
                for (int index = 0; index < 20; index++) {
                    Console.WriteLine("Index: " + index);
                    if (index % 2 == 0) {
                        ZeigerAufFunktion();
                    }
                }
            }
        }
        class Empfaenger {
            public Empfaenger(Sender sender) {
                // Abonnieren des events
                sender.ZeigerAufFunktion += Reaktion;
            }
            public void Reaktion() {
                Console.WriteLine("Ich bin eine Reaktion auf das Event");
            }
        }
        // -------------------------------
        // Aufgaben
        // -------------------------------

        /* Aufgabe 0 (Basics)
         * Klasse "Person"
         * - mit einem public void Delegaten "FeuerEventHandler" ohne Parameter
         * - einem passenden Event "FeuerGerufen"
         * - einer void Methode "FeuerRufen()", welche "Feuer!" auf der Konsole ausgibt, das Event auf null prüft und auslöst.
         * Klasse "Feuerwehrmann"
         * - mit einer void Methode "FeuerLöschen()" ohne Parameter, welche auf der Konsole "Feuer löschen!" ausgibt.
         * 
         * In der Main:
         * Eine Person und einen Feuerwehrmann erstellen. Der Feuerwehrmann abonniert das "FeuerGerufen"-Event der Person mit seiner "FeuerLöschen"-Methode. Starten Sie die "FeuerRufen" Methode der Person.
         */
        public void Aufgabe0() {
            Person person = new Person();
            Feuerwehrmann feuerwehrmann = new Feuerwehrmann(person);
            person.FeuerRufen();
        }
        class Person {
            public delegate void FeuerEventHandler();
            public event FeuerEventHandler FeuerGerufen;
            public void FeuerRufen() {
                Console.WriteLine("Feuer!");
                FeuerGerufen?.Invoke();
            }
        }
        class Feuerwehrmann {
            public Feuerwehrmann(Person person) {
                person.FeuerGerufen += FeuerLoeschen;
            }
            public void FeuerLoeschen() {
                Console.WriteLine("Feuer löschen!");
            }
        }

        /* Schreiben Sie folgendes C# Programm:
         * Sie haben eine "KI" in Ihrem Einkaufzentrum im Einsatz. 
         * Jedes mal, wenn der Sensor an der Tür einen neuen Kunden bemerkt, soll die "KI" den Kunden grüßen.
         * 
         * Das werden wir durch verschiedene Klassen simulieren.
         * Der Sender des Events ist das Einkaufzentrum mit dem Sensor.
         * Dort wird ein Delegat (NeuerKundeEventHandler) mit Void und ohne Parameter definiert.
         * Mit dem Delegaten wird das Event NeuerKundeHatDasGebäudeBetreten erzeugt.
         * Die öffentliche Methode NeuerKundeBetrittDasGebäude löst das Event aus.
         * 
         * Empfänger für das Event sind die Klassen Mitarbeiter und Geschäftsführer. 
         * Ja, das Einkaufzentrum wird von einer KI geführt.
         * Um nun allen Empfängern die Methode, mit der sie auf das Event reagieren können, vorzuschreiben (das macht das Abonnieren leichter),
         * implementieren wir das Interface IMitarbeiterBegrüßenKunde, welches über die Methode Grüßen() verfügt.
         * Die Grüßen-Methode macht nichts anderes, als testweise eine Begrüßung auf dem Bildschirm auszugeben.
         * Da die KI japanisch ist, sagt sie "Irasshaimase!" als Mitarbeiter und "Irasshaimase!!!" als Geschäftsführer.
         * Zum Schluss erstellen wir in der Main ein paar Objekte unserer Klassen, abonnieren das Event und lassen einen Kunden in das Gebäude.
         * 
         */

        public void Aufgabe2() {
            Einkaufzentrum einkaufzentrum = new Einkaufzentrum();
            Mitarbeiter mitarbeiter = new Mitarbeiter(einkaufzentrum);
            Geschaeftsfuehrer geschaeftsfuehrer = new Geschaeftsfuehrer(einkaufzentrum);
            einkaufzentrum.NeuerKundeBetrittDasGebaeude();
        }
        class Einkaufzentrum {
            public delegate void NeuerKundeEventHandler();
            public event NeuerKundeEventHandler NeuerKundeHatDasGebaeudeBetreten;
            public NeuerKundeEventHandler GetNeuerKundeHatDasGebaeudeBetreten() {
                return NeuerKundeHatDasGebaeudeBetreten;
            }
            public void NeuerKundeBetrittDasGebaeude() {
                NeuerKundeHatDasGebaeudeBetreten?.Invoke();
            }
        }
        interface IMitarbeiterBegrueßenKunde {
            void Grueßen();
        }
        class Mitarbeiter : IMitarbeiterBegrueßenKunde {
            public Mitarbeiter(Einkaufzentrum einkaufzentrum) {
                einkaufzentrum.NeuerKundeHatDasGebaeudeBetreten += Grueßen;
            }
            public void Grueßen() {
                Console.WriteLine("Irasshaimase!");
            }
        }
        class Geschaeftsfuehrer : IMitarbeiterBegrueßenKunde {
            public Geschaeftsfuehrer(Einkaufzentrum einkaufzentrum) {
                einkaufzentrum.NeuerKundeHatDasGebaeudeBetreten += Grueßen;
            }
            public void Grueßen() {
                Console.WriteLine("Irasshaimase!!!");
            }
        }

        /* Schreiben Sie folgendes C# Programm:
         * Sie entwickeln einen Video Encoder und möchten, wenn das Encoding abgeschlossen ist, 
         * eine Nachricht an den Benutzer über verschiedene Kanäle (Drucker, SMS, Email) verschicken.
         * 
         * Zuerst führen wir die Klasse Video ein, die über die öffentliche Property Name und einen Konstruktor verfügt.
         * 
         * Um dem Benutzer Informationen über das Encoding mitteilen zu können, brauchen wir eine eigene
         * EventArgs Klasse, die wir VideoEventArgs nennen und die von EventArgs erben wird.
         * VideoEventArgs hat die beiden Properties Video und Zeit, mit öffentlichen Gettern und privaten Settern.
         * Im Konstruktor der VideoEventArgs wird das Video übergeben und der Property zugewiesen. 
         * Zeit wird auf die aktuelle Zeit gesetzt.
         *  
         * Das Encoding werden wir in der Klasse VideoEncoder simulieren.
         * Dort wird als erstes ein Event vom Typ EventHandler<VideoEventArgs> angelegt. 
         * Die Angabe in den spitzen Klammern ist der Typ unserer EventArgs.
         * Der Encoder verfügt weiterhin über die Void-Methode "Encode" die als Übergabewert ein Video-Objekt erhält.
         * In der Methode werden zwei Bildschirmausgaben gemacht, die den Start und das Ende des Encodings darstellen
         * und anschließend wird das Event aufgerufen.
         * 
         * Die Empfänger des Events sind die Klassen MailService, PrinterService und SMSService.
         * Alle drei Klassen verfügen über die Methode "OnVideoEncoded", in der Informationen zum Sender, 
         * Empfänger ("Verschicke SMS..." zum Beispiel) und die Daten der EventArgs ausgegeben werden.
         * 
         * In der Main instanziieren wir nun je ein Objekt vom Typ Video, Encoder, MailService, PrinterService und SMSService.
         * Das Event des Encoders wird mit den OnVideoEncoded Methoden abonniert und das Encoding gestartet.
         * 
         */

        public void Aufgabe3() {
            Video video = new Video("Flipper");
            VideoEncoder videoEncoder = new VideoEncoder();
            MailService mailService = new MailService(videoEncoder);
            PrinterService printerService = new PrinterService(videoEncoder);
            SMSService sMSService = new SMSService(videoEncoder);

            videoEncoder.Encode(video);

            video = new Video("Kap und Kapper");
            videoEncoder.Encode(video);
        }
        class Video {
            public string Name { get; set; }
            public Video(string name) {
                this.Name = name;
            }
        }
        class VideoEventArgs : EventArgs {
            public Video Video { get; private set; }
            public DateTime Zeit { get; private set; }
            public VideoEventArgs(Video video) {
                this.Video = video;
                Zeit = DateTime.Now;
            }
        }
        class VideoEncoder {
            public event EventHandler<VideoEventArgs> MeinHandler;
            public void Encode(Video video) {
                Console.WriteLine("\n\nEncoding startet");
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("Encoding beendet");
                VideoEventArgs args = new VideoEventArgs(video);
                MeinHandler?.Invoke(this, args);
            }
        }

        // Empfaenger

        class MailService {
            public MailService(VideoEncoder videoEncoder) {
                videoEncoder.MeinHandler += OnVideoEncoded;
            }
            public void OnVideoEncoded(object sender, VideoEventArgs args) {
                Console.WriteLine("\nVerschicke E-Mail: Video " + args.Video.Name + " wurde encodiert um: " + args.Zeit);
            }
        }
        class PrinterService {
            public PrinterService(VideoEncoder videoEncoder) {
                videoEncoder.MeinHandler += OnVideoEncoded;
            }
            public void OnVideoEncoded(object sender, VideoEventArgs args) {
                Console.WriteLine("\nDrucke: Video " + args.Video.Name + " wurde encodiert um: " + args.Zeit);
            }
        }
        class SMSService {
            public SMSService(VideoEncoder videoEncoder) {
                videoEncoder.MeinHandler += OnVideoEncoded;
            }
            public void OnVideoEncoded(object sender, VideoEventArgs args) {
                Console.WriteLine("\nVerschicke SMS: Video " + args.Video.Name + " wurde encodiert um: " + args.Zeit);
            }
        }


        /* Klasse CIA
         * - Delegaten "TextanalyseEventHandler": void mit string Parameter
         * - Event "GefährlichesWortGefunden"
         * - Methode "Textanalyse": void mit string text und string suche als Parameter
         *      Prüft, ob suche in text vorhanden ist. Wenn ja, wird das Event ausgelöst.
         * 
         * Klasse SWAT
         * - Methode "Einsatz": void mit string grund als Parameter
         *      Gibt grund + "! GO! GO! GO!" auf der Konsole aus
         * 
         * Klasse FoxNews
         * - Methode "Eilmeldung": void mit string grund als Parameter
         *      Gibt grund auf der Konsole aus
         * 
         * Im Main: CIA, SWAT und FoxNews instanziieren, Event mit Einsatz und Eilmeldung abonnieren und Textanalyse aufrufen. 
         * 
         */

        public void Aufgabe4() {

        }

        class CIA {
            public delegate void TextanalyseEventHandler(string text);
            public event TextanalyseEventHandler GefaehrlichesWortGefunden;
        }
    }
}
