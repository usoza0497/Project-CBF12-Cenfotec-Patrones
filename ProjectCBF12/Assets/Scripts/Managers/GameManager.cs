using System;
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
    private int totalHealth = 6;

    //Public variables
    public HUD hud;

    //Getters
    public int GetTotalHealth
    {
        get { return totalHealth; }
        set { totalHealth = value; }
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
        ToggleHUD();
    }

    public void ToggleHUD()
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
        if (totalHealth % 2 == 0)
        {
            hud.EmptyHeart(totalHealth/2);
        } else
        {
            hud.HalfHeart(totalHealth/2);
        }
    }

    public void GainHealth()
    {
        if (totalHealth >= 6) { return; }

        if (totalHealth % 2 == 0)
        {
            hud.HalfHeart(totalHealth/2);
        } else
        {
            hud.FullHeart(totalHealth/2);
        }

        totalHealth++;
    }

    public void ResetHealth()
    {
        totalHealth = 6;
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
        UpdateBossHealthBar(1);
    }

    public void UpdateBossHealthBar(float health)
    {
        hud.UpdateBossHealthBar(health);
    }
}
