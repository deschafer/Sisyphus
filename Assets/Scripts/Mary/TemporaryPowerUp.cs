﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryPowerUp : PowerUp
{
    public int whatami;
    public PlayerStatProxy playerstats;

    // Start is called before the first frame update
    
       
   

    void Start()
    {
       
        playerstats = FindObjectOfType<PlayerStatProxy>(); //Connects the proxy player manager
        
        whatami = Random.Range(0, 4); //Gives the object a random type of boost: health, speed, attack, or jump.
    }   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //onclick
        {
            ChangeAmount(whatami, 1); //adds the amount (1 is postitive, so it's adding)
            Debug.Log("You changed the inital amount +10");
            //Timer();

            //Timer--current problem is that it is way too fast.
            Time.timeScale = 1.0f;
            float seconds = 5.0f;


            while (seconds > 0.0f)
            {
                Debug.Log(seconds);
                seconds -= Time.deltaTime;
            }
            //end timer


            ChangeAmount(whatami, -1);
            Debug.Log("You changed the amount back -10");
            Destroy(gameObject);
        }
    }
  
 
    /*    void Timer()
    {
        Time.timeScale = 1.0f;
        float seconds = 5.0f;
        while (seconds > 0)
        {
            Debug.Log("In the timer");
            seconds -= Time.deltaTime;
        }
   
    }
    */
    void ChangeAmount(int whatami, int direction)
    {
        int amount = 10; //amount you want to change the player stat by
        amount = amount * direction; //makes it postitive or negative

        if (whatami == 0)//These check type, then change by the amount
        {
            playerstats.health += amount;
        }
        if (whatami == 1)
        {
            playerstats.attack += amount;
        }
        if (whatami == 2)
        {
            playerstats.speed += amount;
        }
        if (whatami == 3)
        {
            playerstats.jump += amount;
        }

    }
}
