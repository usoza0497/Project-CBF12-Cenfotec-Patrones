using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public int potionPrice;
    public int potionPowerPoints;
    private bool isBought = false;

    public bool IsBought
    {
        get { return isBought; }
        set { isBought = value; }
    }

    
}
