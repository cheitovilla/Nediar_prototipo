using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC 
{
	
	public Animator animZ;
	GameObject[] obj;
	public GameObject go;

	// Use this for initialization
	void Start () 
	{

		animZ = GetComponent<Animator>(); // animacion zombie
		Link_Start (); // metodo de iniciar
		obj = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
		animZ.SetTrigger ("idleZombie");
	}
	
	// Update is called once per frame
	void Update () 
	{

		Movement();
		Search ();
		if (walkk >1) {
			animZ.SetTrigger ("walkZombie");
		}

	}


	public override void Link_Start()
	{
		base.Link_Start ();
	}


	public void OnCollisionEnter(Collision collision)
	{
		//Si colisiona con la espada
		if (collision.gameObject.tag == "Sword") {
			animZ.SetTrigger ("deathZombie");
			Debug.Log ("me golpeo la espada");
			FindObjectOfType<Admin> ().KillEnemy ();
			Destroy (gameObject, 1);
		}

		if (collision.gameObject.tag == "Player") 
		{
			animZ.SetTrigger ("attackZombie");	
		}
	}



	void Search()
	{
		foreach (GameObject go in obj)
		{
			if (go != null)
			{      
				if (go.GetComponent<FPSMove>())
				{
					float dist = Vector3.Distance(go.transform.position, transform.position);

					if (dist < 5f)
					{
						animZ.SetTrigger("attackZombie");
						Vector3 direccion = go.transform.position - transform.position;
						dist = direccion.magnitude;
						transform.LookAt(go.transform.position);
						transform.position += Vector3.Normalize(go.transform.position - transform.position) * speed * Time.deltaTime;
					}
				}
			}

		}
	}


}
