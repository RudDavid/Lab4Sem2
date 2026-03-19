using System;
using System.Collections.Generic;
using System.IO;

namespace standardInputAndOutput {
  public class FindFileWithKeyword {
    List<string> listWithSearchFiles;
    string keyword;
    string lincForFolder;
    string localContent;

    public FindFileWithKeyword(string userKeyword, string userLinc) {
      keyword = userKeyword;
      lincForFolder = userLinc;
    }

    public List<string> SearchFilesWithKeyword() {

      listWithSearchFiles = new List<string>();
      string[] listWithLincsFiles = Directory.GetFiles(lincForFolder);

      Console.WriteLine($"Find {listWithLincsFiles.Length} files");

      for (int indexI = 0; indexI < listWithLincsFiles.Length; ++indexI) {
        localContent = File.ReadAllText(listWithLincsFiles[indexI]);
        if (keyword.Length <= localContent.Length) { 
          for (int indexT = 0; indexT <= localContent.Length - keyword.Length; ++indexT) {
            bool found = true;
            for (int indexK = 0; indexK < keyword.Length; ++indexK) {
              if (localContent[indexT + indexK] != keyword[indexK]) {
                found = false;
                break;
              } 
            }
            if (found) {
              listWithSearchFiles.Add(listWithLincsFiles[indexI]);
              break;
            }
          }
        }
      }
      return listWithSearchFiles;
    } 
    public void Print() {
      Console.WriteLine(listWithSearchFiles);
    }
  }
}