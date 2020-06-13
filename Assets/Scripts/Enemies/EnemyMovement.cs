using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float kecepatan;
    private bool attackArea;

    public LayerMask attackAreaLayer;
    public Transform deteksiTembok;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        attackArea = Physics2D.OverlapCircle(deteksiTembok.position, 0, attackAreaLayer);

        if (attackArea)
        {
            anim.SetBool("eAttack", true);
            anim.SetBool("eWalk", false);
        } else
        {
            anim.SetBool("eWalk", true);
            anim.SetBool("eAttack", false);
            transform.Translate(-Vector2.right * kecepatan * Time.deltaTime);
        }
    }
}
