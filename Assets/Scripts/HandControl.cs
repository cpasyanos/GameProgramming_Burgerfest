using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
	private Rigidbody rigidbody;

	public float speed = 10.0f;
	public float turnSpeed = 360.0f;
    public float moveSpeed = 10000f;

    public Camera FollowCam;
    public Vector3 CameraOffset;

	// Use this for initialization
	void Start()
	{
        Cursor.lockState = CursorLockMode.Locked;
		rigidbody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetAxis("Mouse X") != 0)
        {
            rigidbody.AddForce(new Vector3(Input.GetAxisRaw("Mouse Y") * Time.deltaTime * -1 * moveSpeed,
                0.0f, Input.GetAxisRaw("Mouse X") * Time.deltaTime * moveSpeed));
        }

        var scrollVal = Input.GetAxis("Mouse ScrollWheel");

		// Scroll down to lower hand
		if (scrollVal < 0f)
		{
			Vector3 position = this.transform.position;
			rigidbody.AddForce (0, -250, 0);
		}
	
		// Scroll up to lower hand
		if (scrollVal > 0f)
		{
			Vector3 position = this.transform.position;
			rigidbody.AddForce (0, 250, 0);
		}
        if (scrollVal == 0 && Input.GetAxis("Mouse X") == 0)
        {// Stops rigidbody movement if no scroll wheel input
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
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

        FollowCam.transform.position = this.transform.position + CameraOffset;
	}
}
