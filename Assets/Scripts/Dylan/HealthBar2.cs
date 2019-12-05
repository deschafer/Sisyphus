using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Health2 health;
    private Image TopLayerImage;
    /* Health2 is the class that dictates the logic behind the health bar functioning.  It is a singleton pattern ans thus was made into its own class.
     * The TopLayerImage is the image of the top layer of the health bar.  The portion of the health bar that is filled and unfilled according to the 
     * change in the players health. 
     * The data type Image is a standard Unity type.
     * */

    private void Awake()
    {
        TopLayerImage = transform.Find("TopLayer").GetComponent<Image>();
        health = new Health2();
    }
    /* The TopLayerImage is set to the image component of the top layer of the health
     * health is being set to a new health2 class.  The design of the health 2 class will either return the only current
     * version of the health2 class or it will create one if there is not already one created.
     */

    // Update is called once per frame
    void Update()
    {
       
        TopLayerImage.fillAmount = health.NormalizeHealth();
    }
}
/*The update function called the normalize health function to decide how far to fill the health bar. 
     * It divides the total current health of the player by the max total health for the player which returns a
     * normalized version of the health. (ie. 10/100 yields 0.1) The fill amount of the toplayer image must be a number between 0 and 1
     */


public sealed class Health2
{
    private int Health_Max = 100;
    private float healthTotal;
    private static Health2 instance = null;
    private static readonly object padlock = new object();
    /* Health_Max is the total maximum health that the player can have.  It is used to normalize the health value of the player (ie. between 0 and 1)
     * the health total is pulled from the PlayerHealth script and updated once per frame
     * The Health2 instance is one of the mechanisms used to ensure that only one instance of the class is generated.
     * The padlock object is used to lock and unlock the generation function for the health2 class.
     */

    public Health2()
    {
        
    }
    
    public static Health2 Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Health2();
                }
                return instance;
            }
        }
    }

    /* Instance is used to generate one and only one instance of the class health2.  This is done by checking for an instance of the class
     * and return the instance if it exists. Otherwise it generates one instance ofthe class, sets the instance variable to the instance of the class, then
     * returns that instance of the class the the function that called
     */
    public void Update()
    {

    }
    /* The update function is left blank as nothing needs to be done for the update but it inherits an update from the superclass
     * */
    public float NormalizeHealth()
    {
        return healthTotal / Health_Max;
    }
    /* Normalizehealth normalizes the health total of the player such that it is a number between 0 and 1
     */
}