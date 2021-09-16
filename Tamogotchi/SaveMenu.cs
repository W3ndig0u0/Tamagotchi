using System;
using System.IO;

namespace Tamogotchi
{
  public class SaveMenu
  {
    public static void FileMenuMethod()
    {

      SafeFile safeFile = new SafeFile();
      Tamo tamogotchi = new Tamo();

      int menu = 0;
      string menuString = "";

      while (menu != 10)
      {
        Console.WriteLine("Välj ett av alternativen.");
        Console.WriteLine("1. Fortsätt med en existerande File");
        Console.WriteLine("2. Starta En Nytt File");
        Console.WriteLine("3. Radera En File (EJ klar)");
        Console.Write("Jag väljer alternativ : ");
        menuString = Console.ReadLine();

        Console.WriteLine("Files Som Du har : ");
        safeFile.CheckFile();
        safeFile.SafeFileReadFile();

        // !Så att det inte krashar om anvädaren inte lyssnar
        while (!int.TryParse(menuString, out menu))
        {
          Console.WriteLine("Det där är inte ett giltigt svar. Försök igen!");
          Console.Write("Ok, Jag väljer då: ");
          menuString = Console.ReadLine();
        }

        // !Istället för att använda fler if
        switch (menu)
        {
          case 1:
            Console.Clear();
            Console.WriteLine("Files Som Du har: ");
            safeFile.SafeFileReadFile();
            Console.Write("Jag Väljer File Nr: ");
            Console.ReadLine();
            // //  ?Gör så att man kan välja...
            GamePlay.GamePlayMethod();
            break;
          case 2:
            Console.Clear();
            Console.WriteLine("En ny file skappas...");
            Console.WriteLine("Vad ska Tamogotchins namn vara?:");
            string namn = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"Tamogotchin heter nu {namn}.");
            Console.WriteLine("Klar.");
            Console.WriteLine("Tryck på [ENTER] För att Fortsätta.");
            Console.ReadLine();
            Console.Clear();
            // File.AppendAllText("date.txt", DateTime.Now.ToString());
            // File.AppendAllText("Tamogotchi SaveFile.txt", "New Game;0;0;false");
            Console.WriteLine("Tryck på [ENTER] För att Startar Den nya Filen.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("SAIK HADE ERROR FÖR LÄNGE SEDAN GÅ TILLBAKA TILL DEN FILEN DU HAR!");
            Console.ReadLine();
            // //  ?Gör så att man Startar på den nya...
            // GamePlay.GamePlayMethod();
            break;

          default:
            Console.Clear();
            Console.WriteLine("Ej giltig kommando");
            Console.WriteLine("Tryck på [ENTER] För att Fortsätta.");
            Console.ReadLine();
            break;
        }

      }
    }
  }
}