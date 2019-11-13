using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *     PermanentFactory is a Factory subclass that
 *     makes powerups which drop a specified health amount,
 *     but do not timeout.
 */
public class PermanentFactory : PowerUpFactory
{
    /*
     *  The Factory function here makes the correct PowerUp type
     *  and then adds the permanent script attached to it. 
     */
    public override void Factory(int type)
    {
        //Find the player's position
        playerpos = GameObject.FindGameObjectWithTag("Player").transform.position;

        //Instantiate prefab relative to player's position.
        var go = Instantiate(prefab[type], new Vector3(playerpos.x + offset, pos.y, 0), Quaternion.identity);

        //Then, the permanent script is attached to it. 
        if (type == 0)//These check type, then change by the amount
        {
            go.AddComponent<PermHealth>();
        }
        if (type == 1)
        {
            go.AddComponent<PermSpeed>();
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
}
