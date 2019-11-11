using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *  This subclass of PowerUp implements a permanent health drop. 
 */
public class PermHealth : PowerUp
{
    /*
     *  The start function sets main differentiating variables
     *  for the subclass.
     */
    void Start()
    {
        //It's a permanent powerup, so we use the PowerDrop action initiator type.
        message = FindObjectOfType<PowerDrop>(); 
        //Health type is integer 0
        type = 0;
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