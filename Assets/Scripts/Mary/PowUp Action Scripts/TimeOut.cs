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
    private float timerActive = 0.0f;
    //Flag for active PowerUp
    private float powerUpInSession = 0;

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
            playerHealth.health += amount;
        }
        if (type == 1)
        {
            otherPlayerStats.maxSpeed += amount;
            Debug.Log(amount);
            Debug.Log("Changed amount back");
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
        playerHealth = FindObjectOfType<PlayerHealth>();
        otherPlayerStats = FindObjectOfType<PlayerControl>();
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
                Debug.Log("Timer Ran Out");
                amount = -amount; //get the negative value for amount
                Debug.Log("Changing amount back by:");
                Debug.Log(amount);
                ChangeAmount(type, amount); //change the stat back to the previous amount
                timerActive = 0.0f; //reset the timer value to zero
                powerUpInSession = 0;
            }
        }
    }

    /*
     *      The PowerAction variable adds an amount equal to 
     *      the maximal stat amount for the player. It then uses
     *      the ChangeAmount function to implement this. 
     */
    public override void PowerAction(int typeOfThing)
    {
        type = typeOfThing;
        //First, play the sound.
        twang.Play();

        //check to make sure there isn't already a PowerUp on. (If so, don't let another one happen).
        if (powerUpInSession == 0)
        {
            //set flag
            powerUpInSession = 1;
            //set the timer to the seconds amount specified.
            timerActive = amountSeconds;

            if (type == 0)
                amount = MAXHEALTH - playerHealth.health;

            if (type == 1)
            {
                //  playerstats.attack += amount;
                amount = MAXSPEED - otherPlayerStats.maxSpeed;
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
       
    }
    /*
     *      The SetTime method allows the number of seconds of powerup
     *      activity to be changed. 
     */
    public void SetTime(float x)
    {
       amountSeconds = x;
    }
    /*
     *      The GetTime method returns the number of seconds of powerup
     *      activity. 
     */
    public float GetTime()
    {
        return amountSeconds;
    }
}

