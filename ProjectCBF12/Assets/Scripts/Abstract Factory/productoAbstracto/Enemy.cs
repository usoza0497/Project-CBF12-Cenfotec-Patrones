using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float _EnemyHealth;
    protected string _EnemyName;
    protected string[] _MeleeAttacks;
    protected string[] _RangeAttacks;
    protected string _Log;

    public float EnemyHealth { get => _EnemyHealth; set => _EnemyHealth = value; }
    public string EnemyName { get => _EnemyName; set => _EnemyName = value; }
    public string[] MeleeAttacks { get => _MeleeAttacks; set => _MeleeAttacks = value; }
    public string[] RangeAttacks { get => _RangeAttacks; set => _RangeAttacks = value; }
    public string Log { get => _Log; set => _Log = value; }


    public string GetName()
    {
        return this._EnemyName;
    }

    public string MeleeAttack()
    {
        string attackUsed = null;
        if (CanAttack())
        {
            attackUsed = DoMeleeAttack();
        }
        return attackUsed;
    }

    public string RangeAttack()
    {
        string attackUsed = null;
        if (CanAttack())
        {
            attackUsed = DoRangeAttack();
        }
        return attackUsed;
    }
    public void ReceiveDamage(int damage)
    {
        bool isDead = ApplyDamage(damage);
        DamageReceived(isDead);
    }
    private bool ApplyDamage(int damage)
    {
        _EnemyHealth -= damage;
        return !IsAlive();
    }
    public IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    public bool IsAlive()
    {
        if (_EnemyHealth <= 0)
        {
            _EnemyHealth = 0;
            return false;
        }
        else
        {
            return true;
        }
    }
    public void SetMeleeAttacks()
    {
        string[] attackNames = null;

        switch (EnemyName)
        {
            case "PyronitiaBasico":
                attackNames = new string[] { "Attack1" };
                break;
            case "PyronitiaAvanzado":
                attackNames = new string[] { "Attack1", "Attack2" };
                break;
            case "Minotaur":
                attackNames = new string[] { "Attack1", "Attack2", "Attack3" };
                break;
                case "Ice Monster":
                attackNames = new string[] { "Attack" };
                break;
            default:
                attackNames = new string[] { "Punch", "Kick", "Headbutt" };
                break;
        }

        _MeleeAttacks = attackNames;
    }

    public void SetRangeAttacks()
    {
        string[] attackNames = null;

        switch (EnemyName)
        {
            case "PyronitiaPistolero":
                attackNames = new string[] { "Attack3" };
                break;
            case "PyronitiaVolador":
                attackNames = new string[] { "Attack3" };
                break;
                case "Minotaur":
                attackNames = new string[] { "Stomp" };
                break;
                case "Ice Monster":
                attackNames = new string[] { "Cast" };
                break;
            default:
                attackNames = new string[] { "Fireball", "Iceball", "Lightning" };
                break;
        }

        _RangeAttacks = attackNames;
    }

    bool CanAttack()
    {
        if (this._EnemyHealth > 0)
        {
            return true;
        }
        else { return false; }
    }

    public void DamageReceived(bool isDead)
    {
        if (isDead)
        {
            this._Log = this._EnemyName + " is dead";
        }
        else
        {
            this._Log = this._EnemyName + " received damage";
        }
    }
    //Abstract functions that must be implemented by the concrete classes
    protected abstract string DoMeleeAttack();
    protected abstract string DoRangeAttack();
}
