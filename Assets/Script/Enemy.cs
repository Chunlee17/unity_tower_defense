using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float Speed = 10f;
	public int wavepointIndex = 0;
	public int Health = 100;
	public int moneyGained = 100;
	public GameObject enemyDeathEffect;
	public Transform waypointTarget;
	void Start () {
		waypointTarget = Waypoints.points[0];
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = waypointTarget.position - transform.position;
		transform.Translate(direction.normalized * Speed * Time.deltaTime,Space.World);
		if (Vector3.Distance(transform.position, waypointTarget.position) <= 0.4f)
		{
			getNextWayPoints();
		}

	}

	public void takeDamage(int damage)
	{
		Health -= damage;
		if(Health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		GameObject deathEffect = Instantiate(enemyDeathEffect, transform.position, transform.rotation);
		PlayerStats.Money += moneyGained;
		Destroy(gameObject);
		Destroy(deathEffect, 3f);
	}
	void getNextWayPoints()
	{
		if(wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}
		wavepointIndex++;
		waypointTarget = Waypoints.points[wavepointIndex];

	}

	void EndPath()
	{
		PlayerStats.Lives -= 1;
		Destroy(gameObject);
	}
}
