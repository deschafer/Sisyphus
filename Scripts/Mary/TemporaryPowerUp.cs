using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryPowerUp : PowerUp
{

    public float TimerActive = 0.0f;
    public int type;
    public PowerUpTimer timer;
    public int collided = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<PowerUpTimer>(); //connect the object to the outside timer
        //whatami = Random.Range(0, 4); //Gives the object a random type of boost: health, speed, attack, or jump.
        type = 0; //for testing purposes right now, I'm only allowing it to be a health boost
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && collided == 0) //if collides with player (and hasn't already)
        {
            collided = 1;
            TimerActive = 10.0f; //set the timer variable to the number of seconds for the powerup
            Debug.Log("Hit the player");
            timer.ChangeAmount(type, 1); //add the amount of health boost
            Debug.Log("You changed the inital amount +10");
            timer.type = type; //tell the timer what type of powerup it is
            timer.TimerActive = TimerActive; //set the timer to the number of seconds
            Destroy(gameObject); //destory the object

        }
    }
}

 