using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrafab;
    public Transform spawnPoints;
    public float timeBetweenWaves;
    public float countdown;
    public float waveIndex;
    public Text waveCountdownText;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator spawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        //Debug.Log("Wave incoming");
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrafab, spawnPoints.position, spawnPoints.rotation);
    }
}
