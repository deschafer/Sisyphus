using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *      The Timeout class is a subclass of the PowerUpAction
 *      class, and makes a powerup communicate a temporary
 *      maximal player stat. 
 */
public class TimeOut : PowerUpAction
{
   
    //The amountSeconds variable determines how long the PowerUp is Active
    private float amountSeconds = 10f;
    //The timerActive variable helps start and stop the timer. 
    public float timerActive = 0.0f;

    /*
     *      The ChangeAmount function takes in a type and an amount, and 
     *      determines adds the amount to the correct statistic.
     * 
     */
    private void ChangeAmount(int type, float amount)
    {

       // Debug.Log(amount);


        if (type == 0)
        {
            playerstats.health += amount;
        }
        if (type == 1)
        {
            //  playerstats.attack += amount;
        }
        if (type == 2)
        {
            // playerstats.speed+= amount;
        }
        if (type == 3)
        {
            // playerstats.jump += amount;
        }

    }

    /*
     *      The Start() method connects the Player Manager.
     */
    void Start()
    {
        playerstats = FindObjectOfType<PlayerHealth>();
    }

   /*
    *       The Update() method checks to see if the timer is active.
    *       If it is, it subtracts time and continues. When the timer 
    *       runs out, it restores the stat variable and timer variables
    *       back to their previous state.
    */
    void Update()
    {
        if (timerActive > 0) //while the timer is running
        {
            timerActive -= Time.deltaTime; //countdown
            if (timerActive <= 0) //if the timer has run out, reset everything
            {
                amount = amount - 2*amount; //get the negative value for amount
                ChangeAmount(type, amount); //change the stat back to the previous amount
                timerActive = 0.0f; //reset the timer value to zero
            }
        }
    }

    /*
     *      The PowerAction variable adds an amount equal to 
     *      the maximal stat amount for the player. It then uses
     *      the ChangeAmount function to implement this. 
     */
    public override void PowerAction(int type)
    {
        //First, play the sound.
        twang.Play();

        //set the timer to the seconds amount specified.
        timerActive = amountSeconds;
        if (type == 0)
            amount = MAXHEALTH - playerstats.health;

        if (type == 1)
        {
            //  playerstats.attack += amount;
        }
        if (type == 2)
        {
            // playerstats.speed+= amount;
        }
        if (type == 3)
        {
            // playerstats.jump += amount;
        }

        //implement the change with ChangeAmount
        ChangeAmount(type, amount);
    }
    /*
     *      The SetTime method allows the number of seconds of powerup
     *      activity to be changed. 
     */
    public void SetTime(int x)
    {
       amountSeconds = x;
    }
}

