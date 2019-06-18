using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

	public int wavepointIndex = 0;

	public Transform waypointTarget;

	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();
		waypointTarget = Waypoints.points[0];
	}
	void Update()
	{
		Vector3 direction = waypointTarget.position - transform.position;
		transform.Translate(direction.normalized * enemy.Speed * Time.deltaTime, Space.World);
		if (Vector3.Distance(transform.position, waypointTarget.position) <= 0.4f)
		{
			getNextWayPoints();
		}

		enemy.Speed = enemy.startSpeed;

	}

	
	void getNextWayPoints()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
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
