﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    Text health;
    Player player;

    // Use this for initialization
    void Start()
    {
        health = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = player.GetHP().ToString();
    }
}
