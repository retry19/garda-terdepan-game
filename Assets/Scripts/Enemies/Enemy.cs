using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Animator camAnim;
    public int health,
        level,
        money;
    public float damage;
    private bool attackArea; 

    public GameObject deathEffect;
    public GameObject explosion;
    public LayerMask attackAreaLayer;
    public Transform deteksiTembok;

    private Items player;

    private void Start()
    {
        player = GameObject.FindWithTag("Character").GetComponent<Items>();
    }

    private void Update()
    {
        attackArea = Physics2D.OverlapCircle(deteksiTembok.position, 0, attackAreaLayer);

        if (attackArea)
        {
            player.health -= damage;
        }

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
