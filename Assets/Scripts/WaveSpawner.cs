using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int ExistingEnemies = 0;
    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    public GameObject startWaveButton;
    public static List<GameObject> enemies = new List<GameObject>();

    public Text gameCountDown; 

    void Update()
    {
        if(ExistingEnemies > 0)
        {
            return; 
        }

        if (countdown <= 0f)
        {
            if(waveIndex > 0 && !StartNextWave.startNextWave)
            {
                //game object start next wave button 
                startWaveButton.SetActive(true);
            }

            if((StartWave.a == 1 && waveIndex == 0) || StartNextWave.startNextWave)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                StartNextWave.startNextWave = false;
                return;
            }
        }

        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.numberOfEnemies; i++)
        {
            SpawnEnemy(wave.Enemy);
            yield return new WaitForSeconds(1f/wave.spawnRate);
        }

        waveIndex++;
        if (waveIndex == waves.Length) {
            GameManager.gameWon = true; 
            this.enabled = false;
        }

    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        ExistingEnemies++;
    }

}
