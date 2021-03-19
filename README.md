# P3-CSH-1
Third programming class during retraining

## What is it about?

- making school notes
- solving school tasks
- sharing and collaborating with class mates
- showcasing some of my Code in C#

### Features

- Console Application
- Advanced object oriented way of the day-switching algorithm from the P2 class

### Technologies

- C# Console-App (.NET Framework)
- Visual Studio

---

## Small feature showcase

Here i tried to take an object oriented approach to the navigation method which i developed in the P2 course. You can have a look at the procedural version right [here](https://github.com/TobMoeller/P2-C-1).

I thought of a class that handles the navigation part. Off of this class each individual day inherits all needed attributes and methods:

```csharp
class Day {
    protected int dayNumber;
    protected static List<Day> days = new List<Day>();
    protected List<Aufgabe> aufgaben = new List<Aufgabe>();

    public static List<Day> Days {
        get { return days; }
    }

    public List<Aufgabe> Aufgaben {
        get { return aufgaben; }
    }

    // Konstruktor
    public Day() {
        days.Add(this);
        dayNumber = days.Count;
    }

    public static void StartProg() {
        int auswahl;
        do {
            Console.Clear();
            Console.WriteLine("C# Programmieren 3");
            Console.Write("\nWähle einen Tag aus \n(1 - " + Days.Count + ", 0 = Ende)\n ");
            if (Int32.TryParse(Console.ReadLine(), out auswahl)) {
                if (auswahl <= Days.Count && auswahl > 0) {
                    Days[auswahl - 1].startDay();
                }
            } else auswahl = 1;
        } while (auswahl != 0);
    }

    public void startDay() {
        int auswahl;
        do {
            Console.Write(this + " ");
            if (Int32.TryParse(Console.ReadLine(), out auswahl)) {
                Console.WriteLine();
                if (auswahl <= aufgaben.Count && auswahl > 0) aufgaben[auswahl - 1].method();
            } else auswahl = 1;
        } while (auswahl != 0);
    }

    public override string ToString() {
        Console.WriteLine("\n\n\nTag " + dayNumber);
        string temp = "Bitte wählen (0 = Zurück / Beenden)\n";
        int zaehler = 1;
        foreach (Aufgabe item in aufgaben) {
            temp += "(" + zaehler + ") " + item.aufgabe + "\n";
            zaehler++;
        }
        return temp;
    }

    public void addAufgabe(string beschreibung, Action methode) {
        Aufgabe temp;
        temp.aufgabe = beschreibung;
        temp.method = methode;
        aufgaben.Add(temp);
    }
}
```

Anytime i instantiate a new Day it gets added to the static `days` list from where i can easily navigate between them.

Each day has its own list of the struct `Aufgabe` which contains a delegate and a matching description of it. This list gets filled with the methods of each day.

```csharp
struct Aufgabe {
    public string aufgabe;
    public Action method;
}
```

I add the methods of each day by using the method `addAufgabe()` inside its constructor.

```csharp
class Day1 : Day {
    public Day1() {
        addAufgabe("Testbeschreibung", Transcript);
    }

    public void Transcript() {
    }
}
```
Finally i create an object of each day in the `Main()` and call the `StartProg` method to start the whole process.
