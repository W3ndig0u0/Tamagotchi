using System;
using System.IO;

namespace Tamogotchi
{
  public class SafeFile
  {
    public string[] bordsInnehåll;
    public string filnamn = "Tamogotchi.txt";
    public string tomtBord = "0;0;Null,false";
    public int antalbord = 3;

    public void CheckFile()
    {
      // kollar om filen finns
      if (File.Exists(filnamn))
      {
        bordsInnehåll = File.ReadAllLines(filnamn);
        Console.WriteLine("Tamogotchi Info:");
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
    }

  }
}