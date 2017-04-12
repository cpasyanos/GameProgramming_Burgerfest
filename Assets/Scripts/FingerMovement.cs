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
     if (Input.GetMouseButtonDown(0))
      {
         isGrabbing = true;
         Debug.Log("Grabbing.");
      }

     if (Input.GetMouseButtonUp(0))
      {
         isGrabbing = false;
         Debug.Log("Stopped grabbing.");
      }
	}
}
