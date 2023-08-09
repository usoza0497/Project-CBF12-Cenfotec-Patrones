using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI.Level_Loading
{
    public class LevelLoader : MonoBehaviour
    {
        private static string levelName;
        public static Animator animator;

        public void Start()
        {
            animator = GetComponent<Animator>();
        }

        public static void FadeToLevel(string plevelName)
        {
            levelName = plevelName;
            animator.SetTrigger("FadeOut");
        }

        public void OnFadeComplete()
        {
            SceneManager.LoadScene(levelName);
            animator.SetTrigger("FadeIn");
        }
    }
}

