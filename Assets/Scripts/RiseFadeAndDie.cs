using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiseFadeAndDie : MonoBehaviour {
    public RectTransform rectTransform;
    public float initialHeight = 50f;
    public Text text;

    public void SetHeight(float newHeight)
    {
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, 0);
    }

    void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(RiseFadeDie());
    }
	
    private IEnumerator RiseFadeDie()
    {
        SetHeight(50);
        text.color = new Color(text.color.r, text.color.b, text.color.g, 1);
        while (text.color.a > 0f)
        {
            text.color = new Color(text.color.r, text.color.b, text.color.g, text.color.a - .01f);
            rectTransform.position += new Vector3(0, .6f);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
