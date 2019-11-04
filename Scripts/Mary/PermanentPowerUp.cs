using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentPowerUp : PowerUp
{
    private float Maz_Health = 100f;
    private float amount = 10f;

    //public PlayerStatProxy playerstats;
    public PlayerHealth playerstats;
    PermanentPowerUp()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //playerstats = FindObjectOfType<PlayerStatProxy> ();
        playerstats = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
     {

            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Hit the player");
                playerstats.health += amount;
                Destroy(gameObject);
            }
     }
    }
