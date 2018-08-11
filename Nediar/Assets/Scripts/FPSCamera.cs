using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour {

	public float mouseX;
	public float mouseY;
	public float secibility = 50f;
	public bool ShowCursor;

	public bool InvertedMouse;

	void Update()
	{
		MovMause();
	}

	//Script para mover la camara 
	void MovMause()
	{
		Camera cam = Camera.main;
		mouseX += (Input.GetAxis("Mouse X") * secibility) * Time.deltaTime;
		//mouseY -= (Input.GetAxis("Mouse Y") * secibility) * Time.deltaTime;
		transform.eulerAngles = new Vector3(0, mouseX, 0);
		cam.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
	
	}
}
