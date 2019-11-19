using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LB_PU : PU_HUD_HANDLER
{
    private TimeOut lightningBolt; //public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        lightningBolt = FindObjectOfType<TimeOut>();  
        powerUp.color = new Color(1f, 1f, 1f, 0.0f);

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
                timer.color = new Color(1f, 1f, 1f, Mathf.Lerp(timer.color.a, maxAlpha, step));
            }
            else if (lightningBolt.timerActive <= 0.0f)
            {
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, minAlpha, step));
                timer.color = new Color(1f, 1f, 1f, Mathf.Lerp(timer.color.a, minAlpha, step));
            }
        }
    }

    /*public override void powerUpTimer()
    {
        //throw new System.NotImplementedException();
    }*/
}
