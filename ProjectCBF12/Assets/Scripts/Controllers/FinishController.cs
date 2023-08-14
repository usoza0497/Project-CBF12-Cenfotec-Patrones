using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.UI.Level_Loading;

    public class FinishController : MonoBehaviour
    {
        public string levelName;
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (levelName.Contains("Map") || levelName.Contains("Boss"))
                {
                    GameManager.instance.MementoManager.updateGameStatsMemento(GameManager.instance.CurrentLevel, GameManager.instance.LevelCoinScore + GameManager.instance.GlobalCoinScore);
                } 
                LevelLoader.FadeToLevel(levelName);
            }
        }
    }
