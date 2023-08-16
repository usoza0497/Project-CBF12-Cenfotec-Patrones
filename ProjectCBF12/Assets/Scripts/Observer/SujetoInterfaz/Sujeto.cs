using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Scripts.Observer
{
public abstract class Sujeto : MonoBehaviour
{
    /*No lleva lista de objetos debido al event Action*/
    public abstract void Notify();
}

}
