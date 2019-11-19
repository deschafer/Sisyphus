using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNDL_PU : PU_HUD_HANDLER
{
    private TimeOut sandal;

    // Start is called before the first frame update
    void Start()
    {
        sandal = FindObjectOfType<TimeOut>();
        powerUp.color = new Color(1f, 1f, 1f, 0.0f);

    }

    // Update is called once per frame
    public override void Update()
    {
        if (sandal.type == 1)
        {
            if (sandal.timerActive > 0.0f)
            {
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, maxAlpha, step));

            }
            else if (sandal.timerActive <=  0.0f)
            {
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, minAlpha, step));
            }
        }
        
    }
    /*public override void powerUpTimer()
    {
        //throw new System.NotImplementedException();
    }*/

}
