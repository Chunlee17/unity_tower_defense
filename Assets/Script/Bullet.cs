using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float Speed = 10f;
    public GameObject bulletImpactEffect;
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

    }

    void hitTarget()
    {
        GameObject effectGO = Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(effectGO, 1f);
		Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
