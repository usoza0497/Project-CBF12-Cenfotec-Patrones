using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    private EnemyFactory enemyFactory;

    private void Start()
    {
        enemyFactory = new EnemyFactory();

        // Generar enemigos
        Enemy slimeEnemy = enemyFactory.CreateEnemy("Slime");
        slimeEnemy.Attack();

        Enemy goblinEnemy = enemyFactory.CreateEnemy("Goblin");
        goblinEnemy.Attack();
    }
}