using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.UI.Level_Loading;
 
    public class LevelSelectedLoad : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            string levelName = gameObject.name;

            if (other.gameObject.tag == "Player")
            {
                LevelLoader.FadeToLevel(levelName);
            }
        }
    }
