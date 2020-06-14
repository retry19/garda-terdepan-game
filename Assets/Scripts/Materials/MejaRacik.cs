using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MejaRacik : MonoBehaviour
{
    public GameObject dialogSelectAmmo;
    public Button ammo1,
        ammo2;
    private Items itemsPlayer;

    private void Start()
    {
        itemsPlayer = GameObject.FindWithTag("Character").GetComponent<Items>();

        Button btnBuyAmmo1 = ammo1.GetComponent<Button>();
        Button btnBuyAmmo2 = ammo2.GetComponent<Button>();

        btnBuyAmmo1.onClick.AddListener(handleBuyAmmo1);
        btnBuyAmmo2.onClick.AddListener(handleBuyAmmo2);

        SetActiveRecursivelyExt(dialogSelectAmmo, false);
    }

    private void handleBuyAmmo1()
    {
        if (itemsPlayer.money >= 10)
        {
            FindObjectOfType<AudioManager>().Play("ButtonClicked");

            itemsPlayer.money -= 10;
            itemsPlayer.ammo += 8;
        }
    }

    private void handleBuyAmmo2()
    {
        if (itemsPlayer.money >= 17)
        {
            FindObjectOfType<AudioManager>().Play("ButtonClicked");

            itemsPlayer.money -= 17;
            itemsPlayer.ammo += 16;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Character")
        {
            SetActiveRecursivelyExt(dialogSelectAmmo, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        SetActiveRecursivelyExt(dialogSelectAmmo, false);
    }

    private void SetActiveRecursivelyExt(GameObject obj, bool state)
    {
        obj.SetActive(state);
        foreach (Transform child in obj.transform)
        {
            SetActiveRecursivelyExt(child.gameObject, state);
        }
    }
}
