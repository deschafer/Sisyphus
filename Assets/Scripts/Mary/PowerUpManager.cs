using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *      This is a singleton PowerUpManager, the main control
 *      for the powerups generated during the game.
 *      
 *      Please note that function brackets do not comply with coding 
 *      standards for ease of agile development. They can be changed prior
 *      to final versions. 
 */

public sealed class PowerUpManager : MonoBehaviour
{

    

    //The two factory classes attached to the Manager
    private TemporaryFactory tempFactory;
    private PermanentFactory permFactory;

    //The two action classes attached to the Manager
    private TimeOut timeOut;
    private PowerDrop powerDrop;

    //The following variables help determine whether or not to add PowerUps to the current game:

        //The timePassed variable counts the time since the start
        private float timePassed = 0.0f;
        //timeInterval determines how often the PowerUps are added
        private float timeInterval = 15.0f;
        //The checkPowerUps variable will help compare the total time passed against the time interval
        private float checkPowerUps;


    //The following variables help determine and implement the game's increasing difficulty algorithm.

        //The checkpoint variable determines how often the game will increase in difficulty
        private float timeCheckPoint = 45.0f;
        //timePowerUpStepDown determines how much the active time for PowerUps will decrease
        private float timePowerUpStepDown = 5.0f;
        //amountPowerUpStepDown determines how much the amount boost for PowerUps will decrease
        private float amountPowerUpStepDown = 1.0f;
        //timePowerUpLowerBoundary is the minimum allowed active PowerUp timing
        private float timePowerUpLowerBoundary = 10.0f;
        //amountPowerUpLowerBoundary is the minimum allowed PowerUpBoost
        private float amountPowerUpLowerBoundary = 5.0f;
        //numberDifficultyIncreases is how many times the level difficulty has been increased
        private float numberDifficultyIncreases = 0.0f;
        //powerUpTimeGenerationStepUp is the increased time gap between powerups. 
        private float powerUpTimeGenerationStepUp = 1.0f;


    //Helps with singleton implementation
    private static readonly PowerUpManager instance = new PowerUpManager();

    //List of PowerUp Variables
    public List<GameObject> powerUpList;

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
        int whatStat = Random.Range(0, 3);
        if (whatType == 0)
        {
            tempFactory.Factory(whatStat, powerUpList);
        }
        else
        {
            permFactory.Factory(whatStat, powerUpList);
        }
    }
    /*
     *      The IncreaseDifficulty Function implements a change in the difficulty level of the function.
     *      It uses the current time, as well as the Action scripts's boost and timing variables to
     *      make Powerups less effective (and less often seen) as a user gets further in the game.
     * 
     */
    private void IncreaseDifficulty()
    {
        float currentPowerUpTime;
        float currentPowerUpBoost;

        //First, we'll increase the count of the number of times we've increased the difficulty
            numberDifficultyIncreases++;

        //Then, we'll take down the powerup activity time by a step.
            currentPowerUpTime = timeOut.GetTime();
            currentPowerUpTime -= timePowerUpStepDown;

        //check the boundary first, though
            if (currentPowerUpTime >= timePowerUpLowerBoundary)
            {
                timeOut.SetTime(currentPowerUpTime);
            }
        

        //Then, every OTHER time we increase the difficulty, we'll take the boost down a step
            if (numberDifficultyIncreases % 2 == 0)
            {
                currentPowerUpBoost = powerDrop.GetAmount();
                currentPowerUpBoost -= amountPowerUpStepDown;

                //again, check the boundary
                if (currentPowerUpBoost >= amountPowerUpLowerBoundary)
                {
                    powerDrop.SetAmount(currentPowerUpBoost);
                }
                
            }

        //Finally, we'll increase the time between when PowerUps are generated.
            timeInterval += powerUpTimeGenerationStepUp;

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
     *  It also intializes a powerups to begin. 
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
        //assigns the PowerDrop action
        powerDrop = FindObjectOfType<PowerDrop>();
        //assigns the TimeOut action
        timeOut = FindObjectOfType<TimeOut>();
        //assigns the checkPowerUps variable
        checkPowerUps = timeInterval;

        AddPowerUp();
       
    }

    /*
     *      The Update function checks the time and determines
     *      whether or not it is time to add another PowerUp, or 
     *      Increase the Difficulty of the game.
     */
    void Update()
    {
        //other helping timing variables
        float timingHelp = 0.0f;
        float difficultyTimingHelp = 0.0f;
    
        //First, check the time passed
        timePassed += Time.deltaTime;
        timingHelp += Time.deltaTime;
        difficultyTimingHelp += Time.deltaTime;
        checkPowerUps -= timingHelp;

        //This checks to see if the PowerUp Generation time interval has gone by
        if (checkPowerUps < 0)
        {
            checkPowerUps = timeInterval;
            AddPowerUp();
            timingHelp = 0;
        }

        //This checks to see if the Level Difficulty Increase time interval has gone by
        if (difficultyTimingHelp >= timeCheckPoint)
        {
            //reset the difficulty helper variable
            difficultyTimingHelp = 0;
            IncreaseDifficulty();
        }

}
}
