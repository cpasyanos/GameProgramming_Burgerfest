using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pickupper : MonoBehaviour
{
    public GameObject heldObject = null;
    public List<GameObject> objectsToPickup = null;
    public Transform handTransform;
    private bool isGrabbing = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ingredient")
        {
            Debug.Log(string.Format("Touched ingredient {0}", other.name));
            objectsToPickup.Add(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
            if (other.tag == "Ingredient")
            {
                Debug.Log(string.Format("Stopped touching ingredient {0}", other.name));
                objectsToPickup.Remove(other.gameObject);
            }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // pick something up
            if (objectsToPickup.Count > 0)
            {
                heldObject = objectsToPickup.First();
                heldObject.transform.SetParent(this.transform);
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
                isGrabbing = true;
                Debug.Log("Picked up " + heldObject.name);
            }
        }
        if (Input.GetKeyUp(KeyCode.E) && isGrabbing)
        {
            // let go
            heldObject.transform.SetParent(null);
            isGrabbing = false;
            Debug.Log("Let go of " + heldObject.name);
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
