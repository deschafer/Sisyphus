using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextClass : MonoBehaviour, ICustomUIListener
{
   Image myHealth;
   // Start is called before the first frame update
   void Start()
   {
      myHealth = GetComponent<Image>();
   }

   public void UpdateUIElement(float info)
   {
      myHealth.fillAmount = info;
   }
}
