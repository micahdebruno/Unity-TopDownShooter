﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    [System.Serializable]
    public class Wave
    {   
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }
    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;

    private bool finishedSpawn;
    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;
    public GameObject boss;
    public Transform bossSpawnPoint;
    public GameObject healthBar;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
	}
	
	// Update is called once per frame
	void Update () {
		if(finishedSpawn == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finishedSpawn = false;
            if(currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else {
                Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
                healthBar.SetActive(true);
            }
        }
	}
    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }
    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];
        for(int i = 0; i < currentWave.count; i++)
        {
            if(player == null)
            {
                yield break;
            }
            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);
            if(i == currentWave.count - 1)
            {
                finishedSpawn = true;
            }
            else { finishedSpawn = false; }
            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }
    }
}
