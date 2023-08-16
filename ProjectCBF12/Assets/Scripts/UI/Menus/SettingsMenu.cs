using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.UI.Menus;
using Assets.Scripts.Mediator;

public class SettingsMenu : MonoBehaviour
{
    private MenuMediator _mediator;

    public AudioMixer audioMixer;

    public GameObject SettingsMenuPanel;

    /*Métodos del Mediador*/
    public void Configure(MenuMediator menuMediator){
            _mediator = menuMediator;
    }

    public void Hide(){
        SettingsMenuPanel.SetActive(false);
    }

    public void Show(){
        SettingsMenuPanel.SetActive(true);
    }
    public void PauseMenu(){
        _mediator.GoToPauseMenu();
    }


    /*Metodos propios del menú settings*/
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetMasterVolume(float volumen)
    {
        audioMixer.SetFloat("MasterVolume", volumen);
    }
        public void SetMusicVolume(float volumen)
    {
        audioMixer.SetFloat("MusicVolume", volumen);
    }
        public void SetEffectsVolume(float volumen)
    {
        audioMixer.SetFloat("EffectsVolume", volumen);
    }


}
