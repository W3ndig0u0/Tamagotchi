using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Tamogotchi
{
  public class Tamo
  {
    string namn;
    int hunger;
    int boredom;
    bool isAlive = true;

    Words wordsFile = new Words();
    List<string> words = new List<string>();
    private Random generator = new Random();


    void CreateList()
    {

      if (File.Exists("Tamogotchi WordFile.txt"))
      {
        words = File.ReadLines("Tamogotchi WordFile.txt").ToList();
      }
      else
      {
        wordsFile.CheckFile();
      }
    }


    //! − words: List<string>

    void ReadTamoInfo()
    {
      using (TextReader reader = File.OpenText("Tamogotchi SaveFile.txt"))
      {
        string text = reader.ReadLine();
        string[] bits = text.Split(';');
        namn = bits[0];
        hunger = int.Parse(bits[1]);
        boredom = int.Parse(bits[2]);
      }
    }

    void UpdateTamoInfo()
    {
      File.WriteAllText("Tamogotchi SaveFile.txt", $"{namn};{hunger};{boredom}");
    }

    //! Tick() ökar hunger och boredom, och om någon av dem kommer över 10 så blir isAlive false.
    public void Tick()
    {
      ReadTamoInfo();
      hunger++;
      boredom++;

      if (boredom > 10 || hunger > 10)
      {
        isAlive = false;
      }

      UpdateTamoInfo();
    }

    //! PrintStats() skriver ut nuvarande hunger och bredom, och meddelar också huruvida tamagotchin lever.
    public void PrintStats()
    {
      ReadTamoInfo();
      Console.WriteLine("Boredom :" + boredom);
      Console.WriteLine("Hunger :" + hunger);
      Console.WriteLine("Is Alive :" + isAlive);
    }

    //! Feed() sänker Hunger
    public void Feed()
    {
      ReadTamoInfo();
      hunger -= 2;
      UpdateTamoInfo();
    }

    // !ReduceBoredom() sänker boredom
    public void ReduceBoredom()
    {
      ReadTamoInfo();
      boredom -= 2;
      UpdateTamoInfo();
    }

    //! Hi() skriver ut ett slumpat ord från words, och anropar ReduceBoredom.
    public void Hi()
    {
      CreateList();
      if (words.Count >= 1)
      {
        int i = generator.Next(words.Count);
        Console.WriteLine(words[i]);
      }
      else
      {
        Console.WriteLine($"{namn} kan inga ord :)");
      }

      ReduceBoredom();
    }

    //! Teach(string word) lägger till ett ord i words, och anropar ReduceBoredom.
    public void Teach(string word)
    {
      words.Add(word);

      File.AppendAllLines("Tamogotchi WordFile.txt", words);

      ReduceBoredom();
    }

    //! GetAlive() returnerar värdet som isAlive har.
    public bool GetAlive()
    {
      return isAlive;
    }
  }
}