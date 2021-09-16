using System;
using System.IO;

namespace Tamogotchi
{
    public class Words
    {
    public string[] wordFileInfo;
    public string wordFileName = "Tamogotchi WordFile.txt";
    public string wordText = "Hi";
    int wordMaxFile = 10;


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