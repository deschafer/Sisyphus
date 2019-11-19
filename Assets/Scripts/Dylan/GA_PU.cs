using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GA_PU : PU_HUD_HANDLER
{
    private TimeOut goldenApple;
    //public Text timer;

    private void Start()
    {
        goldenApple = FindObjectOfType<TimeOut>();
        powerUp.color = new Color(1f, 1f, 1f, 0.0f);

        Debug.Log(goldenApple.type);
    }

     private void Awake()
     {
         //powerUp = GameObject.GetComponent<SpriteRenderer>();
     }
     
   /* public override void powerUpTimer()
    {
        return;
    }*/

    // Start is called before the first frame update

    // Update is called once per frame
    public override void Update()
    {
        if (goldenApple.type == 0)
        {
           // timer.text = " " + timeOut.timerActive;
            if (goldenApple.timerActive > 0.0f)
            {
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, maxAlpha, step));
                //timer.color = new Color(0f, 0f, 0f, Mathf.Lerp(timer.color.a, maxAlpha, step));
            }
            else if (goldenApple.timerActive <= 0.0f)
            {
                float step = duration * Time.deltaTime;
                powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, minAlpha, step));
                //timer.color = new Color(1f, 1f, 1f, Mathf.Lerp(timer.color.a, minAlpha, step));
            }
        }
    }
}
