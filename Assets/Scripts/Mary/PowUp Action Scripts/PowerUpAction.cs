using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *      The PowerUpAction class handles
 *      the actual behavior of the PowerUps.
 *      Its two subclasses are the PowerDrop
 *      (for permanent powerups) and the TimeOut
 *      (for temporary powerups) classes.
 * 
 */
public class PowerUpAction : MonoBehaviour
{
    //The playerHealth variable connects to the PlayerHealth (playermanager)
    public PlayerHealth playerHealth;
    //The otherPlayerStats holds the other player stat values (speed, jump)
    public PlayerControl otherPlayerStats;
    //This will be passed to the PowerAction function
    public int type;
    //Amount handles what will be added to the player's stats.
    public float amount;
    //The constants here represent the boundaries for player stats.
    public float MAXHEALTH = 100f;
    public float MAXSPEED = 20f;
    //This is the audio clip that is played when the powerup is collided with.
    public AudioSource twang;

    /*
     *      The PowerAction function takes in the type and then
     *      determines what the PowerUp will do. It is implemented 
     *      in the subclasses.
     */
    public virtual void PowerAction(int typeOfThing)
    {

    }
  
}
