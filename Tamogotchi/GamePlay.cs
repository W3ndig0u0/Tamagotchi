using System;
using System.IO;

namespace Tamogotchi
{
  public class GamePlay
  {

    public static void GamePlayMethod()
    {

      Words words = new Words();
      Tamo tamogotchi = new Tamo();
      string namn;

      using (TextReader reader = File.OpenText("Tamogotchi SaveFile.txt"))
      {
        string text = reader.ReadLine();
        string[] bits = text.Split(';');
        namn = bits[0];
      }


      int gameMenu = 0;
      string GameMenuString = "";

      while (gameMenu != 6)
      {
        Console.Clear();
        Console.WriteLine("Välj ett av alternativen.");
        Console.WriteLine($"1. Hälsa På {namn}");
        Console.WriteLine($"2. Lär {namn} Ett Nytt Ord");
        Console.WriteLine($"3. Mata {namn} ");
        Console.WriteLine("4. Skippa en timme ");
        Console.WriteLine("5. Wut This?");
        Console.WriteLine("6. Avsluta programmet");
        Console.Write("Jag väljer alternativ : ");
        GameMenuString = Console.ReadLine();

        // !Så att det inte krashar om anvädaren inte lyssnar
        while (!int.TryParse(GameMenuString, out gameMenu))
        {
          Console.WriteLine("Det där är inte ett giltigt svar. Försök igen!");
          Console.Write("Ok, Jag väljer då: ");
          GameMenuString = Console.ReadLine();
        }

        // !Istället för att använda fler if
        switch (gameMenu)
        {
          case 1:
            words.CheckFile();

            Console.Clear();
            Console.WriteLine($"Du Hälsar På {namn}!");
            Console.WriteLine($"{namn} Säger :");
            tamogotchi.Hi();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på [ENTER] För att Fortsätta.");
            Console.ReadLine();

            Console.Clear();
            tamogotchi.Tick();
            Console.WriteLine($"{namn} Nya Stats: ");
            tamogotchi.PrintStats();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på [ENTER] För att Fortsätta.");
            Console.ReadLine();
            break;

          case 2:
            words.CheckFile();
            Console.Clear();
            Console.Write($"Du vill lära {namn} ordet/Meningen: ");
            string word = Console.ReadLine();
            tamogotchi.Teach(word);

            Console.Clear();
            Console.WriteLine($"{namn} har nu lärt sig ordet/Meningen: {word}!");
            tamogotchi.Tick();
            Console.WriteLine();
            Console.WriteLine($"{namn} Nya Stats: ");
            tamogotchi.PrintStats();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på [ENTER] För att Fortsätta.");
            Console.ReadLine();
            break;

          case 3:
            Console.Clear();
            Console.WriteLine($"Du Matar {namn}");
            tamogotchi.Feed();
            tamogotchi.Tick();
            Console.WriteLine();
            Console.WriteLine($"{namn} Nya Stats: ");
            tamogotchi.PrintStats();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på [ENTER] För att Fortsätta.");
            Console.ReadLine();
            break;

          case 4:
            Console.Clear();
            Console.WriteLine("En Timme Skippas!");
            tamogotchi.Tick();
            Console.WriteLine();
            Console.WriteLine($"{namn} Nya Stats: ");
            tamogotchi.PrintStats();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på [ENTER] För att Fortsätta.");
            Console.ReadLine();
            break;

          case 5:
            Console.Clear();
            Console.WriteLine("Spellogik");
            Console.WriteLine("Låt användaren döpa sin tamagotchi.");
            Console.WriteLine("Låt spelaren välja mellan att lära tamagotchin ett nytt ord, hälsa på den, mata den eller göra ingenting.");
            Console.WriteLine("När spelaren valt en handling, kör motsvarande metod och fråga sedan igen.");
            Console.WriteLine("Varje gång spelaren gör ett val så körs också Tick.");
            Console.WriteLine("Om tamagotchin är död avslutas spelloopen.");

            Console.WriteLine("Tryck på [ENTER] För att Fortsätta.");
            Console.ReadLine();
            break;

          case 6:
            Console.Clear();
            Console.WriteLine("Då va det slut!");
            Console.WriteLine($"Säg Hejdå Till {namn}!");
            Console.WriteLine("Tryck på en knapp för att gå ut :)");
            Console.ReadLine();
            break;

          default:
            Console.WriteLine("Ej giltig kommando");
            Console.WriteLine("Tryck på [ENTER] För att Fortsätta.");
            Console.ReadLine();
            break;

        }
      }
    }
  }
}