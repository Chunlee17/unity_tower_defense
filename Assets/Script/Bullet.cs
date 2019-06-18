using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float Speed = 10f;
	public int damage = 50;
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
			GameObject effectGO = Instantiate(ImpactEffect, transform.position, transform.rotation);
			Destroy(effectGO, 1f);
			Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;
		//
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
        Destroy(effectGO, 1f);

		if(explosionRadius > 1)
		{
			Explode();
		}
		else
		{
			Damage(target);
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
				Damage(collider.transform);
			}
		}
		
	}
	void Damage(Transform enemyGO)
	{
		Enemy e = enemyGO.GetComponent<Enemy>();
		if (e != null)
		{
			e.takeDamage(damage);
		}

		
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);

	}
}
