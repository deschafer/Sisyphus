using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This subclass of PowerUp implements a permanent jump drop. 
 */
public class PermJump : PowerUp
{
    /*
     *  The start function sets main differentiating variables
     *  for the subclass.
     */
    void Start()
    {
        //It's a permanent powerup, so we use the PowerDrop action initiator type.
        message = FindObjectOfType<PowerDrop>();
        //Jump type is integer 2
        type = 2;
    }

    /*
     *   The collision function here detects whether or not 
     *   the player hit the PowerUp. If the player did, the 
     *   powerup sends it's message via TalkToPlayer()
     *   Collision has to be implemented by the concrete subclass.
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player") //if collides with player (and hasn't already)
            TalkToPlayer();
    }
}
