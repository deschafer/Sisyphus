using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PU2_2 : MonoBehaviour
{

    public float alphaValue;
    public SpriteRenderer tempHealth;
    public float minAlpha = 0.00f;
    public float maxAlpha = 1.00f;
    public float duration = 3.00f;
    private int flag = 1;

    // Start is called before the first frame update
    void Start()
    {
        tempHealth.color = new Color(1, 1, 1, 0.0f);


    }

    public void fadeIn()
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

    // Update is called once per frame
    void Update()
    {
        if (flag == 0)
        {
            float step = duration * Time.deltaTime;
            tempHealth.color = new Color(1f, 1f, 1f, Mathf.Lerp(tempHealth.color.a, maxAlpha, step));
        }
        if (flag == 1)
        {
            float step = duration * Time.deltaTime;
            tempHealth.color = new Color(1f, 1f, 1f, Mathf.Lerp(tempHealth.color.a, minAlpha, step));
        }
    }
}
