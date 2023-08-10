using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.UI.Level_Loading;

public class IntroMenu : MonoBehaviour
{
    public void LoadGame() 
    {
            LevelLoader.FadeToLevel("Level Map");
    }
}
