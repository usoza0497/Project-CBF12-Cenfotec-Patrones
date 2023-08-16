using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.UI.Level_Loading;
using System;
using Assets.Scripts.Mediator;
using UnityEngine.Audio;

namespace Assets.Scripts.Mediator
{ 
    public class PauseMenu : IMenu
    {   
        public GameObject PauseMenuPanel;
        public Button LoadMapButton;
        public Button QuitButton;

        private void Start()
        {
            ToggleButtons();
        }
        
        public override void Hide(){
            PauseMenuPanel.SetActive(false);
        }
        public override void Show(){
            PauseMenuPanel.SetActive(true);
        }
        public void LoadMap() {
            GameManager.instance.MementoManager.restoreMemento();
            Time.timeScale = 1f;
            MenuMediator.isPaused = false;
            LevelLoader.FadeToLevel("Level Map");
        }

        public void QuitGame() {
            Application.Quit();
        }

        private void ToggleButtons()
        {
            string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName.Contains("Map"))
            {
                LoadMapButton.gameObject.SetActive(false);
                QuitButton.gameObject.SetActive(true);
            }
            else
            {
                LoadMapButton.gameObject.SetActive(true);
                QuitButton.gameObject.SetActive(false);
            }
        }
    }
}