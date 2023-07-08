using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance { get; private set; }
    private string levelName;
    public Animator animator;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
            Debug.LogWarning("Duplicate LevelLoader destroyed.");
        }
    }

    public void FadeToLevel(string plevelName)
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

