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

    void OnLevelCompletete()
    {
        nextWave++;
        if (nextWave > waves.Length - 1)
        {
            //Game Won!
            print("GAME WON. Looping from first wave");
            nextWave = 0;
        }
        waveButton.gameObject.SetActive(true);
    }

    public void StartWaveButtonPress()
    {
        StartCoroutine(SpawnWave(waves[nextWave]));
    }

    public IEnumerator SpawnWave(Wave _wave)
    {
        for (int i = 0; i < _wave.enemies.Length; i++)
        {
            SpawnEnemy(_wave.enemies[i]);
            yield return new WaitForSeconds(1f / spawnRate);
        }
        OnLevelCompletete();
        yield break;
    }

    public void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
    }
}