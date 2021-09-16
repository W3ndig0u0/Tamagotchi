using System;
using System.IO;

namespace Tamogotchi
{
    public class Words
    {
    public string[] wordFileInfo;
    public string wordFileName = "Tamogotchi WordFile.txt";
    public string wordText = "Hi";


    public void CheckFile()
    {
      //! kollar om filen finns
      if (File.Exists(wordFileName))
      {
        wordFileInfo = File.ReadAllLines(wordFileName);
        Console.WriteLine("Tamogotchi Words:");
        for (int i = 0; i < wordFileInfo.Length; i++)
        {
          wordFileInfo[i] = wordText;
        }
      }

      //! om filen inte finns, skapas en ny fil
      else
      {
        for (int i = 0; i < wordFileInfo.Length; i++)
        {
          wordFileInfo[i] = wordText;
        }
        File.WriteAllLines(wordFileName, wordFileInfo);
        Console.WriteLine("Tamogotchi Word.txt Is Creating");
      }
    }

    //! läser vad som står i filen
    public void WordFileReadFile()
    {
      for (int i = 0; i < wordFileInfo.Length; i++)
      {
        // string[] specefikBord = fileInfo[i].Split(' ');
        // string words = specefikBord[0];
        Console.WriteLine(wordFileInfo[i]);
      }
    }
  }
}