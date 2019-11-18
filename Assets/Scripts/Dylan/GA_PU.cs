﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GA_PU : PU_HUD_HANDLER
{
    private TimeOut goldenApple;
    

    private void Start()
    {
        goldenApple = FindObjectOfType<TimeOut>();
        Debug.Log(goldenApple.type);
    }

     private void Awake()
     {
         //powerUp = GameObject.GetComponent<SpriteRenderer>();
     }
     
    public override void powerUpTimer()
    {
        return;
    }

    // Start is called before the first frame update

    // Update is called once per frame
    public override void Update()
    {
        if (goldenApple.type == 0)
        {
            if (goldenApple.timerActive > 0.0f)
            {
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, maxAlpha, step));
            }
            else if (goldenApple.timerActive <= 0.0f)
            {
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, minAlpha, step));
            }
        }
    }
}
