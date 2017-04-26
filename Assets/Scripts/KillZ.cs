using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys all gameObjects that collide with it
/// </summary>
public class KillZ : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ingredient")
        {
            Destroy(other);
        }
    }
}
