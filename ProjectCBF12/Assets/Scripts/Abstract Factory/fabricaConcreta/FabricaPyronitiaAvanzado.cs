using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaPyronitiaAvanzado : Enemigos
{
    public Jefes crearJefes()
    {
        throw new System.NotImplementedException();
    }

    public Pyronitia crearPyronitia()
    {
        PyronitiaAvanzado pyronitia = new PyronitiaAvanzado();
        return pyronitia;
    }
}
