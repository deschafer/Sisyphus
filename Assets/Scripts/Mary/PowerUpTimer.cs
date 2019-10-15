using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTimer : MonoBehaviour
{
    public float TimerActive = 0.0f;
    //public int amount = 0;
    public int type;
    public PlayerHealth playerstats; //connects to the player manager

    // Start is called before the first frame update
    void Start()
    {
        playerstats = FindObjectOfType<PlayerHealth>(); //connects the timer to the player manager
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerActive > 0) //while the timer us running
        {
            TimerActive -= Time.deltaTime; //countdown
            if (TimerActive <= 0) //if the timer has run out, decrease back to where you were. 
            {
                Debug.Log("Player Health: " + playerstats.health);
                ChangeAmount(type, -1);
                Debug.Log("You changed the amount back -10");
            }
        }
    }

    //Takes in the type, and direction of chancge
     public void ChangeAmount(int type, int direction)
    {
        int amount = 10; //amount you want to change the player stat by
        amount = amount * direction; //makes it postitive or negative

        Debug.Log(amount);

        if (type == 0)//These check type, then change by the amount
        {
            Debug.Log("Player health is " + playerstats.health);
            playerstats.health += amount;
            Debug.Log("Just added " + amount + " Of health");
        }
        if (type == 1)
        {
            //  playerstats.attack += amount;
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
