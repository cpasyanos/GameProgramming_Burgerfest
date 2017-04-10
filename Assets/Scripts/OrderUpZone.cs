using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUpZone : MonoBehaviour {
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plate")
        {
            Scorer scorer = other.GetComponent<Scorer>();
            // get the ingredients
            // compare them with the current orders
            // if it's good, add the score
            // display a message
            // clear the plate and then reset it
            scorer.ClearPlate();
        }
    }

}
