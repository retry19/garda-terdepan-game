using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int kecepatan = 7,
        kekuatanLompat = 100,
        pindah;
    private bool balik,
        tanah;
    private float jangkauan = 0.1f;

    Rigidbody2D lompat;

    public LayerMask targetLayer;
    public Transform deteksiTanah;

    void Start()
    {
        lompat = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        tanah = Physics2D.OverlapCircle(deteksiTanah.position, jangkauan, targetLayer);

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

        if (tanah && Input.GetKey(KeyCode.W))
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
