using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]
	public float Speed;

	public float StartHealth = 100;

	private float Health;

	public int worth = 100;

	public GameObject enemyDeathEffect;

	public Image healthBar;

	private bool isDead = false;

	private void Start()
	{
		Speed = startSpeed;
		Health = StartHealth;
	}

	// Update is called once per frame
	public void takeDamage(float damage)
	{
		Health -= damage;
		healthBar.fillAmount = Health / StartHealth;
		if (Health <= 0 && !isDead)
		{
			Die();
		}
	}

	void Die()
	{
		isDead = true;
		WaveSpawner.EnemiesAlive--;
		GameObject deathEffect = Instantiate(enemyDeathEffect, transform.position, transform.rotation);
		PlayerStats.Money += worth;
		Destroy(gameObject);
		Destroy(deathEffect, 1f);
	}

	public void Slow(float slowPercentage)
	{
		Speed = (startSpeed * (100f-slowPercentage))/100f;
	}
}
