using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed,
        lifeTime;

    public GameObject destroyEffect;

    void Start()
    {
        //invoke("DestroyProjectile", lifeTime);
    }

    void Update()
    {
        //tranform.Translate(transform.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
