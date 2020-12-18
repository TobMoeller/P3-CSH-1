using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day2 : Day {
        public Day2() {
            addAufgabe("Tag 2 Mitschrift", Transcript);
        }

        public void Transcript() {
            // Zum Einlesen werden wir die Funktion ReadLine() verwenden, die ebenfalls in der Klasse Console vorkommt.
            // Wir speichern den Rückgabewert der Funktion in einem String ab (Der Rückgabewert ist nämlich gerade die User-Eingabe)
            Console.Write("Geben Sie bitte einen Text ein: ");
            string text = Console.ReadLine();
            Console.WriteLine("Kontrollausgabe: Die Variable 'text' hat nun den Inhalt: " + text);

            // Falls vom User Texte abgefragt werden sollen, sind wir nun natürlich schon am Ziel

            //*************************************************************************************************************************
            // Abfrage von (ganzen) Zahlen
            // Hier nun kommt der 2. Teil unserer Thematik zum tragen, denn wir müssen den Text in eine Zahl konvertieren, wenn wir zum Beispiel damit rechnen wollen:
            // BEISPIEL: Abfrage einer Integer-Variable vom User
            Console.Write("\nBitte geben Sie eine ganze Zahl ein: ");
            text = Console.ReadLine();
            int zahl = Convert.ToInt32(text); // In der Klasse Convert befindet sich die Methode ToInt32, mit der wir den Übergabewert in einen 32-Bit-Integer übersetzen können

            Console.WriteLine("Kontrollausgabe: Die Variable 'text' wurde konvertiert, der Integer 'zahl' hat nun den Wert: " + zahl);

            // Nun kann mit der eingegebenen Zahl gearbeitet werden:
            if (zahl > 10)
                Console.WriteLine("Ihre Eingabe war größer als 10!");
            else
                Console.WriteLine("Ihre Eingabe war NICHT größer als 10!");

            // Bemerkung 1
            // Bei einer Eingabe, die dem Format nicht entspricht, in das konvertiert werden soll, bricht das Programm mit einer Fehlermeldung ab.
            // Bei Integer-Konvertierungen ist dann alles jenseits von Ziffern 0 bis 9 verboten (also nicht nur Buchstaben, sondern auch Kommata)
            // ACHTUNG: Auch Punkte sind verboten (die Eingabe 1.000.000 für 1 Millionen wäre also unzulässig)

            // Bemerkung 2
            // Wir können auf die (Zwischen-) Speicherung der User-Eingabe als String durch Verschachtelung verzichten
            Console.Write("\nGeben Sie bitte eine weitere ganze Zahl ein: ");
            zahl = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kontrollausgabe: zahl = " + zahl);

            // Bemerkung 3
            // Es kann verschiedene User-Eingabe-Fehler / Fehler bei der Konvertierung geben:
            // Falsche Zeichen: Format-Exception
            // Zu große Zahlen: Overflow-Exception


            //***************************************************************************************************************************
            // Abfrage von Kommazahlen
            Console.Write("\nBitte geben Sie eine Kommazahl ein: ");
            double d = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Kontrollausgabe: d = " + d);

            // Bemerkungen
            // Der User wird aufgefordert, die Kommazahl wirklich mit einem Komma einzugeben!
            // (Weil die deutsche Einstellung des Betriebssystems erkannt wird)

            // Lesbarkeits-Punkte (1.000.000 statt 1000000) sind erlaubt, werden aber leider nicht intelligent kontrolliert: 1...0..0 wird 100 konvertiert
            // Bei der AUSGABE (von z.B. 1 Millionen) schreibt er dann aber (leider) 1000000 und nicht 1.000.000
            // Siehe "FormatierungsStrings_ILP" für weitere Infos zu den Lesbarkeits-Punkten und der Ausgabe von Zahlen

            // Ganze Zahlen werden auch als solche ausgegeben
            // (intern ist für das Programm zwar z.B. 25 = 25,000... aber in der Ausgabe erscheint nur 25)

            // Man könnte sich die Frage stellen, warum man dann überhaupt noch mit Integern arbeiten sollte, wenn doch Double (scheinbar) deren "Job" übernehmen könnte.
            // Problem jedoch: Kommazahlen-Verwendung bedeutet immer auch Rundungsfehler und verbrauchen mehr Speicher 
            // => Wenn irgendwie möglich, sollte mit Integer gearbeitet werden

            //***************************************************************************************************************************
            // Eingabe von Character
            Console.Write("\nBitte geben Sie ein einzelnes Zeichen ein: ");
            char c = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Kontrollausgabe: Der Character c hat nun den Wert: " + c);

            // Bemerkung:
            // Eine Eingabe von mehreren Zeichen führt wieder zu einer Format-Exception

            // Alternative:
            Console.Write("Drücken Sie den Any-Key: ");
            c = Console.ReadKey().KeyChar;
            Console.WriteLine("\nKontrollausgabe: c = " + c);

            // Ausführlicher:
            ConsoleKeyInfo info = Console.ReadKey();
            c = info.KeyChar;

            Console.Write("\n\nDas Drücken einer beliebigen Taste beendet das Programm");
            Console.ReadKey();
        }
    }
}
