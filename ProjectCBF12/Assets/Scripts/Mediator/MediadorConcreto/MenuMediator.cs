using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Mediator;
using UnityEngine;

namespace Assets.Scripts.Mediator
{ 
    public class MenuMediator : iMediador
    {
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private SettingsMenu _settingsMenu;
        public static bool isPaused = false;

        private void Awake() {
            _pauseMenu.Configure(this);
            _settingsMenu.Configure(this);
            _settingsMenu.SetFullscreen(false);
            _settingsMenu.Hide();
            _pauseMenu.Hide();
        }
        void Update()
            {
                if(Input.GetKeyDown(KeyCode.Escape)) {
                    if(isPaused) {
                        isPaused = false;
                        Resume();
                    } else {
                        isPaused = true;
                        GoToPauseMenu();
                    }
                }
            }

        public override void GoToSettingsMenu() {
            Time.timeScale = 0f;
            isPaused = true;
            _pauseMenu.Hide();
            _settingsMenu.Show();
        }

        public override void Resume(){
            Time.timeScale = 1f;
            isPaused = false;
            _pauseMenu.Hide();
            _settingsMenu.Hide();
        }

        public override void GoToPauseMenu() {
            Time.timeScale = 0f;
            isPaused = true;
            _settingsMenu.Hide();
            _pauseMenu.Show();
        }

    }
}
