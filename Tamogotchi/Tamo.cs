using System;
using System.Collections.Generic;

namespace Tamogotchi
{
  public class Tamo
  {

    public string name = "";

    int hunger = 0;
    int boredom = 0;
    bool isAlive = true;

    Random rng = new Random();
    // int randomInt = rng.Next(0, 10);

    List<string> words = new List<string>();

    //! − words: List<string>

    //! Tick() ökar hunger och boredom, och om någon av dem kommer över 10 så blir isAlive false.
    public void Tick()
    {
      hunger++;
      boredom++;
      if (boredom > 10 || hunger > 10)
      {
        isAlive = false;
      }
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
        Console.WriteLine()

      }
    }

    //! Teach(string word) lägger till ett ord i words, och anropar ReduceBoredom.
    public void Teach(string word)
    {
      words.Add(word);
    }

    //! PrintStats() skriver ut nuvarande hunger och bredom, och meddelar också huruvida tamagotchin lever.
    public void PrintStats()
    {
      Console.WriteLine("Boredom :" + boredom);
      Console.WriteLine("Hunger :" + hunger);
      Console.WriteLine("Is Alive :" + isAlive);
    }

    //! GetAlive() returnerar värdet som isAlive har.
    // public void GetAlive()
    // {
    //   return isAlive;
    // }
  }
}