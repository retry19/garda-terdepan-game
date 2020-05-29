using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float offset = 0f,
        timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform shootPoint;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (rotZ <= 30 && rotZ >= -70)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        }
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shootPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
