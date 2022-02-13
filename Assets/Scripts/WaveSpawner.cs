using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform enemyVariantPrefab;
    public Button waveButton;
    float spawnRate;
    public Transform spawnPoint;
    uint nextWave = 0;
    private float searchCountdown = 1f;

    [System.Serializable]
    public class Wave
    {
        public Transform[] enemies;
    }

    public Wave[] waves;

    private void Start()
    {
        spawnRate = 1f;
    }

    private void Update()
    {
        if (!EnemiesAlive())
        {
            waveButton.gameObject.SetActive(true);
        }
    }

    bool EnemiesAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown > 0f)
        {
            return true;
        }
        searchCountdown = 1f;
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            return true;
        }
        return false;
    }

    public void StartWaveButtonPress()
    {
        StartCoroutine(SpawnWave(waves[0]));
    }

    public IEnumerator SpawnWave(Wave _wave)
    {
        for (int i = 0; i < _wave.enemies.Length; i++)
        {
            SpawnEnemy(_wave.enemies[i]);
            yield return new WaitForSeconds(1f / spawnRate);
        }
        yield break;
    }

    public void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
