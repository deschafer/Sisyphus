using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *      The PowerUpFactory class is a superclass for 2 types of Creators,
 *      TemporaryFactory and PermanentFactory, which make the 2 types of 
 *      PowerUps in our game. If we added additional types of PowerUps, we
 *      could make them a subclass of this factory superclass. The PowerUpFactory
 *      also implements the Factory method. 
 * 
 */
public abstract class PowerUpFactory : MonoBehaviour
{
    //The prefabs are stored in an array (4 in each subclass)
    public GameObject[] prefab;
    //Default Position Vector
    public Vector3 pos = new Vector3(20, 9, 0);
    //Vector that will hold the player's position.
    public Vector3 playerpos;
    //Offset for powerup relative to player. 
    public float offset = 10f;

    /*
     *  The Factory function is a virtual function that takes
     *  in the type (health, speed, attack, or jump) and the poweruplist and makes
     *  the correct corresponding PowerUp, depending on the subclass.
     * 
     */
    public virtual void Factory(int type, List<GameObject> powerUpList)
    {
        playerpos = GameObject.FindGameObjectWithTag("Player").transform.position;

        //Instantiate prefab relative to player's position. Deafult is health.
        var go = Instantiate(prefab[0], new Vector3(playerpos.x + offset, pos.y, 0), Quaternion.identity);
    }
}

