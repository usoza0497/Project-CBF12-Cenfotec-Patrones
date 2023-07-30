using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI coinScoreText;

    void Update()
    {
        coinScoreText.text = GameManager.instance.TotalCoinScore.ToString();
    }
}
