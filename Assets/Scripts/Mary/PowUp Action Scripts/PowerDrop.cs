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
        playerstats = FindObjectOfType<PlayerHealth>();
    }

    /*
     *      The overriden PowerAction takes in a type, then
     *      adds the specified amount to the player's stats. 
     */
    public override void PowerAction(int type)
    {

        if (type == 0)//These check type, then change by the amount
        {
            amount = (playerstats.health + addAmount);
            /* if (amount >= MAXHEALTH)
             {
                 playerstats.health = MAXHEALTH;
             }
             else
             {
                 playerstats.health += addAmount;
             }*/

            playerstats.health = (amount < MAXHEALTH) ? (playerstats.health + addAmount) : MAXHEALTH;
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
     *      The setAmount method allows the amount of powerup
     *      increase to be changed. 
     */
    public void SetAmount(int x)
    {
        addAmount = x;
    }
}
