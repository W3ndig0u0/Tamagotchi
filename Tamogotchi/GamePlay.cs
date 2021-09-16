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
      int gameMenu = 0;
      string GameMenuString = "";


      // void GameMenu(){

      while (gameMenu != 6)
      {
        Console.Clear();
        Console.WriteLine("\nVälj ett av alternativen.");
        Console.WriteLine("1. Hälsa På Den");
        Console.WriteLine("2. Lära Ett Nytt Ord");
        Console.WriteLine("3. Mata den ");
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

        break;
      }


      // !Istället för att använda fler if
      switch (gameMenu)
      {
        case 1:
          Console.Clear();
          Console.WriteLine("Hälsar På Den");
          words.CheckFile();
          words.WordFileReadFile();

          // Console.WriteLine("");
          // Console.Write("Den Ska lära sig ordet :");
          string word = Console.ReadLine();
          tamogotchi.Teach(word);

          tamogotchi.Hi();
          // words.WordFileReadFile();
          tamogotchi.Tick();
          Console.WriteLine();
          Console.WriteLine("Tamogotchis Nya Stats: ");
          tamogotchi.PrintStats();
          break;

        // case 1:
        // Console.Clear();
        // Console.WriteLine("Hälsar På Den");
        // tamogotchi.Hi();
        // tamogotchi.Tick();
        // Console.WriteLine();
        // Console.WriteLine("Tamogotchis Nya Stats: ");
        // tamogotchi.PrintStats();
        //   break;

        case 2:
          Console.Clear();
          Console.Write("Den Ska lära sig ordet :");
          string newWord = Console.ReadLine();
          tamogotchi.Teach(newWord);

          tamogotchi.Tick();
          Console.WriteLine();
          Console.WriteLine("Tamogotchis Nya Stats: ");
          tamogotchi.PrintStats();
          break;

        case 3:
          Console.Clear();
          Console.WriteLine("Matar Den");
          tamogotchi.Feed();
          tamogotchi.Tick();
          Console.WriteLine();
          Console.WriteLine("Tamogotchis Nya Stats: ");
          tamogotchi.PrintStats();
          break;

        case 4:
          Console.Clear();
          Console.WriteLine("En Timme Skippas!");
          tamogotchi.Tick();
          Console.WriteLine();
          Console.WriteLine("Tamogotchis Nya Stats: ");
          tamogotchi.PrintStats();
          break;

        case 5:
          Console.Clear();
          Console.WriteLine("Spellogik");
          Console.WriteLine("Låt användaren döpa sin tamagotchi.");
          Console.WriteLine("Låt spelaren välja mellan att lära tamagotchin ett nytt ord, hälsa på den, mata den eller göra ingenting.");
          Console.WriteLine("När spelaren valt en handling, kör motsvarande metod och fråga sedan igen.");
          Console.WriteLine("Varje gång spelaren gör ett val så körs också Tick.");
          Console.WriteLine("Om tamagotchin är död avslutas spelloopen.");
          break;

        case 6:
          Console.Clear();
          Console.WriteLine("Då va det slut!");
          Console.WriteLine("Tryck på en knapp för att gå ut :)");
          break;

        default:
          Console.WriteLine("Ej giltig kommando");
          Console.ReadLine();
          break;

      }
    }
  }
}