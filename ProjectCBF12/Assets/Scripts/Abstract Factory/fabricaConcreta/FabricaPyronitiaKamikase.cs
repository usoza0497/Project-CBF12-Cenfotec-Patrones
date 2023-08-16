using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaPyronitiaKamikase : FabricaEnemigos
{
    public Enemy crearPyronitia()
    {
        PyronitiaKamikase pyronitia = new PyronitiaKamikase();
        return pyronitia;
    }
}
