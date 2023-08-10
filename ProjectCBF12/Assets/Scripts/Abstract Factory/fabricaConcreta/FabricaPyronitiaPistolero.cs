using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaPyronitiaPistolero : Enemigos
{
    public Jefes crearJefes()
    {
        throw new System.NotImplementedException();
    }

    public Pyronitia crearPyronitia()
    {
        PyronitiaPistolero pyronitia = new PyronitiaPistolero();
        return pyronitia;
    }
}
