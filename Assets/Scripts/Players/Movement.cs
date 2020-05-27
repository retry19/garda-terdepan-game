using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int kecepatan = 7,
        kekuatanLompat = 50,
        pindah;
    private bool balik;

    Rigidbody2D lompat;

    void Start()
    {
        lompat = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector2.right * kecepatan * Time.deltaTime);
            pindah = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            lompat.AddForce(new Vector2(0, kekuatanLompat));
        }

        if (pindah > 0 && !balik)
        {
            BalikBadan();
        } else if (pindah < 0 && balik)
        {
            BalikBadan();
        }
    }

    void BalikBadan()
    {
        balik = !balik;
        Vector3 karakter = transform.localScale;
        karakter.x *= -1;
        transform.localScale = karakter;
    }
}
