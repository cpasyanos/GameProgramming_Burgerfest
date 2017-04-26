using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{
	private bool isShown = false;
	private bool isPaused = false;

	public GameObject controlDisplay;

	// Use this for initialization
	void Start () 
	{
		controlDisplay = GameObject.FindGameObjectWithTag ("Control");
		gameObject.SetActive (false);
		controlDisplay.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{
		if (isPaused) 
			Time.timeScale = 0; // Time stops
		else 
			Time.timeScale = 1; // Normal time
	}

	// Shows or hides pause menu
	public void TogglePauseMenu()
	{
		if (!controlDisplay.activeInHierarchy) //prevents mix-ups with toggling between control and pause menus
		{
			gameObject.SetActive (!gameObject.activeInHierarchy);
			isShown = !isShown;
			isPaused = !isPaused;
			// Resume normal time if not paused
			if (!isPaused)
				Time.timeScale = 1;
		}
	}

	// Shows or hides controls when paused
	public void ToggleControlDisplay()
	{
		gameObject.SetActive (!gameObject.activeInHierarchy);
		controlDisplay.SetActive (!controlDisplay.activeInHierarchy);
	}

	// Resume gameplay at same state
	public void Resume()
	{
		gameObject.SetActive (false);
		Time.timeScale = 1;
		isShown = false;
		isPaused = false;
	}

	// Start game over from beginning by reloading game scene
	public void Restart()
	{
		gameObject.SetActive (false);
		Time.timeScale = 1;
		isShown = false;
		isPaused = false;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	// Quit game and return to start menu
	public void Quit()
	{
		gameObject.SetActive (false);
		Time.timeScale = 1;
		isShown = false;
		isPaused = false;
		SceneManager.LoadScene ("StartMenu");
	}
}
