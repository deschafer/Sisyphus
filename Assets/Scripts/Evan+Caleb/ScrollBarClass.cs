using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class for the scroll bar. Implements UpdateUIElement from ICustomUIListener class.
public class ScrollBarClass : MonoBehaviour, ICustomUIListener
{
   Scrollbar myScrollBar;
   // Start is called before the first frame update
   void Start()
   {
      myScrollBar = GetComponent<Scrollbar>();
   }

   // Sets the value of the scroll bar (between 0 and 1) to whatever value is passed as info
   public void UpdateUIElement(float info)
   {
      myScrollBar.value = info;
   }
}
