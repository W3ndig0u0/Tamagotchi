using System;
using System.IO;

namespace Tamogotchi
{
  public class SafeFile
  {
    public string[] bordsInnehåll;
    public string filnamn = "Tamogotchi.txt";
    public string tomtBord = "0;0;Null;false";
    public int antalbord = 3;

    public void CheckFile()
    {
      // kollar om filen finns
      if (File.Exists(filnamn))
      {
        bordsInnehåll = File.ReadAllLines(filnamn);
        Console.WriteLine("Tamogotchi Info:");
        for (int i = 0; i < bordsInnehåll.Length; i++)
        {
          bordsInnehåll[i] = tomtBord;
        }
      }
      else //om filen inte finns, skapas en ny fil
      {
        bordsInnehåll = new string[antalbord];
        for (int i = 0; i < bordsInnehåll.Length; i++)
        {
          bordsInnehåll[i] = tomtBord;
        }
        File.WriteAllLines(filnamn, bordsInnehåll);
        Console.WriteLine("Tamogotchi.txt Is Creating");
      }
    }
    public void ReadFile()
    {
      for (int i = 0; i < bordsInnehåll.Length; i++)
      {
        string[] specefikBord = bordsInnehåll[i].Split(';');
        int antalGäst = int.Parse(specefikBord[0]);
        int bordsnamn = int.Parse(specefikBord[1]);
        string antalPengar = specefikBord[2];
        bool antalSittPlatser = bool.Parse(specefikBord[3]);
        Console.WriteLine($"Save File Nr {i + 1} - hunger: {bordsnamn}, boredom: {antalGäst}, name: {antalSittPlatser}, isAlive: {antalPengar}");
      }
    }

  }
}