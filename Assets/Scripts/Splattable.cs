using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splattable : MonoBehaviour {
    private const int MAX_SPLATS = 3;

    public GameObject[] ketchupSplatObjects = new GameObject[MAX_SPLATS];
    private int ketchupSplatCount;

    public GameObject[] mustardSplatObjects = new GameObject[MAX_SPLATS];
    private int mustardSplatCount;


    public void Splat(Splatter.SplatterTypes SplatType)
    {
        switch (SplatType)
        {
            case (Splatter.SplatterTypes.KETCHUP):
                {
                    if (ketchupSplatCount < MAX_SPLATS)
                    {
                        ketchupSplatObjects[ketchupSplatCount].SetActive(true);
                        ketchupSplatCount++;
                    }
                    break;
                }
            case (Splatter.SplatterTypes.MUSTARD):
                {
                    if (mustardSplatCount < MAX_SPLATS)
                    {
                        mustardSplatObjects[mustardSplatCount].SetActive(true);
                        mustardSplatCount++;
                    }
                    break;
                }
        }

    }
}
