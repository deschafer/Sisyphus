using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class that updates the score UI element
public class ScoreTextClass : MonoBehaviour, ICustomUIListener
{
   Text myText;
    
   // Start is called before the first frame update
   void Start()
   {
      myText = GetComponent<Text>();
   }

   // Set the score equal to the value passed in info.
   public void UpdateUIElement(float info)
   {
      myText.text = "Score: " + info.ToString();
   }
}
