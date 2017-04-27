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
        if (other.tag == "Ingredient" && other.GetComponent<IngredientScript>().kind != Burger.fillings.MUSTARD && other.GetComponent<IngredientScript>().kind != Burger.fillings.KETCHUP)
        {
            Splattable splattable = other.GetComponent<Splattable>();
            if (splattable == null)
            {
                Debug.LogError(other.name);
            }
            else
            {
                splattable.Splat(SplatType);
            }
        }
    }
}
