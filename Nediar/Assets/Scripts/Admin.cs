using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Admin : MonoBehaviour 
{
	public Text cantEenemy;
	public Image image;
	public int numNPC;
	public GameObject[] Npcs;
	public static int NumEnemy;
	public int life;
	public float max_img, min_img;
	GameObject zombicito;





	// Use this for initialization
	void Start () 
	{
		numNPC = Random.Range (15, 25);
		Npcs = new GameObject[numNPC];
		life = 400;
		max_img = life;

		for (int i = 0; i < numNPC; i++) 
		{
			zombicito = Instantiate (Resources.Load("Zombie", typeof(GameObject))) as GameObject;
		//	zombicito.AddComponent(typeof(NewNPC));
			zombicito.tag = "Zombie";
			zombicito.transform.position = Select_Position ();
			Npcs [i] = zombicito;
		}

		NewNPC[] enemies = FindObjectsOfType<NewNPC> ();
		NumEnemy = enemies.Length;
		cantEenemy.text = "Enemies: " + NumEnemy.ToString(); 


	}
	
	// Update is called once per frame
	void Update () 
	{

	}


	Vector3 Select_Position()
	{
		Vector3 pos = new Vector3();
		pos.x = Random.Range(-80, 80);
		pos.y = 2.7f;
		pos.z = Random.Range(-80, 80);
		return pos;
	}

	public void KillEnemy()
	{
		NumEnemy = NumEnemy - 1;
		cantEenemy.text = "Enemies: " + NumEnemy.ToString ();
	}

	public void GetLife()
	{
		if (life == 400)
		{
			image.fillAmount = (life) / 1;
		}
		life += 30;
		image.fillAmount = (life) / max_img; 
	}

	public void LoseLife()
	{
		life -= 30;
		image.fillAmount = (life) / max_img;
	}

}
