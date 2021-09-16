using System;
using System.IO;

namespace Tamogotchi
{
  public class SafeFile
  {

    public string[] fileInfo;
    string fileName = "Tamogotchi SaveFile.txt";
    string text = "New Game;0;0;false";
    int maxFile = 3;


    public void CheckFile()
    {
      //! kollar om filen finns
      if (File.Exists(fileName))
      {
        fileInfo = File.ReadAllLines(fileName);
        Console.WriteLine("Tamogotchi Info:");
        for (int i = 0; i < fileInfo.Length; i++)
        {
          fileInfo[i] = text;
        }
      }

      //! om filen inte finns, skapas en ny fil
      else
      {
        fileInfo = new string[maxFile];
        for (int i = 0; i < fileInfo.Length; i++)
        {
          fileInfo[i] = text;
        }
        File.WriteAllLines(fileName, fileInfo);
        Console.WriteLine("Tamogotchi SaveFile.txt Is Creating");
      }
    }

    //! läser vad som står i filen
    public void SafeFileReadFile()
    {
      for (int i = 0; i < fileInfo.Length; i++)
      {
        string[] specefikFile= fileInfo[i].Split(';');
        string fileName = specefikFile[0];
        int filePetHunger = int.Parse(specefikFile[1]);
        int filePetBoredome = int.Parse(specefikFile[2]);
        string filePetAlive = specefikFile[3];
        Console.WriteLine($"Save File Nr {i + 1}, FileName: {fileName}, (Hunger: {filePetHunger}, Boredome: {filePetBoredome}, Alive: {filePetAlive})");
      }
    }

  }
}