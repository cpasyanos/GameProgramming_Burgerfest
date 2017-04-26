using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
	// Use this for initialization
	void Start () {	}
	
	// Update is called once per frame
	void Update () { }

	// Start or Replay game
	public void ToGame()
	{
		SceneManager.LoadScene ("newBurgerFestKitchen");
		//SceneManager.LoadScene ("BurgerFest Kitchen");
	}

	// Open Instructions scene
	public void ToInstructions()
	{
		SceneManager.LoadScene ("InstructionsMenu");
	}

	// Go to Start menu/title screen
	public void ToStart()
	{
		SceneManager.LoadScene ("StartMenu");
	}
}
