using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaPyronitiaBasico : Enemigos
{
    public Enemy crearPyronitia()
    {
        PyronitiaBasico pyronitia = new PyronitiaBasico();
        return pyronitia;
    }
}
