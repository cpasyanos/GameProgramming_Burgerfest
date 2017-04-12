using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMovement : MonoBehaviour {
   private bool isGrabbing;

   void Start()
   {
      isGrabbing = false;
   }
	
	// Update is called once per frame
	void Update () {
     if (Input.GetKeyDown(KeyCode.Space))
      {
         isGrabbing = true;
         Debug.Log("Grabbing.");
      }

     if (Input.GetKeyUp(KeyCode.Space))
      {
         isGrabbing = false;
         Debug.Log("Stopped grabbing.");
      }
	}
}
