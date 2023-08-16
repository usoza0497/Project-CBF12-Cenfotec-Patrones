using Assets.Resources.Scripts.Enemies.Template;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyronitiaVolador : Enemy
{
    public PyronitiaVolador()
    {
        this._EnemyHealth = 150f;
        this._EnemyName = "PyronitiaVolador";
    }
    public void SetName()
    {
        this._EnemyName = "PyronitiaVolador";
    }

    // Override SetRangeAttacks method if necessary

    protected override string DoMeleeAttack()
    {
        string attack = MeleeAttacks[Utilitario.RandomInt(0, MeleeAttacks.Length)];
        this._Log = this._EnemyName + " used " + attack;
        return attack;
    }

    protected override string DoRangeAttack()
    {
        return null;
    }
}
