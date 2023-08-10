using System.Collections;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    protected float _BossHealth = 100f;
    protected string _BossName;
    protected string[] _MeleeAttacks;
    protected string[] _RangeAttacks;
    protected string _Log;

    public float BossHealth {get => _BossHealth; set => _BossHealth = value;}
    public string BossName {get => _BossName; set => _BossName = value;}
    public string[] MeleeAttacks {get => _MeleeAttacks; set => _MeleeAttacks = value;}
    public string[] RangeAttacks {get => _RangeAttacks; set => _RangeAttacks = value;}
    public string Log {get => _Log; set => _Log = value;}

    public string MeleeAttack() {
        string attackUsed = null;
        if (CanAttack()) {
            attackUsed = DoMeleeAttack();
        }
        return attackUsed;
    }

    public string RangeAttack() {
        string attackUsed = null;
        if (CanAttack()) {
            attackUsed = DoRangeAttack();
        }
        return attackUsed;
    }

    public void ReceiveDamage(int damage) {
        bool isDead = ApplyDamage(damage);
        DamageReceived(isDead); 
    }

    private bool ApplyDamage(int damage) {
        _BossHealth -= damage;
        return !IsAlive();
    }

    public bool IsAlive() {
        if(_BossHealth <= 0) {
            _BossHealth = 0;
            return false;
        } else {
            return true;
        }
    }

    public IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds);
    }

    public void SetMeleeAttacks()
    {
        string[] attackNames = null;

        switch(BossName) {
            case "Xeno":
                attackNames = new string[] {"Attack1", "Attack2"};
                break;
            case "Minotaur":
                attackNames = new string[] {"Attack1", "Attack2", "Attack3"};
                break;
            default:
                attackNames = new string[] {"Punch", "Kick", "Headbutt"};
                break;
        }

         _MeleeAttacks = attackNames;
    }

    public void SetRangeAttacks()
    {
        string[] attackNames = null;

        switch(BossName) {
            case "Xeno":
                attackNames = new string[] {"Attack3"};
                break;
            case "Minotaur":
                attackNames = new string[] {"Stomp"};
                break;
            default:
                attackNames = new string[] {"Fireball", "Iceball", "Lightning"};
                break;
        }

         _RangeAttacks = attackNames;
    }

    //Abstract functions that must be implemented by the concrete classes
    protected abstract bool CanAttack();
    protected abstract string DoMeleeAttack();
    protected abstract string DoRangeAttack();
    protected abstract void DamageReceived(bool isDead);
}
