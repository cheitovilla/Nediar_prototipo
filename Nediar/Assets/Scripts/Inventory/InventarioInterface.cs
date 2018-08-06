using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//Este script contiene los diferentes eventos realizados en el inventario, como darle click, arrastrar, soltar.
public class InventarioInterface : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler  
{
	//definimos alguna svariales
	public Text cant;
	public Image sprite;
	public Button button;
	public int id;
	public AdminBD admin;
	public static InventarioInterface arrastrando;

	//cuando es arrastrado
	public void OnBeginDrag(PointerEventData eventData)
	{
		arrastrando = this;
		InventarioObjPlaceHolder.current.sprite.sprite = sprite.sprite;
	}

	//mientras se arrastra
	public void OnDrag(PointerEventData eventData)
	{
		InventarioObjPlaceHolder.current.transform.position = eventData.position;
	}

	//Cuando se suelta el objeto se va lejos para que no se vea
	public void OnEndDrag(PointerEventData eventData)
	{
		arrastrando = null;
		InventarioObjPlaceHolder.current.transform.position = new Vector3 (100000,100000,100000);
	}

	public void OnDrop(PointerEventData data)
	{
		if (arrastrando == null) 
			return;
		if (arrastrando == this)
			return;

		admin.ChangePosition (id, arrastrando.id);
	}

}
