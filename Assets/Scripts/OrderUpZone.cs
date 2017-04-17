using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUpZone : MonoBehaviour {

    public Text text;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plate")
        {
            Scorer scorer = other.GetComponent<Scorer>();
            // get the ingredients
            // compare them with the current orders
            // if it's good, add the score
            bool isGood = false;
            // display a message
            if (isGood)
            {
                StartCoroutine(GoodMessage());
            }
            else
            {
                StartCoroutine(BadMessage());
            }
            // clear the plate and then reset it
            scorer.ClearPlate();
        }
    }

    private IEnumerator BadMessage()
    {
        text.gameObject.SetActive(true);
        text.text = "Nobody ordered THAT!";
        text.color = Color.red;
        yield return new WaitForSeconds(2);
        text.gameObject.SetActive(false);
    }
    private IEnumerator GoodMessage()
    {
        text.gameObject.SetActive(true);
        text.text = "Order up!";
        text.color = Color.green;
        yield return new WaitForSeconds(2);
        text.gameObject.SetActive(false);
    }

}
