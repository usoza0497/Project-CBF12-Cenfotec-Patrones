using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Scripts.Enemies.Template;

public class IceMonster : Enemy
{
    public IceMonster()
    {
        this.EnemyHealth = 200f;
    }

    public void SetName() {
        this._EnemyName = "Ice Monster";
    }

    protected override string DoMeleeAttack()
    {
        string attack = MeleeAttacks[Utilitario.RandomInt(0, MeleeAttacks.Length)];
        this._Log = this._EnemyName + " used " + attack;
        return attack;
    }

    protected override string DoRangeAttack()
    {
        string attack = RangeAttacks[Utilitario.RandomInt(0, RangeAttacks.Length - 1)];
        this._Log = this._EnemyName + " used " + attack;
        return attack;
    }
}
