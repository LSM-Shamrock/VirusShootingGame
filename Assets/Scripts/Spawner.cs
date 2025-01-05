using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemyOriginals = new List<GameObject>();
    public List<GameObject> bloodCellOriginals = new List<GameObject>();
    public List<GameObject> itemOriginals = new List<GameObject>();

    private float enemySpawnDelay = 2f;
    private float bloodCellSpawnDelay = 5f;
    private float itemSpawnDelay = 10f;

    private void Awake()
    {
        Stage.spawner = this;
    }

    private void Start()
    {
        StartCoroutine(EnemySpawnStart());
        StartCoroutine(BloodCellSpawnStart());
        StartCoroutine(ItemSpawnStart());
    }

    private IEnumerator EnemySpawnStart()
    {
        if (enemyOriginals.Count == 0)
            yield break;

        while (true)
        {
            yield return new WaitForSeconds(enemySpawnDelay * Random.Range(0.9f, 1.1f));

            GameObject original = enemyOriginals[Random.Range(0, enemyOriginals.Count)];
            Vector3 position = new Vector3(Random.Range(-4f, 4f), 9, 0);
            Quaternion rotation = Quaternion.Euler(Vector3.zero);

            Stage.poolManager.SpawnObject(original, position, rotation);
        }
    }

    private IEnumerator BloodCellSpawnStart()
    {
        if (bloodCellOriginals.Count == 0)
            yield break;

        while (true)
        {
            yield return new WaitForSeconds(bloodCellSpawnDelay * Random.Range(0.9f, 1.1f));

            GameObject original = bloodCellOriginals[Random.Range(0, bloodCellOriginals.Count)];
            Vector3 position = new Vector3(Random.Range(-4f, 4f), 9, 0);
            Quaternion rotation = Quaternion.Euler(Vector3.zero);

            Stage.poolManager.SpawnObject(original, position, rotation);
        }
    }

    private IEnumerator ItemSpawnStart()
    {
        if (itemOriginals.Count == 0)
            yield break;

        while (true)
        {
            yield return new WaitForSeconds(itemSpawnDelay * Random.Range(0.9f, 1.1f));

            GameObject original = itemOriginals[Random.Range(0, itemOriginals.Count)];
            Vector3 position = new Vector3(Random.Range(-4f, 4f), 9, 0);
            Quaternion rotation = Quaternion.Euler(Vector3.zero);

            Stage.poolManager.SpawnObject(original, position, rotation);
        }
    }

}
