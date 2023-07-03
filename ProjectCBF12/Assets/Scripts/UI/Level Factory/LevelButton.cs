using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AbstractFactory;
using TMPro;

public class LevelButton : MonoBehaviour
{
        private TMP_Text levelNameText;

        private Level levelToLoad;

        public void SetLevelName(string LevelName)
        {
            levelNameText = GetComponentInChildren<TMP_Text>();
            levelNameText.text = LevelName;
            LevelFactory LevelFactory = new LevelFactory();
        }

        public void SetLevel(Level Level)
        {
            this.levelToLoad = Level;
        }


        public void OnButtonClick()
        {
            levelToLoad.SelectLevel();
        }
}

