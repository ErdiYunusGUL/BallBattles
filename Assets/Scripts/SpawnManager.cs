using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    public GameObject[] powerupPrefabs;
    public GameObject bossPrefab;
    public GameObject[] miniEnemyPrefabs;
    private float spawnRange = 9;
    public int enemyCount;
    public int powerupCount;
    public int waveNumber = 1;
    public int bossRound;
    
    private bool isSpawningPowerup = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        PowerupSpawnEnemyWave(1);
    }

    private void Update()
    {
        
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        powerupCount = GameObject.FindGameObjectsWithTag("Powerup").Length;

        if (enemyCount == 0 )
        {
            waveNumber++;

            if (waveNumber % bossRound ==0)
            {
                SpawnBossWave(waveNumber);
            }
            else
            {
                SpawnEnemyWave(waveNumber);
            }
        }

        if ( powerupCount == 0 && !isSpawningPowerup)
        {
            StartCoroutine(SpawnPowerupWithDelay(7));
        }
    }
    
    IEnumerator SpawnPowerupWithDelay(float delay)
    {
        isSpawningPowerup = true;
        yield return new WaitForSeconds(delay);
        PowerupSpawnEnemyWave(1);
        isSpawningPowerup = false;
    }
    void SpawnEnemyWave(int enemiesToSpawn )
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnemy], GenerateSpawnPosition(), enemyPrefabs[randomEnemy].transform.rotation);
        }
    }
    void PowerupSpawnEnemyWave(int powerupToSpawn)
    {

        int randomPowerup = Random.Range(0, powerupPrefabs.Length);
        for (int i = 0; i < powerupToSpawn; i++)
        {
            Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnBossWave(int currentRound)
    {
        int miniEnemysToSpawn;

        if (bossRound !=0)
        {
            miniEnemysToSpawn = currentRound / bossRound;
        }
        else
        {
            miniEnemysToSpawn = 1;
        }

        var boss =Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
        boss.GetComponent<Enemy>().miniEnemySpawnCount = miniEnemysToSpawn;
    }

    public void SpawnMiniEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomMini = Random.Range(0, miniEnemyPrefabs.Length);
            Instantiate(miniEnemyPrefabs[randomMini], GenerateSpawnPosition(), miniEnemyPrefabs[randomMini].transform.rotation);
        }
    }
}
