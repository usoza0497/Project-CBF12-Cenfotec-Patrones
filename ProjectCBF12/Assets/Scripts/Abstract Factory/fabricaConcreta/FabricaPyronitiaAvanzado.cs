using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaPyronitiaAvanzado : FabricaEnemigos
{
    public Enemy crearPyronitia()
    {
        PyronitiaAvanzado pyronitia = new PyronitiaAvanzado();
        return pyronitia;
    }
}
