using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlattformsShowAndHide : MonoBehaviour
{
    public List<GameObject> platforms;
    private PlayerController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.onJumpPlattformHide += Show;
    }


    private void Show(object sender, EventArgs e)
    {
        foreach(GameObject block in platforms)
        {
            block.SetActive(!block.activeSelf);
        }
    }
}
