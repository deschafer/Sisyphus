using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This script tests what would happen if the player (and the PowerUp Timer attached to it) was suddenly spammed with a ton of of powerup requests.
 * The script here simulates one powerup (on health) request per frame for 30 seconds (which can be adjusted in unity, since it's public). The 
 * script then checks to see if the playerhealth ever goes above it's maximum limit of 100 (in the test scene, it begins at zero). If the health
 * ever goes above the maximum, the failed variable is set to one. At the end of the test, the script displays (based on the failed variable)
 * whether the game ever went above the maximum allowable player statistic (fail) or if it maintained the maximum statistic (passed). 
 * 
 * Notes:  1. The results are displayed in the console.
 *         2. The objects in the scene don't do much because the simulation is happening pretty much exclusively behind the scenes. However,
 *         you can see the Debug message's numbers increasing. Also, playerhealth on the player should be at 100 during the game run. 
 *         3. For this script to work, the player must have the playerhealth and poweruptimer scripts attached. Another object must have
 *         TestPowerUpMessage script attached. 
 */
public class TestPowerUpMessages : MonoBehaviour
{
    private PowerUpTimer timer;
    private int type;
    private float TimerActive = 0.0f;
    public float timepassed = 30.0f;
    private int failed = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<PowerUpTimer>(); //connect the object to the outside timer
        type = 0;
}

    // Update is called once per frame
    void Update()
    {
        if (timepassed > 0.0f)
        {
            timepassed -= Time.deltaTime;
            timer.ChangeAmount(type, 1); //add the amount of health boost
                                         //Debug.Log("You changed the inital amount +10");
            timer.type = type; //tell the timer what type of powerup it is
            timer.TimerActive = TimerActive; //set the timer to the number of seconds
            if (timer.playerstats.health > 100)
            {
                failed = 1;
            }
        }
        else
        {
            if (failed == 1)
            {
                Debug.Log("Failed the test. Exceeded max player value");
            }
            else
            {
                Debug.Log("Passed the test. Didnot exceed max player  value.");
            }
            Destroy(gameObject); //destory the object
        }
    }
}
