using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour 
{
	private bool canGrab = false;
	private bool holdingOne = false;
	private Transform onhand;

	// Use this for initialization
	void Start () 
	{	
		canGrab = false;
		holdingOne = false;
		GameObject temp = GameObject.Find("HandTransform");
		onhand = temp.GetComponent<Transform>();

		this.GetComponent<Pickupable> ().enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{
		GrabObject (canGrab);
	}

	public void OnTriggerEnter(Collider other)
	{
		this.GetComponent<Pickupable> ().enabled = true;

		if(this.GetComponent<Pickupable> ().enabled)
			Debug.Log ("ENTER" + other.name);
		SetGrab (true);
	}

	public void GrabObject(bool can)
	{
		if (Input.GetKeyDown (KeyCode.E) && can && !holdingOne) 
		{
			holdingOne = true;
			GetComponent<Rigidbody> ().useGravity = false;
			this.transform.position = onhand.position;
			this.transform.parent = GameObject.Find ("Main Camera").transform;
			this.transform.parent = GameObject.Find ("HandTransform").transform;
			
		}
		if (Input.GetKeyUp (KeyCode.E)) 
		{
			holdingOne = false;
			this.transform.parent = null;
			GetComponent<Rigidbody> ().useGravity = true;
		}
	}

	public void OnTriggerExit(Collider other)
	{
		//Debug.Log ("EXIT" + this.name);
		SetGrab (false);
	}

	public bool GetGrab()
	{
		return canGrab;
	}

	public void SetGrab(bool grab)
	{
		canGrab = grab;
	}
}
