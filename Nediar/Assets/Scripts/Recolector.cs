using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recolector : MonoBehaviour 
{

	public Text countTextBook;
	private int countBook;
	public GameObject leyendaText;

	// Use this for initialization
	void Start () 
	{
		countBook = 0;
		SetCountText ();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	public void SetCountText ()
	{
		countTextBook.text = "Books: " + countBook.ToString ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Books")) 
		{
			Instantiate(Resources.Load("Particle"), other.transform.position, Quaternion.Euler(-90, 0, 0));
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
			leyendaText.SetActive (true);
			Destroy(other.gameObject);
			countBook += 1;
			SetCountText ();
		}
	}

	public void CloseLeyenda(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		leyendaText.SetActive (false);
	}
}
