using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaPyronitiaBasico : Enemigos
{
    public Jefes crearJefes()
    {
        throw new System.NotImplementedException();
    }

    public Pyronitia crearPyronitia()
    {
        PyronitiaBasico pyronitia = new PyronitiaBasico();
        return pyronitia;
    }
}
