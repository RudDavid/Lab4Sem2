using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace standardInputAndOutput {
  public class Caretaker {
    private object _memento;
    public void SaveState(IOriginator originator) {
      _memento = originator.GetMemento();
    }

    public void RestoreState(IOriginator originator) {
      originator.SetMemento(_memento);
    }
  }
}
