using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelLoad;

namespace LevelLoad
{  
    public class LevelComplete : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            string levelName = "Level Select";
            LevelLoader levelLoader = new LevelLoader();

            if (other.gameObject.tag == "Player")
            {
                StartCoroutine(levelLoader.LoadLevel(levelName));
            }
        }
    }
}
