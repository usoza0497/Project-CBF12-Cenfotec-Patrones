using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    public void SelectLevel(string plevelName)
    {
        SceneManager.LoadScene(plevelName);
    }

    public void OnClick()
    {
        string levelName = GetComponentInChildren<TMP_Text>().text;
        SelectLevel(levelName);
    }
}
