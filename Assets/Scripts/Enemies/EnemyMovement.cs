using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float kecepatan;

    private void Update()
    {
        if (Time.deltaTime >= 0.0130000 && Time.deltaTime % 2 != 0)
        {
            transform.Translate(-Vector2.right * kecepatan * Time.deltaTime);
        }
    }
}
