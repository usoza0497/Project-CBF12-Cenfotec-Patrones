using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelLoad;

namespace LevelLoad
{   
    public class LevelSelectedLoad : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            string levelName = gameObject.name;
            
            LevelLoader levelLoader = new LevelLoader();

            if (other.gameObject.tag == "Player")
            {
                Debug.Log(levelName);
                StartCoroutine(levelLoader.LoadLevel(levelName));
            }
        }
    }
}
