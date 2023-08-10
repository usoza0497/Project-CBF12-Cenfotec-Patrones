using System.Collections;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject pyronitiaBasicoPrefab;
    [SerializeField]
    private float intervaloPyronitiaBasico;
    [SerializeField]
    private Transform positionsParent; // Cambiado a Transform

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(intervaloPyronitiaBasico, pyronitiaBasicoPrefab));
    }

    private IEnumerator SpawnEnemy(float intervalo, GameObject enemy)
    {
        while (true) // Evita el bucle infinito anterior
        {
            foreach (Transform spawnPoint in positionsParent)
            {
                GameObject newEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(intervalo);
            }
        }
    }
}
