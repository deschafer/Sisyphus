﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentPowerUp : PowerUp
{

    private int amount = 10;
    public PlayerStatProxy playerstats;
    PermanentPowerUp()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        playerstats = FindObjectOfType<PlayerStatProxy> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            playerstats.health += amount;
            //amount += 10;
            Destroy(gameObject);  
        }
    }
}
