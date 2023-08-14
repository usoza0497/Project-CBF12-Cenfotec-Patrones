using Assets.Resources.Scripts.Enemies.Template;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyronitiaBasico : Enemy
{
    public PyronitiaBasico()
    {
        this._EnemyHealth = 50f;
        this._EnemyName = "PyronitiaBasico";
    }
    public void SetName()
    {
        this._EnemyName = "PyronitiaBasico";
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
