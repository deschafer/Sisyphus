using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateHealth : UpdateUIElements
{
   //Get health
   // Start is called before the first frame update
   public GameObject myHealthText;


   // Call this function to set the amount of health left. Info should be a float between 0 and 1.
   public override void UpdateUIElement(float info)
   {
      ExecuteEvents.Execute<ICustomUIListener>(myHealthText, null, (x, y) => x.UpdateUIElement(info));
   }
}
