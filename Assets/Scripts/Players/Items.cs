﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public int money,
        ammo;
    public float health;
    private int healthInt;

    Text infoMoney,
        infoHealth,
        infoAmmo;

    private void Start()
    {
        infoMoney = GameObject.Find("UIMoney").GetComponent<Text>();
        infoHealth= GameObject.Find("UIHealth").GetComponent<Text>();
        infoAmmo = GameObject.Find("UIAmmo").GetComponent<Text>();
    }

    private void Update()
    {
        healthInt = (int)health;

        infoMoney.text = money.ToString();
        infoHealth.text = healthInt.ToString();
        infoAmmo.text = ammo.ToString();
    }
}
