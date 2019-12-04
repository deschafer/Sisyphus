using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenClass : MonoBehaviour
{
   public Vector3 pivot;
   float speed = 50f;
   void Start()
   {
      Time.timeScale = 1f;   
   }


   // Update is called once per frame
   void Update()
   {
      transform.RotateAround(pivot, -Vector3.forward, speed * Time.deltaTime);
   }
}
