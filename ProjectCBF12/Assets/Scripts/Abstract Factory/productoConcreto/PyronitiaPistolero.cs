using Assets.Resources.Scripts.Enemies.Template;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyronitiaPistolero : Enemy
{
    public PyronitiaPistolero()
    {
        this._EnemyHealth = 100f;
    }
    public void SetName()
    {
        this._EnemyName = "PyronitiaPistolero";
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
