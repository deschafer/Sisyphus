using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Interface for UI elements so that they can be updated using Unity's event system
public interface ICustomUIListener : IEventSystemHandler
{
   // Function that will update UI elements
   void UpdateUIElement(float info);
}
