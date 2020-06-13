using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Animator camAnim;
    public int health,
        level,
        money;
    public GameObject deathEffect;
    public GameObject explosion;

    private Items player;

    private void Start()
    {
        player = GameObject.FindWithTag("Character").GetComponent<Items>();
    }

    private void Update()
    {
        if (health <= 0) {
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            player.money += money;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) 
    {
        camAnim.SetTrigger("shake");
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }

}

