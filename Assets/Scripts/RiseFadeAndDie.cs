using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiseFadeAndDie : MonoBehaviour {
    public RectTransform rectTransform;
    public Text text;
	// Use this for initialization
	void Start () {
        StartCoroutine(RiseFadeDie());
	}
	
    private IEnumerator RiseFadeDie()
    {
        while (text.color.a > 0f)
        {
            text.color = new Color(text.color.r, text.color.b, text.color.g, text.color.a - .01f);
            rectTransform.position += new Vector3(0, .6f);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
