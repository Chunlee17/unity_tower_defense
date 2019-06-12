using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float Speed = 10f;
	public int wavepointIndex = 0;
	public Transform target;
	void Start () {
		target = Waypoints.points[0];
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = target.position - transform.position;
		transform.Translate(direction.normalized * Speed * Time.deltaTime,Space.World);
		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			getNextWayPoints();
		}

	}
	void getNextWayPoints()
	{
		if(wavepointIndex >= Waypoints.points.Length - 1)
		{
			Destroy(gameObject);
			return;
		}
		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];

	}
}
