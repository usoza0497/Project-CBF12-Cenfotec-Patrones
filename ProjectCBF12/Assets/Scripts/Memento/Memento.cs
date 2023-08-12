using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Memento
{
    public class Memento 
    {
        private Snapshot _snapshot;

        public Memento(string pLevelName, int pGlobalCoinScore)
        {
            this._snapshot = new Snapshot();
            this._snapshot.newSnapshot(pLevelName, pGlobalCoinScore);
        }

        public Snapshot getSnapshot()
        {
            return this._snapshot;
        }
    }
}
