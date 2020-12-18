using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_CSH_1 {
    class Day6 : Day {
        public Day6() {
            addAufgabe("Tag 6 Mitschrift", Transcript);
        }
        public void Transcript() {
            //int test = Enumerationen();
            //if(test == (int)DerBool.IstTrue) {
            //    Console.WriteLine("Das " + DerBool.IstTrue);
            //} else {
            //    Console.WriteLine("Das ist false");
            //}

            //Autos();
            Strukturen();
        }

        enum DerBool { IstTrue = 2345, IstFalse = 123 };
        enum MeinEnum { NRW, Bayern, Hessen };
        enum MeinAuto { USA = 17, BRD = 18, ENGLAND = 16, SCHWEDEN = 17 }
        static int Enumerationen() {
            int MeinBool = (int)DerBool.IstFalse;

            string MeinString = Console.ReadLine();
            if (MeinString.Length == 5) {
                MeinBool = (int)DerBool.IstTrue;
            }
            return MeinBool;
        }
        static void Autos() {
            string[] laender = Enum.GetNames(typeof(MeinAuto));
            int[] alter = (int[])Enum.GetValues(typeof(MeinAuto));

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int index = 0; index < laender.Length; index++) {
                if (alter[index] == 17) {
                    Console.WriteLine("Führerschein ab 17 in Land: " + laender[index]);
                }
            }
        }

        struct MeinStruct {
            public string strasse;
            public string PLZ;
            public string Ort;

            public void StructMethode() {
                Console.WriteLine("Ich werde im Struct aufgerufen");
            }
        }
        static MeinStruct Aendern(MeinStruct wert1, MeinStruct wert2) {
            MeinStruct geaendert;
            geaendert.strasse = wert1.strasse;
            geaendert.PLZ = wert2.PLZ;
            geaendert.Ort = wert1.Ort;
            return geaendert;
        }
        static void Strukturen() {
            MeinStruct adresse1;
            adresse1.strasse = "Heimweg";
            adresse1.Ort = "Dortmund";
            adresse1.PLZ = "44123";

            MeinStruct adresse2 = new MeinStruct();
            adresse2.strasse = "Mustergasse";
            adresse2.Ort = "Bielefeld";
            adresse2.PLZ = "12345";

            MeinStruct ergebnis = Aendern(adresse1, adresse2);
            Console.WriteLine(ergebnis.strasse);
            Console.WriteLine(ergebnis.PLZ);
            Console.WriteLine(ergebnis.Ort);
            ergebnis.StructMethode();
        }
    }
}
