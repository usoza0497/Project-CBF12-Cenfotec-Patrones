using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Memento
{
    public class Originator
    {
        private Snapshot _state;

        public Originator()
        {
            this._state = new Snapshot();
        }

        public void newState(string pLevelName, int pGlobalCoinScore)
        {
            this._state.newSnapshot(pLevelName, pGlobalCoinScore);
        }

        public Snapshot getState()
        {
            return this._state;
        }

        public void restoreMemento(Memento pMemento)
        {
            this._state.newSnapshot(pMemento.getSnapshot().getLevelName(), pMemento.getSnapshot().getGlobalCoinScore());

        }

        public Memento createMemento()
        {
            return new Memento(this._state.getLevelName(), this._state.getGlobalCoinScore());
        }
    }
}
