using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaPyronitiaPistolero : FabricaEnemigos
{
    public Enemy crearPyronitia()
    {
        PyronitiaPistolero pyronitia = new PyronitiaPistolero();
        return pyronitia;
    }
}
