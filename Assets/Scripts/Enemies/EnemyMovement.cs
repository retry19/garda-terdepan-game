using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float kecepatan;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("eWalk", true);
        transform.Translate(-Vector2.right * kecepatan * Time.deltaTime);
    }
}
