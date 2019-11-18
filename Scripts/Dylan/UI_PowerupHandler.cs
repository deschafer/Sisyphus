using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UI_PowerupHandler : MonoBehaviour
{
   // public KeyCode increaseAlpha;
   // public KeyCode decreaseAlpha;
    public float alphaValue = 0.0f;
    public SpriteRenderer tempHealth;
    public float minAlpha = 0.00f;
    public float maxAlpha = 1.00f;
    public float duration = 5.00f;
    //private float startTime;

    void Start()
    {
       // startTime = Time.time;
       // Debug.Log(startTime);
        tempHealth = transform.Find("GameObject").GetComponent<SpriteRenderer>();
        tempHealth.color = new Color(1, 1, 1, 0.0f);
    }

    public void Power_up()
    {
        while (tempHealth.color.a < 1)
        {
            float step = duration * Time.deltaTime;
            tempHealth.color = new Color(1f, 1f, 1f, Mathf.Lerp(tempHealth.color.a, maxAlpha, step));
        }
        // float t = (Time.time - startTime) / duration;
        //tempHealth.color = new Color(1, 1, 1,Mathf.SmoothStep(minAlpha, maxAlpha, t));
    }
    

  
   /* public void activatePowerup()
    {
        while(alphaValue < 1f)
        {
            Debug.Log("Increase ALpha Loop");
            tempHealth.color = new Color(1, 1, 1, alphaValue);
            alphaValue += 0.0001f;
        }
        //yield return new WaitForSeconds(10);
        while(alphaValue > 0f)
        {
            Debug.Log("Decrease Alpha Loop");
            tempHealth.color = new Color(1, 1, 1, alphaValue);
            alphaValue -= 0.0001f;
        }
        alphaValue = 0.1f;
    }


    /*void Update()
     {

         if (Input.GetKeyDown(increaseAlpha))
             alphaValue += 0.1f;
         if (Input.GetKeyDown(decreaseAlpha))
             alphaValue -= 0.1f;
        tempHealth.color = new Color(1, 1, 1, alphaValue);   
        //  GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaValue);
             
    }*/



}
