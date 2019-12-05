using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for the canvas to ensure only one instance of the Canvas is created.
// Uses the singleton pattern.
public class CanvasClass : MonoBehaviour
{
   private static CanvasClass canvasInstance;
   // Return the canvasInstance to make sure only one exists.
   public static CanvasClass Instance
   {
      get
      {
         return canvasInstance;
      }
   }
   // Awake is called when the script is loaded.
   void Awake()
   {
      if(canvasInstance != null && canvasInstance != this)
      {
         Destroy(this.gameObject);
      }
      else
      {
         canvasInstance = this;
      }
   }
}
