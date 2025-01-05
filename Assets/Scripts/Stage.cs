using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public static int stage = 1;

    public static int score = 0;
    
    public static int maxPain = 100;
    public static int currentPain = 0;
    
    public static Player player;

    public static Spawner spawner;

    public static PoolManager poolManager;

    public static Enemy boss;

    [SerializeField] private GameObject stage1BossOriginal;
    [SerializeField] private GameObject stage2BossOriginal;

    private void Awake()
    {
        score = 0;

        if (stage == 1)
            currentPain = 10;
        else if (stage == 2)
            currentPain = 30;
            
        Invoke("BossSpawn", 10f);
    }

    private void BossSpawn()
    {
        Vector3 spawnPosition = new Vector3(0, 9, 0);
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);

        if (stage == 1)
        {
            poolManager.SpawnObject(stage1BossOriginal, spawnPosition, spawnRotation);
        }
        else if (stage == 2)
        {
            poolManager.SpawnObject(stage2BossOriginal, spawnPosition, spawnRotation);
        }
    }
}
