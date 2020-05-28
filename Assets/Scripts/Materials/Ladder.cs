using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float kecepatanNaik = 6;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Character" && Input.GetKey(KeyCode.W))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, kecepatanNaik);
        } else if (other.tag == "Character" && Input.GetKey(KeyCode.S))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -kecepatanNaik);
        } else
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0.1f);
        }
    }
}
