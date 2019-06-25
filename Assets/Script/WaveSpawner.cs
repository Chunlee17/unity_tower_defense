using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public GameManager gameManager;

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
		waveText.text = string.Format("Total Waves: {0}\n Current wave: {1}\n Enemy Alives: {2}", waves.Length, waveIndex, EnemiesAlive);
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length && PlayerStats.Lives > 0)
		{
			gameManager.WinLevel();
			this.enabled = false;
			return;
		}

		if (countdown <= 0f)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;
			waveIndex++;
		}
        countdown -= Time.deltaTime;
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator spawnWave()
    {
		PlayerStats.Rounds = waveIndex;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count;

        for (int i = 1; i <= wave.count; i++)
        {
            spawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
	}

    void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoints.position, spawnPoints.rotation);
    }
}
