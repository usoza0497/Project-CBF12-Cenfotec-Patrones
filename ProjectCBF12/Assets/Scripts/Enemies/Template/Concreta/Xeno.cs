using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Scripts.Enemies.Template;

public class Xeno : Boss
{
    public void SetName() {
        this._BossName = "Xeno";
    }

    protected override bool CanAttack()
    {
        if(this._BossHealth > 0) {
            return true;
        } else {
            return false;
        }
    }

    protected override string DoMeleeAttack()
    {
        string attack = MeleeAttacks[Utilitario.RandomInt(0, MeleeAttacks.Length - 1)];
        this._Log = this._BossName + " used " + attack;
        return attack;
    }

    protected override string DoRangeAttack()
    {
        string attack = RangeAttacks[Utilitario.RandomInt(0, MeleeAttacks.Length - 1)];
        this._Log = this._BossName + " used " + attack;
        return attack;
    }

    protected override void DamageReceived(bool isDead)
    {
        if(isDead) {
            this._Log = this._BossName + " is dead";
        } else {
            this._Log = this._BossName + " received damage";
        }
    }
}
