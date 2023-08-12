using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
}

public class PlatformsCommand : ICommand
{
    private List<GameObject> platforms;

    public PlatformsCommand(List<GameObject> platforms)
    {
        this.platforms = platforms;
    }

    public void Execute()
    {
        foreach (GameObject platform in platforms)
        {
            platform.SetActive(!platform.activeSelf);
        }
    }
}
