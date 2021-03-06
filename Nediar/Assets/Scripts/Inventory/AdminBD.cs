﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminBD : MonoBehaviour 
{
	
	[System.Serializable]
	public struct ObjInventarioId
	{
		public int id;
		public int cant;

		public ObjInventarioId(int id, int cant)
		{
			this.id = id;
			this.cant = cant;
		}

		public void AddCant(int cant)
		{
			this.cant += cant;
		}

	}

	public InventarioBD bd;
	public List<ObjInventarioId> inventario;


	public void Start()
	{
		ActInventario ();
	}



	//Agrega algo al inventario
	public void AddSometoInventory(int id, int cant)
	{
		for (int i = 0; i < inventario.Count; i++) 
		{	
			if (inventario[i].id == id) 
			{
				inventario [i] = new ObjInventarioId (inventario [i].id, inventario [i].cant + cant);
				ActInventario ();
				return;
			}
		}
		inventario.Add (new ObjInventarioId (id, cant));
		ActInventario ();
	}

	//Elimina algo del inventario pero esta funcion no la implementé.
	public void DeleteSomeToinventory(int id, int cant)
	{
		for (int i = 0; i < inventario.Count; i++) 
		{
			if (inventario[i].id == id) 
			{
				inventario [i] = new ObjInventarioId(inventario[i].id, inventario[i].cant - cant);
				if (inventario [i].cant <= 0)
					inventario.Remove (inventario [i]);
				ActInventario ();
				return;
			}	
		}
		Debug.Log ("WTF?!");
	}

	//Cambiar posiciones de objetos en inventario
	public void ChangePosition(int i1, int i2)
	{
		ObjInventarioId i = inventario [i1];
		inventario [i1] = inventario [i2];
		inventario [i2] = i;
		ActInventario ();
	}


	public InventarioInterface prefab;
	public Transform inventarioUI;

	//cant de obj que si utilizamos o no
	List<InventarioInterface> pool = new List<InventarioInterface>();


	//actualizar inventario
	public void ActInventario()
	{	
		print ("actualizado");
		for (int i = 0; i < pool.Count; i++) 
		{
			if (i< inventario.Count) 
			{
				ObjInventarioId o = inventario [i];
				pool [i].sprite.sprite = bd.BD [o.id].sprite;
				pool [i].cant.text = o.cant.ToString ();
				pool [i].id = i;

				pool [i].button.onClick.RemoveAllListeners ();
				pool [i].button.onClick.AddListener (() => gameObject.SendMessage (bd.BD [o.id].funcion, SendMessageOptions.DontRequireReceiver));

				pool [i].gameObject.SetActive (true);
			}

			else 
			{
				pool [i].gameObject.SetActive (false);
			}
		}


		if (inventario.Count > pool.Count) 
		{
			for (int i = pool.Count; i < inventario.Count; i++) 
			{
				InventarioInterface oi = Instantiate (prefab, inventarioUI);
				pool.Add (oi);
				oi.transform.position = Vector3.zero;
				oi.transform.localScale = Vector3.one;

				ObjInventarioId o = inventario [i];
				pool [i].sprite.sprite = bd.BD [o.id].sprite;
				pool [i].cant.text = o.cant.ToString ();
				pool [i].id = i;
				pool [i].admin = this;

				pool [i].button.onClick.RemoveAllListeners ();
				pool [i].button.onClick.AddListener (() => gameObject.SendMessage (bd.BD [o.id].funcion, SendMessageOptions.DontRequireReceiver));

				pool [i].gameObject.SetActive (true);

			}	
		}

	}

	//Cuando se le da click aparece info del libro verde
	public void GreenBook()
	{
		print ("el libro verde");
	}

	//cuando se le da click info del libro rojo
	public void RedBook()
	{
		print ("el libro rojo");
	}

	//cuando se le da clic info del libro marron
	public void BrownBook()
	{
		print ("el libro marron");
	}

	//cuando se le da clic info del libro dorado
	public void GoldBook()
	{
		print ("el libro dorado");
	}


}
