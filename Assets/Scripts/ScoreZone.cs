using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{

    [Tooltip("if true, the ingredients in this zone are not counted towards the burger total ingredients.")]
    public bool isBonusZone;

    [Tooltip("The amount of points to award for having ingredients in this score zone.")]
    public int scoreAmount;

    [Tooltip("The parent object that keeps track of what's on this plate")]
    public Scorer scorer;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ingredient")
        {
            if (!isBonusZone)
            {
                scorer.AddIngredient(other.GetComponent<IngredientScript>().kind);
            }
            scorer.AddScore(scoreAmount);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ingredient")
        {
            if (!isBonusZone)
            {
                scorer.RemoveIngredient(other.GetComponent<IngredientScript>().kind);
            }
            scorer.RemoveScore(scoreAmount);
        }
    }
}
