using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private int totalCoinScore = 0;

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
    
    public int TotalCoinScore
    {
        get { return totalCoinScore; }
    }

    public void AddCoinScore(int coinScore)
    {
        totalCoinScore += coinScore;
    }
}
