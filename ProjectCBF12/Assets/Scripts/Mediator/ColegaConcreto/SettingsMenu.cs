using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Mediator;

namespace Assets.Scripts.Mediator{
public class SettingsMenu : IMenu
{

    public AudioMixer audioMixer;

    public GameObject SettingsMenuPanel;

    /*Métodos del Mediador*/

    public override void Hide(){
        SettingsMenuPanel.SetActive(false);
    }

    public override void Show(){
        SettingsMenuPanel.SetActive(true);
    }

    /*Metodos propios del menú settings*/
    public void PauseMenu(){
        _mediator.GoToPauseMenu();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

        public void SetVolume(float volumen)
    {
        audioMixer.SetFloat("volumen", volumen);
    }
    }
}