using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]
	public float Speed;

	public float Health = 100;

	public int worth = 100;

	public GameObject enemyDeathEffect;

	private void Start()
	{
		Speed = startSpeed;
	}

	// Update is called once per frame
	public void takeDamage(float damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
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
