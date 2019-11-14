using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *      This is a singleton PowerUpManager, the main control
 *      for the powerups generated during the game.
 */

public sealed class Test_PowerUpManager : MonoBehaviour
{
    //List of PowerUp Variables
    public List<GameObject> powerUpList;

    //determines what test to run. 1= Overwhelmed boundary test. 2= Close to overwhelmed boundary test. 3= Stress test.
    public int whichTest = 0;
    //determines number of currentPowerUps made 
    private int numPowerUps = 0;
    //flag for initial PowerUp creation on near-Boundary test
    private int createPowerUpFlag = 1;
    //outside counter 
    int j = 40;


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


    //Testing variables
        //Checks how many performace hits the system is taking
        int numFramesSlow = 0;

    //Helps with singleton implementation
    private static readonly Test_PowerUpManager instance = new Test_PowerUpManager();

    //The one instance connector of the singleton 
    public Test_PowerUpManager thePowerUpBoss;

    /*
     *      The Constructor for the PowerUpManager class
     *      is private because it is a singleton.
     */
    private Test_PowerUpManager() { }
    
   

    /*
     *      The AddPowerUp method chooses a 
     *      random PowerUp to add to the scene.
     */
    private void AddPowerUp()
    {
        numPowerUps++;
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
     * 
     *      TestBoundary tests the performance of the system with a high load. If the performs goes below the 
     *      standard that was set, the test checks the number of powerups instantiated. If that number is below 15,
     *      the test fails. 
     * 
     */

    private void TestBoundary()
    {
        //continuously add PowerUps
        AddPowerUp(); 

        //keep track of frames per second
        float framesPerSecond;
        framesPerSecond = 1.0f / Time.deltaTime; 
        //Debug.Log(framesPerSecond);

        //30 frames per second is minumum playable
        if (framesPerSecond < 30)
        {
            numFramesSlow++;
            //Debug.Log("Frames running slowly");
        }

        //if the performance hit lasts a full second or more:
        if (framesPerSecond < 30 && numFramesSlow >= 30)
        {
            //Log useful info
            Debug.Log("Overwhelmed");
            Debug.Log("Number of Powerups made was");
            Debug.Log(numPowerUps);

            //To pass the test, the number of powerups that were made has to be greater than 10
            if (numPowerUps >= 10)
            {
                Debug.Log("Test passed. Enough Powerups were made before the slowdown performance");
            }
            else
            {
                Debug.Log("Test failed. Performance took a hit at/before enough Powerups");
            }
            //Then cast it into the fire! Destroy it! ISILDUR!
            Destroy(gameObject);
        }

    }
    /*
     * 
     *      This tests the system behavior really close to system failure. We'll use 30 instantiated PowerUps
     *      because the system bugs out around 33
     * 
     */
    private void TestAlmostBoundary()
    {
        //add 30 PowerUps the first time the function accessed
        if (createPowerUpFlag == 1)
        {
            for (int i = 0; i < 30; i++)
            {
                AddPowerUp();
            }
            createPowerUpFlag = 0;
        }

        //keep track of frames per second
        float framesPerSecond;
        framesPerSecond = 1.0f / Time.deltaTime;

        Debug.Log(framesPerSecond);
        //30 frames per second is minumum playable
        if (framesPerSecond < 30)
        {
            numFramesSlow++;
            
        }
        
        //if the performance hit lasts over 5 "seconds" (10 frames per second is the "slow" behavior)
        if (framesPerSecond < 30 && numFramesSlow >= 50)
        {
            //Log useful info
            Debug.Log("Performance Hit");

            Debug.Log("Test failed. Performance took a major hit.");
            
            //Destroy
            Destroy(gameObject);
        }
        else if(timePassed > 15) //Otherwise, if 15 seconds go by without this happening
        {
            Debug.Log("Test Passed. No significant performance hit after time went by.");
            Destroy(gameObject);
        }
    }
    /*
     *   The Stress Test Determines how the system will behave when intentionally overloaded. 
     * 
     */
    private void StressTest()
    {
        //helps us delete the PowerUps
        GameObject x;

       
        //add 40 PowerUps to overwhelm the system
        if (createPowerUpFlag == 1)
        {
            for (int i = 0; i < 40; i++)
            {
                AddPowerUp();
            }
            createPowerUpFlag = 0;
            Debug.Log("Number of PowerUps in list");
            Debug.Log(powerUpList.Count);

        }

        //keep track of frames per second
        float framesPerSecond;
        framesPerSecond = 1.0f / Time.deltaTime;

        //if the frame rate is bad after 5 seconds, decrease until the frame rate is better.
        if (timePassed > 5)
        {
            if (framesPerSecond < 30 && powerUpList.Count >= 10)
            {
                if (powerUpList.Count != 0) //If there are still items in the list
                {
                    x = powerUpList[j];
                    Destroy(x);
                    powerUpList.RemoveAt(j);
                    Debug.Log(powerUpList.Count);
                    j--;
                }
            }
            else if (framesPerSecond < 30 && powerUpList.Count < 10)
            {
                Debug.Log("FAIL. Performance recovery not achieved through repeated deletion");
                Destroy(gameObject);

            }
            else if (framesPerSecond > 30 && powerUpList.Count >= 10)
            {
                Debug.Log("Success. Performance recovery achieved through repeated deletion");
                Destroy(gameObject);

            }
        }


    }


  /*
   *      The static function (also from class notes) helps
   *      with the Singleton implementation
  */
        static Test_PowerUpManager() { }

    /*
     *  PowerUpManager Instance returns the powerup instance.
     */
    public static Test_PowerUpManager Instance  //from the class notes on implementing the singleton
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
        thePowerUpBoss = Test_PowerUpManager.Instance; 
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
        //make a PowerUp List
        powerUpList = new List<GameObject>();

        AddPowerUp();

        
    }

    /*
     *      The Update function checks the time and determines
     *      whether or not it is time to add another PowerUp. 
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

        //count down for next PowerUp creation
        checkPowerUps -= timingHelp;
        
        //Determine what test to run (it is set in inspector)
        if (whichTest == 1)
        {
            TestBoundary();
        }
        else if (whichTest == 2)
        {
            TestAlmostBoundary();
        }
        else if (whichTest == 3)
        {
            StressTest();
        }

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

            //Take the difficulty up a notch!
            IncreaseDifficulty();
        }
    }
    
}
