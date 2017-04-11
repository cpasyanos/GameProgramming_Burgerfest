using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMovement : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
      // pinky
		if (Input.GetKeyDown(KeyCode.A))
      {
         Debug.Log("Clench pinky");
      }

      // ring finger
      if (Input.GetKeyDown(KeyCode.W))
      {

      }

      // middle finger
      if (Input.GetKeyDown(KeyCode.E))
      {

      }

      // index finger
      if (Input.GetKeyDown(KeyCode.R))
      {

      }

      // thumb
      if (Input.GetKeyDown(KeyCode.Space))
      {

      }
	}
}
