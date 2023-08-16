using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Observer;

public class MapManager : MonoBehaviour
{
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;

    void Start()
    {
        HidePanel();
        GameManager.instance.VerifyState();
        string message = "Basado en tus puntos de poder, tu estado actual es: ";
        
        switch(GameManager.instance.PlayerState.getState())
        {
            case "Normal":
                ChangeMessage(message + "\nEstado de Poder Verde - Nivel Inicial");
                break;
            case "Blue":
                ChangeMessage(message + "\nEstado de Poder Celeste - Potencia Creciente");
                break;
            case "Orange":
                ChangeMessage(message + "\nEstado de Poder Naranja - Impulso Ascendente");
                break;
            case "Pink":
                ChangeMessage(message + "\nEstado de Poder Rosa - Nebulosa Resplandeciente");
                break;
            case "Purple":
                ChangeMessage(message + "\nEstado de Poder Violeta - Fuerza Celestial Absoluta");
                break;
        }

        if(GameManager.instance.MementoManager.getLevelName() != null)
        {
            if(GameManager.instance.MementoManager.getLevelName().Contains("Store"))
            {
                ShowPanel();
            }
        }
    }

    private void ChangeMessage(string message)
    {
        messageText.text = message;
    }

    private void ShowPanel()
    {
        messagePanel.SetActive(true);
    }

    public void HidePanel()
    {
        messagePanel.SetActive(false);
    }


}
