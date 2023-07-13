using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyronitia : Enemy
{
    public override void Attack()
    {

    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}