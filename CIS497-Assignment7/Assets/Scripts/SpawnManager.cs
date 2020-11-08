/*
John Mordi
Assignment #7
Manages the spawn of enemies and powerups
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public Text winLossText;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(waveNumber == 10 && enemyCount == 0)
        {
            WinLossManager.gameOver = true;
            WinLossManager.win = true;
        }
        if (enemyCount == 0 && !WinLossManager.gameOver && WinLossManager.gameStart)
        {
            waveNumber++;
            winLossText.text = "Wave: " + waveNumber;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup(1);
        }
        
    }
}
