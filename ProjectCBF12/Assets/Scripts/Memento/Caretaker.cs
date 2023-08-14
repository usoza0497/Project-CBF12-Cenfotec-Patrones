using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Memento
{
    public class Caretaker
    {
        private Memento _memento;

        public void setMemento(Memento pMemento)
        {
            this._memento = pMemento;
        }

        public Memento getMemento()
        {
            return this._memento;
        }
    }
}
