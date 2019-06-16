using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float Speed = 10f;
	public float explosionRadius;
    public GameObject ImpactEffect;
    public void Seek(Transform _target)
    {
        this.target = _target;
    }
    void Update()
    {
        if (target==null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;
        if(direction.magnitude <= distanceThisFrame)
        {
            hitTarget();
            return;
        }

        //move the bullet
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);
    }

    void hitTarget()
    {
        GameObject effectGO = Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectGO, 5f);

		if(explosionRadius > 1)
		{
			Explode();
		}
		else
		{
			DestroyEnemy(target);
		}

        Destroy(gameObject);
    }

	void Explode()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach(Collider collider in colliders)
		{
			if (collider.CompareTag("Enemy"))
			{
				DestroyEnemy(collider.transform);
			}
		}
	}
	void DestroyEnemy(Transform enemy)
	{
		Destroy(enemy.gameObject);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);

	}
}
