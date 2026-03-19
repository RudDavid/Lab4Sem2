using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace standardInputAndOutput {
  [Serializable]
  class TextFile : IOriginator {
    public string nameTextFile {  get; set; }
    public string contentOfTextFile { get; set; }

    public TextFile(string name, string content) {
      nameTextFile = name;
      contentOfTextFile = content;
    }

    public void BinarySerialization(FileStream file) {
      BinaryFormatter bifile = new BinaryFormatter();
      bifile.Serialize(file, this);
      file.Flush();
      file.Close();
    }

    public void BinaryDeserialization(FileStream file) {
      BinaryFormatter bifile = new BinaryFormatter();
      TextFile deserializedFile = (TextFile)bifile.Deserialize(file);
      nameTextFile = deserializedFile.nameTextFile;
      contentOfTextFile = deserializedFile.contentOfTextFile;
      file.Close();
    }

    public void XmlSerialization(FileStream file) {
      XmlSerializer xfile = new XmlSerializer(this.GetType());
      xfile.Serialize(file, this);
      file.Flush();
      file.Close();
    }

    public void XmlDeserialization(FileStream file) {
      XmlSerializer xfile = new XmlSerializer(this.GetType());
      TextFile deserializedFile = (TextFile)xfile.Deserialize(file);
      nameTextFile = deserializedFile.nameTextFile;
      contentOfTextFile = deserializedFile.contentOfTextFile;
      file.Close();
    }

    public void Print() {
      Console.WriteLine($" Name file: {nameTextFile}.\n Text: {contentOfTextFile}");
    }

    object IOriginator.GetMemento() {
      return new Memento { nameTextFile = this.nameTextFile, contentOfTextFile = this.contentOfTextFile};
    }

    void IOriginator.SetMemento(object memento) {
      if (memento is Memento) {
        var mem = memento as Memento;
        nameTextFile = mem.nameTextFile;
        contentOfTextFile = mem.contentOfTextFile;
      }
    }

  }
}