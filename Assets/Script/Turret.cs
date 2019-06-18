using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
	private Enemy targetEnemy;

    [Header("General")]
    public float range = 10f;

	[Header("use bullets")]
    public float fireRate = 3f;
    private float fireCountdown = 0f;
	public GameObject bulletPrafab;

	[Header("Laser")]

	public float damageOverFrame;
	public bool useLaser = false;
	[Range(0, 100)]
	public float slowPercentage;

	public LineRenderer lineRenderer;

	[Header("Unity setup Field")]

	public Light impactLight;
	public ParticleSystem laserParticle;
    public string enemytag = "Enemy";
    public float turnSpeed = 10f;
    public Transform partToRotate;

    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.2f);
    }

    void Update()
    {
        if (target == null)
		{
			if (useLaser)
			{
				if (lineRenderer.enabled) {
					impactLight.enabled = false;
					laserParticle.Stop();
					lineRenderer.enabled = false;
				} 
			}
			return;
		} 
		LockOnTarget();
		if (useLaser)
		{
			Laser();
		}
		else
		{
			if (fireCountdown <= 0)
			{
				Shoot();
				fireCountdown = 1 / fireRate;
			}
			fireCountdown -= Time.deltaTime;
		}

        
    }

    public void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrafab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

	public void Laser()
	{
		targetEnemy.takeDamage(damageOverFrame * Time.deltaTime);
		targetEnemy.Slow(slowPercentage);
		if (!lineRenderer.enabled)
		{
			impactLight.enabled = true;
			lineRenderer.enabled = true;
			laserParticle.Play();
		}
		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, target.position);

		Vector3 dir = firePoint.position - target.position;

		laserParticle.transform.position = target.position + dir.normalized;

		laserParticle.transform.rotation = Quaternion.LookRotation(dir);
	}

	public void LockOnTarget()
	{
		Vector3 direction = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}
    void updateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //Debug.Log(distanceToEnemy);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
		if (nearestEnemy != null && shortestDistance <= range) {
			targetEnemy = nearestEnemy.GetComponent<Enemy>();
			target = nearestEnemy.transform;
		}      
                    
        else
            target = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
