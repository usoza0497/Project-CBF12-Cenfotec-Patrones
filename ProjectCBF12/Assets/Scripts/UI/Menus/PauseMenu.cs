using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.UI.Level_Loading;

namespace Assets.Scripts.UI.Menus
{ 
    public class PauseMenu : MonoBehaviour
    {
        public static bool isPaused = false;
        public GameObject PauseMenuPanel;

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                if(isPaused) {
                    Resume();
                } else {
                    Pause();
                }
            }
        }

        public void Resume() {
            PauseMenuPanel.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

        public void Pause() 
        {
            PauseMenuPanel.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }

        public void LoadMap() {
            Time.timeScale = 1f;
            LevelLoader.FadeToLevel("Level Map");
        }
    }
}