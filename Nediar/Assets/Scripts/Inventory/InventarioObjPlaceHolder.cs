﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script para ver como se ve los objetos cuando salen del inventario
public class InventarioObjPlaceHolder : MonoBehaviour
{

	public static InventarioObjPlaceHolder current;
	public Image sprite;




	// Use this for initialization
	void Start () {
		if (current != null) 
			Destroy (gameObject);
		
		sprite = GetComponent<Image> ();
		current = this;
	}
	

}
