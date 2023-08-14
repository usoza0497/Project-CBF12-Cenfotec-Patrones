using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI coinScoreText;
    public RectTransform coinScoreObject;
    public RectTransform healthObject;
    public RectTransform timerObject;
    public GameObject[] hearts;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Slider BossHealthBar;


    public void Update()
    {
        ChangeHudAppearance();
    }

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

    public void HalfHeart(int heartIndex)
    {
        Image heartImage = hearts[heartIndex].GetComponent<Image>();
        heartImage.sprite = halfHeart;
    }

    public void ResetHearts()
    {
        foreach (GameObject heart in hearts)
        {
            Image heartImage = heart.GetComponent<Image>();
            heartImage.sprite = fullHeart;
        }
    }

    public void UpdateBossHealthBar(float health)
    {
        BossHealthBar.value = health;
    }

    public void ChangeHudAppearance()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName.Contains("Boss"))
        {
            coinScoreObject.gameObject.SetActive(false);
            BossHealthBar.gameObject.SetActive(true);
            timerObject.gameObject.SetActive(false);
        }
        else if (sceneName.Contains("Map") || sceneName.Contains("Store"))
        {
            coinScoreText.text = GameManager.instance.GlobalCoinScore.ToString();
            coinScoreObject.gameObject.SetActive(true);
            healthObject.gameObject.SetActive(false);
            BossHealthBar.gameObject.SetActive(false);
            timerObject.gameObject.SetActive(false);
        }
        else
        {
            coinScoreObject.gameObject.SetActive(true);
            BossHealthBar.gameObject.SetActive(false);
            timerObject.gameObject.SetActive(true);
            healthObject.gameObject.SetActive(true);
        }
    }
}