using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *      The PowerDrop class is a subclass of the PowerUpAction
 *      class, and makes a powerup communicate a one time boost
 *      to the player's stats. 
 */
public class PowerDrop : PowerUpAction
{
    //The variable addAmount is how much the player gets as an increase. It defaults to 10.
    private float addAmount = 10f;

    /*
     *      The Start() method connects the player manager.
     */
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        otherPlayerStats = FindObjectOfType<PlayerControl>();
    }

    /*
     *      The overriden PowerAction takes in a type, then
     *      adds the specified amount to the player's stats. 
     */
    public override void PowerAction(int typeOfThing)
    {
        //First, play the sound.
        twang.Play();
        type = typeOfThing;

        if (type == 0)//These check type, then change by the amount
        {
            amount = (playerHealth.health + addAmount);

            playerHealth.health = (amount < MAXHEALTH) ? (playerHealth.health + addAmount) : MAXHEALTH;
        }
        if (type == 1)
        {
            amount = (otherPlayerStats.maxSpeed + addAmount);
            otherPlayerStats.maxSpeed = (amount < MAXSPEED) ? (otherPlayerStats.maxSpeed + addAmount) : MAXSPEED;
        }
        if (type == 2)
        {
            amount = (otherPlayerStats.jumpForce + addAmount);
            otherPlayerStats.jumpForce = (amount < MAXJUMP) ? (otherPlayerStats.jumpForce + addAmount) : MAXJUMP;
        }
        if (type == 3)
        {
            // playerstats.jump += amount;
        }

    }
    /*
     *      The setAmount method allows the amount of powerup
     *      increase to be changed. 
     */
    public void SetAmount(float x)
    {
        addAmount = x;
    }
    /*
     *      The GetAMount method returns the amount of powerup
     *      increasye 
     */
    public float GetAmount()
    {
        return addAmount;
    }
}
