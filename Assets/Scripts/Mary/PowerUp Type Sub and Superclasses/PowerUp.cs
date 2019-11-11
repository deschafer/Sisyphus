using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *      This is the superclass of every PowerUp type object.
 *      When the game is implemented, it will have 8 subclasses, 
 *      one temporary PowerUp for each component health, speed, jump, and
 *      attack, and one permanent (Drop) for the same components. The superclass
 *      also handles all the message passing to the player with the TalkToPlayer()
 *      function.    
 */
public class PowerUp : MonoBehaviour
{
    //the type and message type are set by the subclasses. 
    public int type;
    public PowerUpAction message;

    /*
     *     The TalkToPlayer function sends the message (implemented 
     *     by the subclass) and then destroys the object that 
     *     was collided with.
     */
    public void TalkToPlayer()
    {
        message.PowerAction(type);
        Destroy(gameObject);
    }
}
