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

    
    Resolution[] resolutions;

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
    void Start() {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
    
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = Screen.resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volumen)
    {
        audioMixer.SetFloat("volumen", volumen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


}
