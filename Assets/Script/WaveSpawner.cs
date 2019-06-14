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
	public Text waveText;

    void Update()
    {
        if (countdown <= 0f)
        {
			waveText.CrossFadeAlpha(1, 0, true);
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
		const string V = "Countdown till next wave: ";
		waveCountdownText.text = V + Mathf.Round(countdown).ToString();
    }

    IEnumerator spawnWave()
    {
        waveIndex++;
		waveText.text = "Wave: " + waveIndex.ToString();
		waveText.CrossFadeAlpha(0, 2f,true);
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
