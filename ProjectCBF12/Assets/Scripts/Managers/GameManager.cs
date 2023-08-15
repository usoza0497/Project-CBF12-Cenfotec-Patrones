using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Memento;
using Assets.Scripts.State;

public class GameManager : MonoBehaviour
{
    //Singleton pattern
    public static GameManager instance { get; private set; }

    //Private variables
    private MementoManager mementoManager = new MementoManager();
    private int globalCoinScore = 1000;
    private string currentLevel = "Level 1-1";
    private int levelCoinScore = 0;
    private int totalHealth = 6;
    private PlayerState playerState;

    //Public variables
    public HUD hud;

    //Getters
    public int GetTotalHealth
    {
        get { return totalHealth; }
        set { totalHealth = value; }
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
    }

    public PlayerState PlayerState
    {
        get { return playerState; }
        set { playerState = value; }
    }

    //Methods

    //Singleton pattern
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        playerState = new PlayerState();
    }

    void Start()
    {
        hud.UpdateCoinScore(levelCoinScore);
        hud.ResetHearts();
    }

    void Update()
    {
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
        if (totalHealth % 2 == 0)
        {
            hud.EmptyHeart(totalHealth / 2);
        }
        else
        {
            hud.HalfHeart(totalHealth / 2);
        }
    }

    public void GainHealth()
    {
        if (totalHealth >= 6) { return; }

        if (totalHealth % 2 == 0)
        {
            hud.HalfHeart(totalHealth / 2);
        }
        else
        {
            hud.FullHeart(totalHealth / 2);
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
        levelCoinScore = 0;
        hud.UpdateCoinScore(levelCoinScore);
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

    public void AddPowerPoints(int powerPoints)
    {
        PlayerState.AddPowerPoints(powerPoints);
        hud.UpdatePowerPoints(PlayerState.getPowerPoints());
    }

    public void VerifyState()
    {
        PlayerState.VerifyState(PlayerState);
    }
}