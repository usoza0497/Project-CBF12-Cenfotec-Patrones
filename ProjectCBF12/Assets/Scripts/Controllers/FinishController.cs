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
                LevelLoader.FadeToLevel(levelName);
            }
        }
    }
