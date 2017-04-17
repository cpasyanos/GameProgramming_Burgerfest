using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour 
{
	private float x = 0.0f;
	private float y = 0.0f;
	private float z = -0.75f;

	public GameObject[] ingredientPrefabs;
	public GameObject[] ingredientBox;

	// Use this for initialization
	void Start () 
	{	
		// Spawn
		for (int i = 0; i < ingredientBox.Length; i++) 
		{
			if (ingredientPrefabs [i].CompareTag ("Pickles")) 
			{
				SpawnIngredients (ingredientPrefabs [i], ingredientBox [i], 15, x - 0.25f, y, z - 0.2f, 0.0f, 0.12f);
				SpawnIngredients (ingredientPrefabs [i], ingredientBox [i], 15, x, y, z - 0.2f, 0.0f, 0.12f);
				SpawnIngredients (ingredientPrefabs [i], ingredientBox [i], 15, x + 0.25f, y, z - 0.2f, 0.0f, 0.12f);
			} 
			else if (ingredientPrefabs [i].CompareTag ("TopBun")) 
			{
				SpawnIngredients (ingredientPrefabs [i], ingredientBox [i], 5, x, y + 0.25f, z + 1.25f, 0.25f, 0.0f);
			}
			else if (ingredientPrefabs [i].CompareTag ("BottomBun")) 
			{
				SpawnIngredients (ingredientPrefabs [i], ingredientBox [i], 5, x, y + 0.25f, z + 0.25f, 0.25f, 0.0f);
			}
			else if (ingredientPrefabs [i].CompareTag ("Patty")) 
			{
				SpawnIngredients (ingredientPrefabs [i], ingredientBox [i], 3, x - 0.5f, y + 0.25f, z + 0.75f, 0.25f, 0.0f);
				SpawnIngredients (ingredientPrefabs [i], ingredientBox [i], 3, x + 0.25f, y + 0.25f, z + 0.3f, 0.25f, 0.0f);
				SpawnIngredients (ingredientPrefabs [i], ingredientBox [i], 3, x + 0.25f, y + 0.25f, z + 1.2f, 0.25f, 0.0f);
			}
			else
				SpawnIngredients (ingredientPrefabs [i], ingredientBox [i], 10, x, y, z, 0.0f, 0.15f);
		}
	}
		
	public void SpawnIngredients(GameObject ingredient, GameObject box, int n, float x, float y, float z, float yOffset, float zOffset)
	{
		for (int i = 0; i < n; i++) 
		{
			Vector3 pos = box.transform.position + new Vector3 (x, y, z);  
			Instantiate (ingredient, pos, Quaternion.identity);
			y += yOffset;
			z += zOffset;
		}
	}

}
