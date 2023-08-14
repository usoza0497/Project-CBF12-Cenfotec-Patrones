using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaPyronitiaBasico : FabricaEnemigos
{
    public Enemy crearPyronitia()
    {
        PyronitiaBasico pyronitia = new PyronitiaBasico();
        return pyronitia;
    }
}
