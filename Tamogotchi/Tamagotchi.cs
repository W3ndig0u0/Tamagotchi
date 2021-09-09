using System;
using System.Collections.Generic;

namespace Tamogotchi
{
  public class Tamagotchi
  {

    public string name = "";

    int hunger = 0;
    int boredom = 0;
    bool isAlive = true;

    Random generator = new Random();
    int randomInt = generator.Next(0, 100);

    List<string> words = new List<string>();

    //! − words: List<string>

    //! Tick() ökar hunger och boredom, och om någon av dem kommer över 10 så blir isAlive false.
    public void Tick()
    {

    }

    //! Feed() sänker Hunger
    public void Feed()
    {

    }

    //! Hi() skriver ut ett slumpat ord från words, och anropar ReduceBoredom.
    public void Hi()
    {

    }

    //! Teach(string word) lägger till ett ord i words, och anropar ReduceBoredom.
    public void Teach(string word)
    {

    }

    //! PrintStats() skriver ut nuvarande hunger och bredom, och meddelar också huruvida tamagotchin lever.
    public void PrintStats()
    {

    }

    //! GetAlive() returnerar värdet som isAlive har.
    public void GetAlive()
    {

    }

    // !ReduceBoredom() sänker boredom
    public void ReduceBoredom()
    {

    }


  }
}