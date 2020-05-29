using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private bool shotArea;
    
    public LayerMask shotAreaLayer;
    public Transform deteksiTanah;

    public GameObject shoulderWithWeapon,
        shoulderWithoutWeapon;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        shotArea = Physics2D.OverlapCircle(deteksiTanah.position, 0, shotAreaLayer);

        if (shotArea)
        {
            shoulderWithWeapon.SetActive(true);
            shoulderWithoutWeapon.SetActive(false);
        } else
        {
            shoulderWithWeapon.SetActive(false);
            shoulderWithoutWeapon.SetActive(true);
        }
    }
}
