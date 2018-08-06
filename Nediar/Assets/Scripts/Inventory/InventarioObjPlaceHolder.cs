using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
