using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Class that will be attached to the spaceship and update the scroll bar.
// Uses the observer pattern to update the scroll bar UI element.
public class UpdateScrollBar : UpdateUIElements
{
   float delay = 0.2f;
   public float startZ, endZ;
   public GameObject myScrollBar;
   
   // Start is called before the first frame update
   void Start()
   {
      startZ = transform.position.z;
      UpdateUIElement(-1);
   }

   // Continually updates the scroll bar, calculating how far into the level the spaceship is.
   public IEnumerator ScrollBarUpdate()
   {
      while (true)
      {
         ExecuteEvents.Execute<ICustomUIListener>(myScrollBar, null, (x, y) => x.UpdateUIElement((transform.position.z - startZ) / (endZ - startZ)));
         yield return new WaitForSeconds(delay);
      }
   }

   // Starts coroutine to update scroll bar.
   public override void UpdateUIElement(float info)
   {
      StartCoroutine(ScrollBarUpdate());
   }
}
