using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
	public float speed = 10.0f;
	public float turnSpeed = 360.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		var scrollVal = Input.GetAxis("Mouse ScrollWheel");
	
		// Scroll down to lower hand
		if (scrollVal < 0f)
		{
			Vector3 position = this.transform.position;
			position.y -= speed*Time.deltaTime;
			this.transform.position = position;
		}

		// Scroll up to lower hand
		if (scrollVal > 0f)
		{
			Vector3 position = this.transform.position;
			position.y += speed*Time.deltaTime;
			this.transform.position = position;
		}

		// Press and hold left mouse button down to turn hand counterclockwise
		if (Input.GetKey (KeyCode.Mouse0)) 
		{
			transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime);
		}

		// Press and hold right mouse button down to turn hand clockwise
		if (Input.GetKey (KeyCode.Mouse1)) 
		{
			transform.Rotate(Vector3.left, turnSpeed * Time.deltaTime);
		}
	}
}
