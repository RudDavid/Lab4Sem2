using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace standardInputAndOutput {
  class Memento {
    public string nameTextFile { get; set; }
    public string contentOfTextFile { get; set; }
  }
  public interface IOriginator {
    object GetMemento();
    void SetMemento(object memento);
  }
}
