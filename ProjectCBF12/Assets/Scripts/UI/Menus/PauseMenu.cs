using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.UI.Level_Loading;
using System;

namespace Assets.Scripts.UI.Menus
{ 
    public class PauseMenu : MonoBehaviour
    {   
        private MenuMediator _mediator;
        public static bool isPaused = false;
        public GameObject PauseMenuPanel;

        public void Configure(MenuMediator menuMediator)
        {
            _mediator = menuMediator;
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
            isPaused = false;
            LevelLoader.FadeToLevel("Level Map");
        }


    }
}