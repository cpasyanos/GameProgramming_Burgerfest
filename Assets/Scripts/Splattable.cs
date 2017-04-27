using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splattable : MonoBehaviour {

    public GameObject[] ketchupSplatObjects;
    private int ketchupSplatCount;

    public GameObject[] mustardSplatObjects;
    private int mustardSplatCount;


    public void Splat(Splatter.SplatterTypes SplatType)
    {
        switch (SplatType)
        {
            case (Splatter.SplatterTypes.KETCHUP):
                {
                    if (ketchupSplatCount < ketchupSplatObjects.Length)
                    {
                        ketchupSplatObjects[ketchupSplatCount].SetActive(true);
                        ketchupSplatObjects[ketchupSplatCount].GetComponent<MeshCollider>().enabled = true;
                        ketchupSplatCount++;
                    }
                    break;
                }
            case (Splatter.SplatterTypes.MUSTARD):
                {
                    if (mustardSplatCount < mustardSplatObjects.Length)
                    {
                        mustardSplatObjects[mustardSplatCount].SetActive(true);
                        mustardSplatObjects[mustardSplatCount].GetComponent<MeshCollider>().enabled = true;
                        mustardSplatCount++;
                    }
                    break;
                }
        }

    }
}
