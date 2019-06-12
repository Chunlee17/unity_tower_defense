using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;

    [Header("Attribute")]
    public float range = 10f;
    public float fireRate = 3f;
    private float fireCountdown = 0f;

    [Header("Unity setup Field")]

    public string enemytag = "Enemy";
    public float turnSpeed = 10f;
    public Transform partToRotate;

    public GameObject bulletPrafab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.2f);
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;

        }
        fireCountdown -= Time.deltaTime;
    }

    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrafab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
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
        if (nearestEnemy != null && shortestDistance <= range)       
            target = nearestEnemy.transform;        
        else
            target = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
