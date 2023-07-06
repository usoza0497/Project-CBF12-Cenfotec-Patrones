using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelLoad;

    public class FinishController : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            string levelName = "Level Map";
            LevelLoader levelLoader = new LevelLoader();

            if (other.gameObject.tag == "Player")
            {
                StartCoroutine(levelLoader.LoadLevel(levelName));
            }
        }
    }
