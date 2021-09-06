using System;
using System.IO;

namespace Tamogotchi
{
  public class SafeFile
  {
    static void Main(string[] args)
    {
      string[] bordsInnehåll;
      string filnamn = "jingsbord.txt";
      string tomtBord = "0;Inga gäster;0kr";
      int antalbord = 20;

      Console.WriteLine("Detta är Jings bordshanterare\nBordsinformation lästes in från fil");

      // kollar om filen finns
      if (File.Exists(filnamn))
      {
        bordsInnehåll = File.ReadAllLines(filnamn);
        Console.WriteLine("Här är Bords infromationen:");
        Console.WriteLine(bordsInnehåll);
      }
      else //om filen inte finns, skapas en ny fil
      {
        bordsInnehåll = new string[antalbord];
        for (int i = 0; i < bordsInnehåll.Length; i++)
        {
          bordsInnehåll[i] = tomtBord;
        }
        File.WriteAllLines(filnamn, bordsInnehåll);
      }

      //  Programmets Meny

      int menuVal = 0;
      while (menuVal != 4)
      {
        Console.WriteLine("\n\nVälj ett av alternativen.");
        Console.WriteLine("1. Visa alla bord");
        Console.WriteLine("2. Lägg ändra bordsinformation");
        Console.WriteLine("3. Markera att ett bord är tomt");
        Console.WriteLine("4. Avsluta programmet");
        Console.Write("\nJag väljer alternativ : ");
        menuVal = int.Parse(Console.ReadLine());

        Console.WriteLine();

        switch (menuVal)
        {
          case 1:
            // om det är inte personer i ett bord
            int totaltAntalGäster = 0;
            int totaltAntalPengar = 0;
            int totaltMaxAntalGäster = 1000;
            for (int i = 0; i < bordsInnehåll.Length; i++)
            {
              if (bordsInnehåll[i] == tomtBord)
              {
                Console.WriteLine($"Bord {i + 1} - Inga gäster, 0kr");
                continue;
              }

              // Detta sker bara om bordet inte är tomt
              string[] specefikBord = bordsInnehåll[i].Split(';');
              int antalGäst = int.Parse(specefikBord[0]);
              string bordsnamn = specefikBord[1];
              int antalPengar = int.Parse(specefikBord[2]);
              int antalSittPlatser = int.Parse(specefikBord[3]);
              totaltAntalGäster += antalGäst;
              totaltAntalPengar += antalPengar;
              totaltMaxAntalGäster += antalSittPlatser;
              Console.WriteLine($"Bord {i + 1} - Namn: {bordsnamn}, antal gäster: {antalGäst}, , Antal Sittplatser: {antalSittPlatser}, Nota: {antalPengar} kr");

            }
            Console.WriteLine($"\nTotalt antal gäster: {totaltAntalGäster}");
            Console.WriteLine($"Totalt antalet Sittplatser kvar: {totaltMaxAntalGäster - totaltAntalGäster}");
            Console.WriteLine($"Totalt antal Pengar: {totaltAntalPengar}");
            break;

          case 2:
            Console.WriteLine("Vilket bordsnummer vill du lägga till/ändra informationen för?");
            int ändraBordsnummer = int.Parse(Console.ReadLine());

            while (ändraBordsnummer <= 0 || ändraBordsnummer > bordsInnehåll.Length)
            {
              Console.WriteLine($"{ändraBordsnummer} är inte ett giltigt bordsnummer. Försök igen.");
              break;
            }

            string[] BordInfoNy = new string[4];

            Console.WriteLine("Skriv in Borders antal Sittplatser");
            BordInfoNy[3] = Console.ReadLine();

            Console.WriteLine("Hur många gäster finns vid bordet?");
            BordInfoNy[0] = Console.ReadLine();

            Console.WriteLine("Skriv in Bordets namn");
            BordInfoNy[1] = Console.ReadLine();

            Console.WriteLine("Hur stor nota ska bordet ha?");
            BordInfoNy[2] = Console.ReadLine();
            bordsInnehåll[ändraBordsnummer - 1] = string.Join(";", BordInfoNy);

            // Uppdatera sparfilen
            File.WriteAllLines(filnamn, bordsInnehåll);
            break;

          case 3:
            Console.WriteLine("Vilket bordsnummer ska vara tomt?");
            int bordsnummerRadera = int.Parse(Console.ReadLine());
            if (bordsnummerRadera <= 0 || bordsnummerRadera > bordsInnehåll.Length)
            {
              Console.WriteLine($"{bordsnummerRadera} är inte ett giltigt bordsnummer");
              break;
            }

            bordsInnehåll[bordsnummerRadera - 1] = tomtBord;
            Console.WriteLine($"Bord {bordsnummerRadera} är markerat som tomt");

            // Uppdatera sparfilen
            File.WriteAllLines(filnamn, bordsInnehåll);
            break;

          case 4:
            Console.WriteLine("Hejdå!");
            break;

          default:
            Console.WriteLine("error");
            break;

        }
      }
    }
  }
}