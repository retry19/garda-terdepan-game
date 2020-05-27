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

    Animator anim;

    void Start()
    {
        lompat = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (tanah)
        {
            anim.SetBool("jump", false);
        } else
        {
            anim.SetBool("jump", true);
        }

        tanah = Physics2D.OverlapCircle(deteksiTanah.position, jangkauan, targetLayer);

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("walk", true);
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah = -1;
        } else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("walk", true);
            transform.Translate(-Vector2.right * kecepatan * Time.deltaTime);
            pindah = 1;
        } else
        {
            anim.SetBool("walk", false);
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
