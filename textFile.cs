using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace standardInputAndOutput {
  [Serializable]
  class TextFile : IOriginator {
    public string NameTextFile {  get; set; }
    public string ContentOfTextFile { get; set; }

    public TextFile(string name, string content) {
      NameTextFile = name;
      ContentOfTextFile = content;
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
      NameTextFile = deserializedFile.NameTextFile;
      ContentOfTextFile = deserializedFile.ContentOfTextFile;
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
      NameTextFile = deserializedFile.NameTextFile;
      ContentOfTextFile = deserializedFile.ContentOfTextFile;
      file.Close();
    }

    public void Print() {
      Console.WriteLine($" Name file: {NameTextFile}.\n Text: {ContentOfTextFile}");
    }

    object IOriginator.GetMemento() {
      return new Memento { NameTextFile = this.NameTextFile, ContentOfTextFile = this.ContentOfTextFile};
    }

    void IOriginator.SetMemento(object memento) {
      if (memento is Memento) {
        var mem = memento as Memento;
        NameTextFile = mem.NameTextFile;
        ContentOfTextFile = mem.ContentOfTextFile;
      }
    }

  }
}