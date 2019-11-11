using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *      This is a singleton PowerUpManager, the main control
 *      for the powerups generated during the game.
 */

public sealed class PowerUpManager : MonoBehaviour
{
    //The two factory variables attached to the Manager
    private TemporaryFactory tempFactory;
    private PermanentFactory permFactory;

    //The timePassed variable counts the time since the start
    private float timePassed = 0.0f;
    //timeInterval determines how often the PowerUps are added
    private float timeInterval = 15.0f;
    //The checkPowerUps variable will help compare
    private float checkPowerUps;

    //Helps with singleton implementation
    private static readonly PowerUpManager instance = new PowerUpManager();

    //The one instance connector of the singleton 
    public PowerUpManager thePowerUpBoss;

    /*
     *      The Constructor for the PowerUpManager class
     *      is private because it is a singleton.
     */
    private PowerUpManager() { }
    
   

    /*
     *      The AddPowerUp method chooses a 
     *      random PowerUp to add to the scene.
     */
    private void AddPowerUp()
    {
        //Determines permanent or temporary PowerUp
        int whatType = Random.Range(0, 2);
        //Determines what stat the powerup will act on
        int whatStat = Random.Range(0, 0);
        if (whatType == 0)
        {
            tempFactory.Factory(whatStat);
        }
        else
        {
            permFactory.Factory(whatStat);
        }
    }
    /*
    *      The static function (also from class notes) helps
    *      with the Singleton implementation
    */
    static PowerUpManager() { }

    /*
     *  PowerUpManager Instance returns the powerup instance.
     */
    public static PowerUpManager Instance  //from the class notes on implementing the singleton
    {
        get
        {
            return instance;
        }
    }

    /*
     *  The Start() function gets the singleton instance, and connects the Factories.
     *  It also intializes a few powerups to start. 
     * 
     */
    void Start()
    {
        //assigns the instance
        thePowerUpBoss = PowerUpManager.Instance; 
        //connects the temporary factory
        tempFactory = FindObjectOfType<TemporaryFactory>(); 
        //connects the permanent factory
        permFactory = FindObjectOfType<PermanentFactory>();
        //assigns the checkPowerUps variable
        checkPowerUps = timeInterval;

        AddPowerUp();
    }

    /*
     *      The Update function checks the time and determines
     *      whether or not it is time to add another PowerUp. 
     */
    void Update()
    {
        //another helping timing variable
        float timingHelp = 0.0f;
    
        timePassed += Time.deltaTime;
        timingHelp += Time.deltaTime;
        checkPowerUps -= timingHelp;
        if (checkPowerUps < 0)
        {
            checkPowerUps = timeInterval;
            AddPowerUp();
            timingHelp = 0;
        }

}
}
