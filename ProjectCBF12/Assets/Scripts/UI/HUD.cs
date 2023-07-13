using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI coinScoreText;
    public GameObject[] hearts;
    public Sprite emptyHeart;
    public Sprite fullHeart;

    public void UpdateCoinScore(int coinScore)
    {
        coinScoreText.text = coinScore.ToString();
    }

    public void EmptyHeart(int heartIndex)
    {
        Image heartImage = hearts[heartIndex].GetComponent<Image>();
        heartImage.sprite = emptyHeart;
    }

    public void FullHeart(int heartIndex)
    {
        Image heartImage = hearts[heartIndex].GetComponent<Image>();
        heartImage.sprite = fullHeart;
    }

    public void ResetHearts()
    {
        foreach (GameObject heart in hearts)
        {
            Image heartImage = heart.GetComponent<Image>();
            heartImage.sprite = fullHeart;
        }
    }
}
