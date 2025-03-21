using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    private const int MAXENEMY = 5;
    private float SpawnRange = 9.0f;
    void Start()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyCtrl>().Length;
        if(enemyCount == 0)
        {
            waveNumber += 1;
            if(waveNumber > MAXENEMY)
            {
                waveNumber = MAXENEMY;
            }
            Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
            SpawnEnemyWave(waveNumber);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float SpawnPosX = Random.Range(-SpawnRange, SpawnRange);
        float SpawnPosZ = Random.Range(-SpawnRange, SpawnRange);
        Vector3 spawnPos = new Vector3(SpawnPosX, 0, SpawnPosZ);
        return spawnPos;
    }
}
