using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Tamogotchi
{
  public class Tamo
  {
    string namn;
    int hunger = 0;
    int boredom = 0;
    bool isAlive = true;

    // Random rng = new Random();
    // int randomInt = rng.Next(0, 10);

    List<string> words = File.ReadLines("Tamogotchi WordFile.txt").ToList();
    // List<string> words = new List<string>();

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
      hunger -= 2;
    }

    // !ReduceBoredom() sänker boredom
    public void ReduceBoredom()
    {
      boredom -= 2;
    }


    //! Hi() skriver ut ett slumpat ord från words, och anropar ReduceBoredom.
    public void Hi()
    {
      for (int i = 0; i < words.Count; i++)
      {
        Console.WriteLine(words[i]);
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