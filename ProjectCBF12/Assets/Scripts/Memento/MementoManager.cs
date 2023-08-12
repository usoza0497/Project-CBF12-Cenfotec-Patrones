using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Memento
{
    public class MementoManager
    {
        private Originator _originator;
        private Caretaker _caretaker;

        public MementoManager()
        {
            this._originator = new Originator();
            this._caretaker = new Caretaker();
        }

        public void newGameStats(string pCurrentLevel, int pGlobalCoinScore)
        {
            GameManager.instance.CurrentLevel = pCurrentLevel;
            GameManager.instance.GlobalCoinScore = pGlobalCoinScore;

            _originator.newState(pCurrentLevel, pGlobalCoinScore);
            updateMemento();
        }

        public string getLevelName()
        {
            return _originator.getState().getLevelName();
        }

        public int getGlobalCoinScore()
        {
            return _originator.getState().getGlobalCoinScore();
        }

        public void updateGameStats(string pCurrentLevel, int pGlobalCoinScore)
        {
            _originator.newState(pCurrentLevel, pGlobalCoinScore);    

            GameManager.instance.CurrentLevel = pCurrentLevel;
            GameManager.instance.GlobalCoinScore = pGlobalCoinScore;            
        }

        public void updateGameStatsMemento(string pCurrentLevel, int pGlobalCoinScore)
        {
            updateGameStats(pCurrentLevel, pGlobalCoinScore);
            updateMemento();
        }

        private void updateMemento()
        {
            _caretaker.setMemento(_originator.createMemento());
        }

        public void restoreMemento()
        {
            _originator.restoreMemento(_caretaker.getMemento());
            GameManager.instance.CurrentLevel = _originator.getState().getLevelName();
            GameManager.instance.GlobalCoinScore = _originator.getState().getGlobalCoinScore();
        }
    }
}
