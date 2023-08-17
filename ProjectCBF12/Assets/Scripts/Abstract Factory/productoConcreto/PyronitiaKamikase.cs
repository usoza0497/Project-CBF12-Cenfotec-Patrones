using Assets.Resources.Scripts.Enemies.Template;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyronitiaKamikase : Enemy
{
    public PyronitiaKamikase()
    {
        this._EnemyHealth = 100f;
        this._EnemyName = "PyronitiaKamikase";
    }
    public void SetName()
    {
        this._EnemyName = "PyronitiaKamikase";
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

     private void Update()
    {
        Die();
    }
}