using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Memento
{   
    public class Snapshot
    {
        private string _levelName;
        private int _globalCoinScore;
        

        public void newSnapshot(string pLevelName, int pGlobalCoinScore)
        {
            this._levelName = pLevelName;
            this._globalCoinScore = pGlobalCoinScore;
        }

        public string getLevelName()
        {
            return this._levelName;
        }

        public int getGlobalCoinScore()
        {
            return this._globalCoinScore;
        }
    }
}
