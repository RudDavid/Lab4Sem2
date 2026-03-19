using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Net.WebRequestMethods;

namespace standardInputAndOutput {
  internal class Program {

    public static void CreateFile(string path) {
      FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
      file.Close();
    }

    public static  void EditFile(TextFile text) {
      string newContent;
      Console.Write("Enter new content: ");
      newContent = Console.ReadLine();
      text.ContentOfTextFile = newContent;
      Console.WriteLine("Content is updated");

    }

    static void Main(string[] args) {

      string menu, path, userFolder, keyword;
      bool isRun;
      int firstBorder, lastBorder;
      FileStream file;
      Caretaker caretaker;
      TextFile myFile;
      FindFileWithKeyword find;



      Console.WriteLine("Enter the path for the new file: ");
      path = Console.ReadLine();
      menu = $"---Text Editor---" +
              "0 - Close programm\n" +
              "1 - Create new file\n" +
              "2 - Edit file\n" +
              "3 - Undo file\n" +
              "4 - Find file with keyword\n"+
              "5 - Show file information\n\n" +
              "Your choice: ";

      myFile = new TextFile(Path.GetFileName(path), "");
      isRun = true;
      caretaker = new Caretaker();
      firstBorder = 0;
      lastBorder = 5;

      while (isRun) {

        Console.Write(menu);
        string userButton;
        userButton = Console.ReadLine();

        while (userButton.Length < firstBorder || userButton.Length > lastBorder) {
          Console.WriteLine("Please enter correct number of operation");
          userButton = Console.ReadLine();
        }

        switch (userButton) {
          case "0":
            isRun = false;
            Console.WriteLine("Programm closed");
            break;
          case "1":
            CreateFile(path);
            Console.Write($"File created.\n{menu}");
            userButton = Console.ReadLine();
            break;
          case "2":
            caretaker.SaveState(myFile);
            EditFile(myFile);
            file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            myFile.BinarySerialization(file);
            break;
          case "3":
            caretaker.RestoreState(myFile);
            Console.Write("Undo: ");
            myFile.Print();
            break;
          case "4":
            Console.WriteLine("Please enter path for folder");
            userFolder = Console.ReadLine();
            Console.WriteLine("Please enter the keyword");
            keyword = Console.ReadLine();

            find = new FindFileWithKeyword(keyword, userFolder);

            find.SearchFilesWithKeyword();
            find.Print();
            break;
          case "5":
            myFile.Print();
            break;
        }
      }
    }
  }
}
