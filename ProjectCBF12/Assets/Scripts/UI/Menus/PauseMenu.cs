using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.UI.Level_Loading;
using System;
using Assets.Scripts.Mediator;

namespace Assets.Scripts.UI.Menus
{ 
    public class PauseMenu : MonoBehaviour
    {   
        private MenuMediator _mediator;
        public GameObject PauseMenuPanel;
        public Button LoadMapButton;
        public Button QuitButton;


        public void Configure(MenuMediator menuMediator)
        {
            _mediator = menuMediator;
        }

        private void Start()
        {
            ToggleButtons();
        }
        
        public void Hide(){
            PauseMenuPanel.SetActive(false);
        }
        public void Show(){
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