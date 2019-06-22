using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	public static int EnemiesAlive = 0;

	public Wave[] waves;

    public Transform spawnPoints;

	private Enemy enemy;

	private float enemyStartHealth;

    public float timeBetweenWaves;

    public float countdown;

    public int waveIndex;

    public Text waveCountdownText;

	public Text waveText;

	void Update()
    {

		if (EnemiesAlive > 0)
		{
			return;
		}
        if (countdown <= 0f)
        {
			waveText.CrossFadeAlpha(1, 0, true);
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator spawnWave()
    {
		PlayerStats.Rounds = waveIndex;
		Wave wave = waves[waveIndex];
		waveText.text = "Wave: " + (waveIndex+1).ToString();
		waveText.CrossFadeAlpha(0, 2f,true);

        for (int i = 1; i <= wave.count; i++)
        {
            spawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
		waveIndex++;
		if(waveIndex == waves.Length)
		{
			Debug.Log("Level Won!!");
			this.enabled = false;
		}
	}

    void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoints.position, spawnPoints.rotation);
		EnemiesAlive++;
    }
}
