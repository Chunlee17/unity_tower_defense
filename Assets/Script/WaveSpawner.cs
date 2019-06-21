using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrafab;
    public Transform spawnPoints;
	private Enemy enemy;
	private float enemyStartHealth;
    public float timeBetweenWaves;
    public float countdown;
    public int waveIndex;
    public Text waveCountdownText;
	public Text waveText;


	private void Start()
	{
		enemy = enemyPrafab.GetComponent<Enemy>();
	}
	void Update()
    {
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
        waveIndex++;
		PlayerStats.Rounds = waveIndex;
		waveText.text = "Wave: " + waveIndex.ToString();
		waveText.CrossFadeAlpha(0, 2f,true);
        for (int i = 0; i <= waveIndex; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        //Debug.Log("Wave incoming");
    }

    void spawnEnemy()
    {
		//enemy = enemyPrafab.GetComponent<Enemy>();
		//enemy.Health = enemyStartHealth + (waveIndex*50);
        Instantiate(enemyPrafab, spawnPoints.position, spawnPoints.rotation);
    }
}
