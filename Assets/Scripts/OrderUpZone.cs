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
            // display a message
            if (scorer.ClearPlateAndScore())
            {
                StartCoroutine(GoodMessage());
            }
            else
            {
                StartCoroutine(BadMessage());
            }
        }
    }

    public IEnumerator BadMessage()
    {
        text.gameObject.SetActive(true);
        text.text = "Nobody ordered THAT!";
        text.color = Color.red;
        yield return new WaitForSeconds(2);
        text.gameObject.SetActive(false);
    }
    public IEnumerator GoodMessage()
    {
        text.gameObject.SetActive(true);
        text.text = "Order up!";
        text.color = Color.green;
        yield return new WaitForSeconds(2);
        text.gameObject.SetActive(false);
    }

}
