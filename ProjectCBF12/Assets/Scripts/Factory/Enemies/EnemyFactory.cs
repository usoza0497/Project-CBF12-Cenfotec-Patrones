using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory
{
    public Enemy CreateEnemy(string enemyType)
    {
        Enemy enemy = null;

        // Lógica para crear enemigos basada en el tipo especificado
        switch (enemyType)
        {
            case "Pyronitia":
                enemy = new Pyronitia();
                break;
            default:
                Debug.LogError("Tipo de enemigo desconocido: " + enemyType);
                break;
        }

        return enemy;
    }
}
