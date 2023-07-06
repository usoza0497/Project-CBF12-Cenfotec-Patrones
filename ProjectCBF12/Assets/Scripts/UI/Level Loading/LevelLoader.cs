using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelLoad
{
    public class LevelLoader {
        private float levelLoadDelay = 1.5f;

        public IEnumerator LoadLevel(string plevelName)
        {
            yield return new WaitForSeconds(levelLoadDelay);
            SceneManager.LoadScene(plevelName);

        }
    }
}
