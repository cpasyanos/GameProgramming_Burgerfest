using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
	private Rigidbody rigidbody;

	public float speed = 10.0f;
	public float turnSpeed = 360.0f;

	// Use this for initialization
	void Start()
	{
		rigidbody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () 
	{
		var scrollVal = Input.GetAxis("Mouse ScrollWheel");

		// Scroll down to lower hand
		if (scrollVal < 0f)
		{
			Vector3 position = this.transform.position;
			rigidbody.AddForce (0, position.y * -250, 0);
		}
	
		// Scroll up to lower hand
		if (scrollVal > 0f)
		{
			Vector3 position = this.transform.position;
			rigidbody.AddForce (0, position.y * 250, 0);
		}

		// Stops rigidbody movement if no scroll wheel input
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;

		// Press and hold left mouse button down to turn hand counterclockwise
		if (Input.GetKey (KeyCode.Mouse0)) 
		{
			transform.Rotate(Vector3.left, turnSpeed * Time.deltaTime);
		}

		// Press and hold right mouse button down to turn hand clockwise
		if (Input.GetKey (KeyCode.Mouse1)) 
		{
			transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime);
		}
	}
}
