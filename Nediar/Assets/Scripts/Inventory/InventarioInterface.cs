using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventarioInterface : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler  
{

	public Text cant;
	public Image sprite;
	public Button button;
	public int id;
	public AdminBD admin;
	public static InventarioInterface arrastrando;


	public void OnBeginDrag(PointerEventData eventData)
	{
		arrastrando = this;
		InventarioObjPlaceHolder.current.sprite.sprite = sprite.sprite;
	}

	public void OnDrag(PointerEventData eventData)
	{
		InventarioObjPlaceHolder.current.transform.position = eventData.position;
	}

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
