using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnteredZoneAttack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            FindObjectOfType<AudioManager>().Play("EnemyAttack");
            Debug.Log("ada enemy");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag != "Character")
        {
            FindObjectOfType<AudioManager>().Stop("EnemyAttack");
            Debug.Log("tidak ada enemy");
        }
    }
}
