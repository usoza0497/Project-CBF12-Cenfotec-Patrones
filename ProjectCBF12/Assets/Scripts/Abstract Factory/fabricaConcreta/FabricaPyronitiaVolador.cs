using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaPyronitiaVolador : FabricaEnemigos
{
    public Enemy crearPyronitia()
    {
        PyronitiaVolador pyronitia = new PyronitiaVolador();
        return pyronitia;
    }
}
