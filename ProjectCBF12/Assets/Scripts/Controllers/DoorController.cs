using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.UI.Level_Loading;

    public class DoorController : MonoBehaviour
    {
        public string levelName;
        public AudioClip doorSound;
        private Animator myAnimator;

        private void Start()
        {
            myAnimator = GetComponent<Animator>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (levelName.Contains("Map") || levelName.Contains("Boss"))
                {
                    GameManager.instance.MementoManager.updateGameStatsMemento(GameManager.instance.CurrentLevel, GameManager.instance.LevelCoinScore + GameManager.instance.GlobalCoinScore);
                } 
            }
            PlayDoorSound();
            myAnimator.SetTrigger("Open");
        }

        private void LoadBossLevel()
        {
            LevelLoader.FadeToLevel(levelName);
        }

        public void PlayDoorSound()
        {
            AudioManager.instance.PlaySound(doorSound);
        }
    }
