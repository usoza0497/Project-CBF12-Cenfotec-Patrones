using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton pattern
    public static GameManager instance { get; private set; }

    //Private variables
    private int totalCoinScore = 0;
    private int totalHealth = 3;

    //Public variables
    public HUD hud;

    //Getters
    public int GetTotalHealth
    {
        get { return totalHealth; }
    }

    public int TotalCoinScore
    {
        get { return totalCoinScore; }
    }

    //Methods

    //Singleton pattern
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
            Debug.LogWarning("Duplicate GameManager destroyed.");
        }
    }

    void Start()
    {
        hud.UpdateCoinScore(totalCoinScore);
        hud.ResetHearts();
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level Map")
        {
            hud.gameObject.SetActive(false);
        } else
        { 
            hud.gameObject.SetActive(true);
        }
    }
    
    public void AddCoinScore(int coinScore)
    {
        totalCoinScore += coinScore;
        hud.UpdateCoinScore(totalCoinScore);
    }

    public void LoseHealth()
    {
        if (totalHealth <= 0) { return; }

        totalHealth--;
        hud.EmptyHeart(totalHealth);
    }

    public void GainHealth()
    {
        hud.FullHeart(totalHealth);
        totalHealth++;
    }

    public void ResetHealth()
    {
        totalHealth = 3;
        hud.ResetHearts();
    }

    public void ResetCoinScore()
    {
        totalCoinScore = 0;
        hud.UpdateCoinScore(totalCoinScore);
    }

    public void ResetGame()
    {
        ResetHealth();
        ResetCoinScore();
    }
}
