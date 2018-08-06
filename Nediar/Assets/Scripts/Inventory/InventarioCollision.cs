using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioCollision : MonoBehaviour 
{
	public GameObject leyendaText;
	AdminBD m;
	// Use this for initialization
	void Start () 
	{
		m = GetComponent<AdminBD> ();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void OnTriggerEnter ( Collider collider) 
	{
		if (collider.GetComponent<ObjRecolectable>() != null) 
		{
			Instantiate(Resources.Load("Particle"), collider.transform.position, Quaternion.Euler(-90, 0, 0));
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
			leyendaText.SetActive (true);
			ObjRecolectable i = collider.GetComponent<ObjRecolectable> ();
			m.AddSometoInventory (i.id, i.cant);
			Destroy (collider.gameObject);		
		}
	}

	public void CloseLeyenda(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		leyendaText.SetActive (false);
	}
}
