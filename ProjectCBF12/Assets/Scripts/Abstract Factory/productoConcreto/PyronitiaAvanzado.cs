using Assets.Resources.Scripts.Enemies.Template;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyronitiaAvanzado : Enemy
{
    public PyronitiaAvanzado()
    {
        this._EnemyHealth = 250f;
    }
    public void SetName()
    {
        this._EnemyName = "PyronitiaAvanzado";
    }
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
