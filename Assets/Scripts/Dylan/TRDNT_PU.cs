using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TRDNT_PU : PU_HUD_HANDLER
{
    private TimeOut trident;
    //public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        trident = FindObjectOfType<TimeOut>();
        powerUp.color = new Color(1f, 1f, 1f, 0.0f);

    }

    // Update is called once per frame
    public override void Update()
    {
        if (trident.type == 3)
        {
            if (trident.timerActive > 0.0f)
            {
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, maxAlpha, step));
                //timer.color = new Color(1f, 1f, 1f, Mathf.Lerp(timer.color.a, maxAlpha, step));
            }
            else if (trident.timerActive <= 0.0f)
            {
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, minAlpha, step));
                //timer.color = new Color(1f, 1f, 1f, Mathf.Lerp(timer.color.a, minAlpha, step));
            }
        }
    }
    /*public override void powerUpTimer()
    {
      //  throw new System.NotImplementedException();
    }*/
}
