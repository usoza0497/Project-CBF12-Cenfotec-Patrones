using Assets.Resources.Scripts.Enemies.Template;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyronitiaVolador : Enemy
{
    public PyronitiaVolador()
    {
        this._EnemyHealth = 150f;
    }
    public void SetName()
    {
        this._EnemyName = "PyronitiaVolador";
    }
    protected override string DoMeleeAttack()
    {
        return null;
    }

    protected override string DoRangeAttack()
    {
        string attack = RangeAttacks[Utilitario.RandomInt(0, MeleeAttacks.Length - 1)];
        this._Log = this._EnemyName + " used " + attack;
        return attack;
    }
}
