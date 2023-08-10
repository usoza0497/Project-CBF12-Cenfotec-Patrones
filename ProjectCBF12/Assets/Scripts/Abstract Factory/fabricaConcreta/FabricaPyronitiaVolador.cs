using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaPyronitiaVolador : Enemigos
{
    // Start is called before the first frame update
    public Jefes crearJefes()
    {
        throw new System.NotImplementedException();
    }

    public Pyronitia crearPyronitia()
    {
        PyronitiaVolador pyronitia = new PyronitiaVolador();
        return pyronitia;
    }
}
