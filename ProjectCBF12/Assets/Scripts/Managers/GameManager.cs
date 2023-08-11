using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Memento;

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

    public int LevelCoinScore
    {
        get { return levelCoinScore; }
        set { levelCoinScore = value; }
    }

    public int GlobalCoinScore
    {
        get { return globalCoinScore; }
        set { globalCoinScore = value; }
    }

    public string CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }

    public MementoManager MementoManager
    {
        get { return mementoManager; }
        set { mementoManager = value; }
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
        }
    }

    internal void UpdateBossHealthBar(float v)
    {
        throw new NotImplementedException();
    }

    void Start()
    {
        hud.UpdateCoinScore(levelCoinScore);
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
        levelCoinScore += coinScore;
        hud.UpdateCoinScore(levelCoinScore);
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
        levelCoinScore = 0;
        hud.UpdateCoinScore(levelCoinScore);
    }

    public void ResetGame()
    {
        ResetHealth();
        ResetCoinScore();
    }
}
