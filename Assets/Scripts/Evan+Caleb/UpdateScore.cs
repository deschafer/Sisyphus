using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Class that contains a function which can update the score text UI element.
public class UpdateScore : UpdateUIElements
{
   public GameObject myText;

   // Attach script keeping track of score here and pass it as the score


   // Function that, when called, will update the score on screen.
   public override void UpdateUIElement(float info)
   {
      ExecuteEvents.Execute<ICustomUIListener>(myText, null, (x, y) => x.UpdateUIElement(info));
   }
}
