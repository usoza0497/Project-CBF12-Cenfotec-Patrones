using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject pyronitiaBasicoPrefab;
    [SerializeField] private float intervaloPyronitiaBasico;

    [SerializeField] private GameObject pyronitiaAvanzadoPrefab;
    [SerializeField] private float intervaloPyronitiaAvanzado;

    [SerializeField] private Transform positionsParent;
    public int opcionPyronitia;

    private static List<Enemy> arEnemy = new List<Enemy>();

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            foreach (Transform spawnPoint in positionsParent)
            {
                string enemyType = ProcesarEnemigo(opcionPyronitia);
                Debug.Log("Enemy obtenido de ProcesarEnemigo" + enemyType);

                GameObject newEnemyPrefab = null;
                float spawnInterval = 0f;

                if (enemyType.Equals("PyronitiaBasico"))
                {
                    newEnemyPrefab = pyronitiaBasicoPrefab;
                    spawnInterval = intervaloPyronitiaBasico;
                }
                else if (enemyType.Equals("PyronitiaAvanzado"))
                {
                    newEnemyPrefab = pyronitiaAvanzadoPrefab;
                    spawnInterval = intervaloPyronitiaAvanzado;
                }

                Debug.Log("newEnemyPrefab: " + pyronitiaBasicoPrefab);
                Debug.Log("spawnInterval: " + intervaloPyronitiaBasico);

                if (newEnemyPrefab != null)
                {
                    GameObject newEnemy = Instantiate(newEnemyPrefab, spawnPoint.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnInterval);
                }

                Debug.Log(enemyType);
            }
        }
    }


    public static string CrearFabricaEnemigos(FabricaEnemigos enemyFabrica)
    {
        Enemy objEnemy = enemyFabrica.crearPyronitia();
        addEnemy(objEnemy);
        Debug.Log("CrearFabricaEnemigos, valor que devuelve:" + objEnemy.GetName());
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
                fabricaEnemigos = new FabricaPyronitiaPistolero();
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
        
        Debug.Log("Nombre de Enemigo a Spawnear: " + nombreEnemigo);
        return nombreEnemigo;

    }
}
