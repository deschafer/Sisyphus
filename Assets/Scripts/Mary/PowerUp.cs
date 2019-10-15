using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int Max_Health = 100; 
    public int healthboost;
    public int speedboost;
    public int attackboost;
    public int jumpboost;
    public PlayerHealth playerstats; //connects to the player manager

    // Start is called before the first frame update
    void Start()
    {
        playerstats = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
