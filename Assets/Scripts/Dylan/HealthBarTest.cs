using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*This script is used to test the boundary cases for the healthbar.  The HealthBar class creates references to the healthbar objects on the canvas and the 
 * Health class below contains the logic functions, namely buttons and condition changes, that are used to alter the health value and test its
 * functionality.
 */
public class HealthBarTest : MonoBehaviour //This is the class that holds the objects
{
    private Health health;
    private Image TopLayerImage;
    //public PlayerHealth healthImage;

    private void Awake()
    {
        TopLayerImage = transform.Find("TopLayer").GetComponent<Image>();
        //healthImage = FindObjectOfType<PlayerHealth>();
        health = new Health();

    }
    private void Update()
    {
        //  Debug.Log("for health.Update");
        // health.Update();
        //Debug.Log("aft health.Update");
         TopLayerImage.fillAmount = health.NormalizeHealth();
        //TopLayerImage.fillAmount = NormalizeHealth();
    }

    /*private float NormalizeHealth()
    {
        float normalizedHealth;
        normalizedHealth = healthImage.health / 100f;
        return normalizedHealth;
    }*/
    
        public void callLoseHealthDemo()
        {
            health.LoseHealthDemo();
        }
        public void callGainHealthDemo()
        {
            health.GainHealthDemo();
        }
        
}

public class Health //Needs to be made into a subclass of the type "Entity Stats"
    //This is the class that contains the logic for how the health bar and health stats interact
{
    private int Health_Max = 100;
    private float healthTotal;
    private float healthRegen;
    
    public Health()
    {
        healthTotal = 100;
        healthRegen = 14;

    }
    
   public void Update ()
   {
       //healthTotal += healthRegen * Time.deltaTime;

   }
public void GainHealthDemo()
{
    if (healthTotal <= 86)
    {
        healthTotal += 14;
    }
    else
    {
        healthTotal = 100;

    }
}
public void LoseHealthDemo()
{
    if (healthTotal >= 21)
    {
        healthTotal -= 21;
    }
    else
    {
        healthTotal = 0;

    }
}
public void LoseHealth(int loss) //These values for loss and gain will be pulled from the player health stats and update whenever the player gets a pickup or interacts with and enemy
{
    if (healthTotal >= loss)
    {
        healthTotal -= loss;
    }
    else {
        healthTotal = 0;
    }
}

public float NormalizeHealth()
{
    return healthTotal / Health_Max;
}

}

