using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Health2 health;
    private Image TopLayerImage;
    
    private void Awake()
    {
        TopLayerImage = transform.Find("TopLayer").GetComponent<Image>();
        health = new Health2();
    }

    // Update is called once per frame
    void Update()
    {
        //health.Update();
        TopLayerImage.fillAmount = health.NormalizeHealth();
    }
}


public sealed class Health2
{
    private int Health_Max = 100;
    private float healthTotal;
    private static Health2 instance = null;
    private static readonly object padlock = new object();
    
    public Health2()
    {

    }
    
    public static Health2 Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Health2();
                }
                return instance;
            }
        }
    }
    public void Update()
    {

    }
    public float NormalizeHealth()
    {
        return healthTotal / Health_Max;
    }
}