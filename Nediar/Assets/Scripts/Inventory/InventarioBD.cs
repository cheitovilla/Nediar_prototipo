using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script para la creacion de base de datos con sus respectivos
[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]

public class InventarioBD : ScriptableObject 
{

	[System.Serializable]
	public struct ObjInventario
	{
		public string name;
		public Sprite sprite;
		public string funcion;

	}


	public ObjInventario[] BD;
}


	

