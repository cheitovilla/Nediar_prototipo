using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script para activar y desactivar inventario
public class Inventario : MonoBehaviour 
{
	public GameObject inventario;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I)) 
		{
			inventario.SetActive (!inventario.activeInHierarchy);	
			Cursor.visible = !Cursor.visible;
			Cursor.lockState = CursorLockMode.Confined;
		}
	}
}
