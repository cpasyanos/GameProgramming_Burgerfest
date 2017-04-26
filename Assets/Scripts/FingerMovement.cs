using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMovement : MonoBehaviour {
   // private bool isGrabbing;
   private bool carrying;
   GameObject hand;
   GameObject carriedObject;
   public float distanceToHand;
   public float maxPickupDistance;
   public float smooth;

   void Start()
   {
      hand = GameObject.FindWithTag("Player");
      // isGrabbing = false;
      carrying = false;
   }
	
	// Update is called once per frame
	void Update () {
     /**
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
      */

     if (carrying)
      {
         carry(carriedObject);
         checkDrop();
      }
     else
      {
         pickup();
      }
	}

   void carry(GameObject o)
   {
      // should move with hand
      o.transform.position = Vector3.Lerp(o.transform.position, 
         hand.transform.position + hand.transform.forward * distanceToHand,
         Time.deltaTime * smooth);
   }

   void pickup()
   {
      if (Input.GetKeyDown(KeyCode.E))
      {
         // TODO: parent to hand, not to camera center
         int x = Screen.width / 2;
         int y = Screen.height / 2;

         Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
         RaycastHit hit;

         if (Physics.Raycast(ray, out hit, maxPickupDistance))
         {
            GameObject obj = GameObject.FindWithTag("ingredients");

            if (obj != null)
            {
               carrying = true;
               carriedObject = obj;
               obj.GetComponent<GameObject>().GetComponent<Rigidbody>().isKinematic = true;
            }
         }
      }
   }

   void checkDrop()
   {
      if (Input.GetKeyDown(KeyCode.E))
      {
         dropObject();
      }
   }

   void dropObject()
   {
      carrying = false;
      carriedObject.GetComponent<GameObject>().GetComponent<Rigidbody>().isKinematic = false;
      carriedObject = null;
      
   }
}
