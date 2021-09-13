using System;

namespace Tamogotchi
{

  public class Menu
  {
    public static void MenuMethod()
    {

      SafeFile safeFile = new SafeFile();
      int menu = 0;
      string menuString = "";

      Console.WriteLine("Det här är spelet Tamogotchi.");

      Console.WriteLine("\nHejsan Välkommen Till Menyn!");

      while (menu != 2)
      {
        Console.WriteLine("\nVälj ett av alternativen.");
        Console.WriteLine("1. Starta Programmet");
        Console.WriteLine("2. Avsluta programmet");
        Console.Write("Jag väljer alternativ : ");
        menuString = Console.ReadLine();

        // !Så att det inte krashar om anvädaren inte lyssnar
        while (!int.TryParse(menuString, out menu))
        {
          Console.WriteLine("Det där är inte ett giltigt svar. Försök igen!");
          Console.Write("Ok, Jag väljer då: ");
          menuString = Console.ReadLine();
        }

        break;
      }

      // !Istället för att använda fler if
      switch (menu)
      {
        case 1:
          safeFile.CheckFile();
          safeFile.ReadFile();
          Tamagotchi.Tick();
          Tamagotchi.PrintStats();
          Console.ReadLine();
          break;
        case 2:
          Console.WriteLine("Då va det slut!");
          Console.WriteLine("Tryck på en knapp för att gå ut :)");
          Console.ReadLine();
          break;

        default:
          Console.WriteLine("Ej giltig kommando");
          Console.ReadLine();
          break;

      }
    }
  }
}