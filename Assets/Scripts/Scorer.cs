using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int score;
    private Vector3 StartingPosition;
    private Transform myTransform;
    private Rigidbody myRigidbody;
    private Dictionary<Burger.fillings, int> ingredientHistogram = new Dictionary<Burger.fillings, int>();

    private void Reset()
    {
        ingredientHistogram.Clear();
        foreach (Burger.fillings filling in Enum.GetValues(typeof(Burger.fillings)))
        {
            ingredientHistogram.Add(filling, 0);
        }
        score = 0;
    }

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myTransform = transform;
        StartingPosition = myTransform.position;
        Reset();
    }

    public void AddIngredient(Burger.fillings ingredient)
    {
        int count;
        if (!ingredientHistogram.TryGetValue(ingredient, out count))
        {
            Debug.LogErrorFormat("Error: adding ingredient {0} not found in burger fillings enum.", ingredient.ToString());
            return;
        }
        Debug.Log(string.Format("Added {0}. New count {1}", ingredient.ToString(), count + 1));
        ingredientHistogram[ingredient] = (count + 1);
    }

    public void RemoveIngredient(Burger.fillings ingredient)
    {
        int count;
        if (!ingredientHistogram.TryGetValue(ingredient, out count))
        {
            Debug.LogErrorFormat("Error: adding ingredient {0} not found in burger fillings enum.", ingredient.ToString());
            return;
        }
        Debug.Log(string.Format("Removed {0}. New count {1}", ingredient.ToString(), count - 1));
        ingredientHistogram[ingredient] = (count - 1);
    }

    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
    }
    public void RemoveScore(int scoreAmount)
    {
        score -= scoreAmount;
    }

    public void ClearPlate()
    {
        Debug.Log("Bombs Away!");
        myRigidbody.AddTorque(new Vector3(-20, 15, 0), ForceMode.Impulse);
        myRigidbody.AddForce(new Vector3(-20, 15, 0), ForceMode.Impulse);
        StartCoroutine(WaitToResetPosition());
    }

    private IEnumerator WaitToResetPosition()
    {
        yield return new WaitForSeconds(3);
        Reset();
        ResetPosition();
    }

    private void ResetPosition()
    {
        myTransform.position = StartingPosition;
        myTransform.rotation = Quaternion.identity;
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.angularVelocity = Vector3.zero;
    }
}
