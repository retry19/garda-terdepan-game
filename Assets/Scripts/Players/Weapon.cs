using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;
    private Quaternion rotationProjectile;

    public GameObject projectile;
    public GameObject shotEffect;
    public Transform shotPoint;
    public Animator camAnim;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private Items player;

    private void Start()
    {
        player = GameObject.FindWithTag("Character").GetComponent<Items>();
    }

    private void Update()
    {
        // Handles the weapon rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 0);

        rotationProjectile = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                if (player.ammo != 0)
                {
                    Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                    camAnim.SetTrigger("shake");
                    Instantiate(projectile, shotPoint.position, rotationProjectile);
                    timeBtwShots = startTimeBtwShots;

                    player.ammo -= 1;
                }
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }
}
