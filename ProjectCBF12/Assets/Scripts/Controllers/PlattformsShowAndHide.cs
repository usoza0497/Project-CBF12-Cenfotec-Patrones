using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlattformsShowAndHide : MonoBehaviour
{
    public List<GameObject> platforms;
    private PlayerController player;
    private ICommand platformsCommand;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        platformsCommand = new PlatformsCommand(platforms);
        player.onJumpPlattformHide += ExecuteCommand;
    }

    private void ExecuteCommand(object sender, EventArgs e)
    {
        platformsCommand.Execute();
    }

}
