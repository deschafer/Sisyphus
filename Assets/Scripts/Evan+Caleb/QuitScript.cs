using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Class attached to button on pause menu to reset the level.
public class QuitScript : MonoBehaviour
{
   Button myButton;
   // Start is called before the first frame update
   void Start()
   {
      myButton = GetComponent<Button>();
      myButton.onClick.AddListener(ResetLevelFunc);
   }

   // Function attached to button to reset the level using the scene manager class.
   public void ResetLevelFunc()
   {
      SceneManager.LoadScene(0);
   }
}