using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.UI.Level_Loading;

public class StoreMenu : MonoBehaviour
{
    public void LoadMap() 
    {
            LevelLoader.FadeToLevel("Level Map");
    }
}
