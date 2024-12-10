using System.Runtime.InteropServices;
using static System.Formats.Asn1.AsnWriter;

internal class program
{
    static Dictionary<string, int> klassement = new Dictionary<string, int>();

    private static void Main(string[] args)
    {
        bool close = true;

        do
        {
            Console.Clear();
            Console.WriteLine("Welkom bij het Klassement Beheer Systeem!");
            Console.WriteLine("Kies een optie uit het menu:");

            Console.WriteLine("1.Toon het klassement");
            Console.WriteLine("2. Zoek de score van een deelnemer");
            Console.WriteLine("3. Pas de score van een deelnemer aan of voeg een nieuwe deelnemer toe");
            Console.WriteLine("4. Toon de gemiddelde score");
            Console.WriteLine("5. Toon de deelnemer met de hoogste score");
            Console.WriteLine("6. Stop het programma");

            Console.Write("Maak uw keuze: ");

            string keuze = Console.ReadLine();
            switch (keuze)
            {
                case "1":
                    showKlassement();
                    break;
                case "2":
                    showScore();
                    break;
                case "3":
                    addOrUpdate();
                    break;

                case "4":
                    everageNumber();
                    break;

                case "5":
                    highestScore();
                    break;

                case "6":
                    Console.WriteLine("Bedankt voor het gebruiken van het Klassement Beheer Systeem. Tot ziens!");
                    close = false;
                    break;

            }
        } while (close);

    }

    private static void addOrUpdate()
    {
        Console.Write("Geef de naam van een deelnemer: ");
        string naam = Console.ReadLine();
        bool exists = klassement.ContainsKey(naam);
        Console.Write("Geef de nieuwe score: ");
        string score = Console.ReadLine();
        if (exists)
        {
            Console.WriteLine($"De score van {naam} is bijgewerkt naar {score} punten.");
            klassement[naam] = int.Parse(score);
        }
        else
        {
            klassement.Add(naam, int.Parse(score));
            Console.WriteLine($"{naam} is toegevoegd aan het klassement met {score} punten.");
        }
        Console.ReadKey();
    }

    private static void showScore()
    {
        Console.Write("Geef de naam van een deelnemer: ");
        string naam = Console.ReadLine();
        bool exists = klassement.ContainsKey(naam);
        if (exists)
        {
            Console.WriteLine($"{naam} heeft {klassement[naam]} punten.");
        }
        else
        {
            Console.WriteLine($"{naam} staat niet in het klassement.");
        }
        Console.ReadKey();
    }

    private static void showKlassement()
    {
        List<KeyValuePair<string, int>> list = klassement.ToList();
        foreach (KeyValuePair<string, int> pair in list)
        {
            Console.WriteLine($"- {pair.Key}: {pair.Value} punten");
        }
        Console.ReadKey();
    }

    private static void everageNumber()
    {
        double gemiddelde = klassement.Values.Average();
        Console.WriteLine($"De gemiddelde score van alle deelnemers is: {Math.Round(gemiddelde, 1)} punten.");
        Console.ReadKey();
    }

    private static void highestScore()
    {
        var hoogsteScore = klassement.OrderByDescending(x => x.Value).First();
        Console.WriteLine($"Deelnemer met de hoogste score: {hoogsteScore.Key} met {hoogsteScore.Value} punten");
        Console.ReadKey();
    }
}