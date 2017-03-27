using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splatter : MonoBehaviour {

    public Collider splatterCollider;
    public ParticleSystem splatterParticles;
    public enum SplatterTypes
    {
        KETCHUP = 1,
        MUSTARD = 2
    }

    public SplatterTypes SplatType;

    public void ToggleSplatter(bool active)
    {
        splatterCollider.enabled = active;
        splatterParticles.Play();

    }

	public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Splattable")
        {
            other.GetComponent<Splattable>().Splat(SplatType);
        }
    }
}
