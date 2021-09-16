using System;
using System.IO;

namespace Tamogotchi
{
  public class Words
  {
    public string[] wordFileInfo;
    public string wordFileName = "Tamogotchi WordFile.txt";
    public string wordText = "Hi";
    int wordMaxFile = 3;


    public void CheckFile()
    {
      //! kollar om filen finns
      if (File.Exists(wordFileName))
      {
        wordFileInfo = File.ReadAllLines(wordFileName);
      }

      //! om filen inte finns, skapas en ny fil
      else
      {
        wordFileInfo = new string[wordMaxFile];
        for (int i = 0; i < wordFileInfo.Length; i++)
        {
          wordFileInfo[i] = wordText;
        }

        File.WriteAllLines(wordFileName, wordFileInfo);
        Console.WriteLine("Tamogotchi SaveFile.txt hittades inte:");
        Console.WriteLine("En ny Tamogotchi SaveFile.txt Skapas:");
        Console.WriteLine("Tryck på [ENTER] För att Fortsätta.");
        Console.ReadLine();
      }
    }

    //! läser vad som står i filen
    public void WordFileReadFile()
    {
      for (int i = 0; i < wordFileInfo.Length; i++)
      {
        Console.WriteLine(wordFileInfo[i]);
      }
    }
  }
}