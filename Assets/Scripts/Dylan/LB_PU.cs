using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_PU : PU_HUD_HANDLER
{
    private TimeOut lightningBolt;
    // Start is called before the first frame update
    void Start()
    {
        lightningBolt = FindObjectOfType<TimeOut>();    
    }

    // Update is called once per frame
    public override void Update()
    {
        if (lightningBolt.type == 2)
        {
            if (lightningBolt.timerActive > 0.0f)
            {
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, maxAlpha, step));
            } 
            else if (lightningBolt.timerActive <= 0.0f)
            {
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, minAlpha, step));
            }
        }
    }

    public override void powerUpTimer()
    {
        //throw new System.NotImplementedException();
    }
}
