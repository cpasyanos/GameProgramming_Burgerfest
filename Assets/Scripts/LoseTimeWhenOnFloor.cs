using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTimeWhenOnFloor : MonoBehaviour {
	private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            LoseTimeAndDie();
        }
    }

    private void LoseTimeAndDie()
    {
        //Debug.Log("death comes for us all");
        ScoreManager.Instance.LoseTime();
        Destroy(gameObject);
    }
}
