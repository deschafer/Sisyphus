using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthtest : MonoBehaviour
{
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void awake()
    {
        
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(playerHealth.GetStat());

    }
}
