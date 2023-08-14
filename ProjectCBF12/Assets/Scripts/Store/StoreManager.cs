using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour
{
    public GameObject buyPanel;
    public TextMeshProUGUI buyPanelText;

    public void ChangeBuyPanelText(string text)
    {
        buyPanelText.text = text;
    }

    public void Buy(Potion selectedPotion)
    {
        if(GameManager.instance.GlobalCoinScore >= selectedPotion.potionPrice)
        {
            GameManager.instance.GlobalCoinScore -= selectedPotion.potionPrice;
            GameManager.instance.AddPowerPoints(selectedPotion.potionPowerPoints);
            ChangeBuyPanelText("Felicidades! Has comprado el objeto. Tus puntos de poder han aumentado.");
        }
        else
        {
            ChangeBuyPanelText("No tienes suficientes monedas para comprar el objeto. :(");
        }
        OpenBuyPanel();
    }

    public void OpenBuyPanel()
    {
        buyPanel.SetActive(true);
    }

    public void CloseBuyPanel()
    {
        buyPanel.SetActive(false);
    }
}
