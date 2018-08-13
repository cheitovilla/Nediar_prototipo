using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//las colisiones con los objetos recolectables
public class InventarioCollision : MonoBehaviour 
{
	public GameObject leyendaText;
	public int cant_Book = 0;
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
		//si colisiona con el objeto recogible, este hace lo siguiente:
		//agrega obj al inventario, se instancia un sist. de particulas, se activa leyenda, se destruye el obj.
		if (collider.GetComponent<ObjRecolectable>() != null) 
		{
			Instantiate(Resources.Load("Particle"), collider.transform.position, Quaternion.Euler(-90, 0, 0));
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
			leyendaText.SetActive (true);
			ObjRecolectable i = collider.GetComponent<ObjRecolectable> ();
			m.AddSometoInventory (i.id, i.cant);
			Destroy (collider.gameObject);		
			Recogiendo ();
		}
	}


	public void Recogiendo()
	{
		cant_Book++;
	}

	//funcion cerrar leyenda
	public void CloseLeyenda(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		leyendaText.SetActive (false);
	}
}
