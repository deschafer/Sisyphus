using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* This script contains the same logic as the classes in the PU_HUD_CONTROLLER class tree but connects only one instance of the powerup sprite to the powerup
 * and uses buttons and condition changes to test the ability of the hud to respond to changes of the powerups and playerstats.
 */
public class PU_HUD : MonoBehaviour
{
    private const float maxAlpha = 1.00f;
    private const float minAlpha = 0.00f;
    private float duration = 3.00f;
    private int flag = 1;

    public SpriteRenderer powerUp;
    


    // Start is called before the first frame update
    void Start()
    {
        powerUp.color = new Color(1, 1, 1, 0.0f);        
    }

    // Update is called once per frame

    public void setPowerupFlag()
    {
        if (flag == 0)
        {
            flag = 1;
        }
        else if (flag == 1)
        {
            flag = 0;
        }
    }

    void Update()
    {
        if (flag == 0)
        {
            float step = duration * Time.deltaTime;
            powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, maxAlpha, step));
        }
        else if (flag == 1)
        {
            float step = duration * Time.deltaTime;
            powerUp.color = new Color(1f, 1f, 1f, Mathf.Lerp(powerUp.color.a, minAlpha, step));
        }
    }
}
