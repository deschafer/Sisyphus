using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* This script was a test script and is not used in the final release of the product
 * */
public class Healthtest : MonoBehaviour
{
    private PlayerHealth playerHealth;
    //private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        //playerHealth = FindObjectOfType<PlayerHealth>();
        //Debug.Log(health);
       //// playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
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
