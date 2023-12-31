using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject pyronitiaBasicoPrefab;
    [SerializeField] private GameObject pyronitiaAvanzadoPrefab;
    [SerializeField] private GameObject pyronitiaKamikasePrefab;
    [SerializeField] private GameObject pyronitiaVoladorPrefab;

    [SerializeField] private Transform positionsParent;
    public int opcionPyronitia;

    private static List<Enemy> arEnemy = new List<Enemy>();

    private HashSet<Transform> spawnedPoints = new HashSet<Transform>();

    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        foreach (Transform spawnPoint in positionsParent)
        {
            if (!spawnedPoints.Contains(spawnPoint)) // Si no hemos spawnado en este punto antes.
            {
                string enemyType = ProcesarEnemigo(opcionPyronitia);

                GameObject newEnemyPrefab = null;

                if (enemyType.Equals("PyronitiaBasico"))
                {
                    newEnemyPrefab = pyronitiaBasicoPrefab;
                }
                else if (enemyType.Equals("PyronitiaAvanzado"))
                {
                    newEnemyPrefab = pyronitiaAvanzadoPrefab;
                } else if (enemyType.Equals("PyronitiaKamikase"))
                {
                    newEnemyPrefab = pyronitiaKamikasePrefab;

                } else if (enemyType.Equals("PyronitiaVolador"))
                {
                    newEnemyPrefab = pyronitiaVoladorPrefab;
                } 

                if (newEnemyPrefab != null)
                {
                    GameObject newEnemy = Instantiate(newEnemyPrefab, spawnPoint.position, Quaternion.identity);
                    spawnedPoints.Add(spawnPoint); // Marcar este punto como utilizado.
                }
            }
        }
    }


    public static string CrearFabricaEnemigos(FabricaEnemigos enemyFabrica)
    {
        Enemy objEnemy = enemyFabrica.crearPyronitia();
        addEnemy(objEnemy);
        return objEnemy.GetName();
    }
    private static void addEnemy (Enemy objEnemy) { arEnemy.Add(objEnemy); }

    public static string ProcesarEnemigo(int opcionEnemigo)
    {
        FabricaEnemigos fabricaEnemigos;
        string nombreEnemigo;
        switch (opcionEnemigo)
        {
            case 1:
                fabricaEnemigos = new FabricaPyronitiaBasico();
                nombreEnemigo = CrearFabricaEnemigos(fabricaEnemigos);
                break;

            case 2:
                fabricaEnemigos = new FabricaPyronitiaAvanzado();
                nombreEnemigo = CrearFabricaEnemigos(fabricaEnemigos);
                break;
            case 3:
                fabricaEnemigos = new FabricaPyronitiaKamikase();
                nombreEnemigo = CrearFabricaEnemigos(fabricaEnemigos);
                break;
            case 4:
                fabricaEnemigos = new FabricaPyronitiaVolador();
                nombreEnemigo = CrearFabricaEnemigos(fabricaEnemigos);
                break;
            default:
                fabricaEnemigos =new FabricaPyronitiaBasico();
                nombreEnemigo = CrearFabricaEnemigos(fabricaEnemigos);
                break;
        }
        
        return nombreEnemigo;

    }
}
