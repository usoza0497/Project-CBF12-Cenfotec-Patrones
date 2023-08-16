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

    public TMP_Dropdown resolutionDropdown;

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
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = Screen.resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, false);
    }
        public void SetVolume(float volumen)
    {
        audioMixer.SetFloat("volumen", volumen);
    }


}
