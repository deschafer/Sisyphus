using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *     TemporaryFactory is a Factory subclass that
 *     makes powerups which only last an amount of seconds.
 */
public class TemporaryFactory : PowerUpFactory
{
   
    /*
     *  The Factory function here makes the correct PowerUp type and the powerup list
     *  and then adds the temporary script attached to it. 
     */
    public override void Factory(int type, List<GameObject> powerUpList)
    {
        //Find the player's position
        playerpos = GameObject.FindGameObjectWithTag("Player").transform.position;
       
        //Instantiate prefab relative to player's position.
        var go = Instantiate(prefab[type], new Vector3(playerpos.x + offset,pos.y, 0), Quaternion.identity);

        //Then, the temporary script is attached to it. 
        if (type == 0)//These check type, then change by the amount
        {
            go.AddComponent<TempHealth>();          
        }
        if (type == 1)
        {
            go.AddComponent<TempSpeed>();
        }
        if (type == 2)
        {
            go.AddComponent<TempJump>();
        }
        if (type == 3)
        {
            // playerstats.attack += amount;
        }
        powerUpList.Add(go);

    }

}
