using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public enum Estados
{
	patrullar, esperar , atacar
}


public class NewNPC : NavMesh 
{
	
	public Estados estados;
	public int i;
	public float rangoAtack = 20;
	public float rangoPoints = 10;
	public GameObject[] points;
	Transform p;
	public LayerMask Objetivo;
	public LayerMask Obstaculos;
	RaycastHit viendo;
	public bool atacar;
	public float correT = 0f;
	public float maximoTEspera = 3f;

	public Animator animZ;

	private void Awake()
	{
		InstancaiNav ();
	}

	// Use this for initialization
	void Start () 
	{
		i = Random.Range (0, 4);
		points = GameObject.FindGameObjectsWithTag("point");
		animZ = GetComponent<Animator>();
		p = GameObject.Find("Player_Sword").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		MachineStates();
		ViendoObjetivo();
	}


	public void MachineStates()
	{
		if (atacar)
		{
			transform.LookAt(p.position);
			estados = Estados.atacar;
		}
		else if (!atacar)
		{
			if (i >= points.Length)
			{
				estados = Estados.esperar;
			}
			else
			{
				estados = Estados.patrullar;
			}
		}
		switch (estados)
		{
		case Estados.patrullar:
			Patrulla();
			break;
		case Estados.esperar:
			Esperando();
			break;
		case Estados.atacar:
			Atacando();
			break;
		}
	}


	public void Patrulla()
	{
		int pos = Random.Range(0,4);
	 	float direction = (points[i].transform.position - transform.position).magnitude;
		if(direction >= rangoPoints)
		{
			target = (points[i].transform);
		}
		if(direction <= rangoPoints)
		{
			i = pos;
		}
		if(i == 4)
		{
			estados = Estados.esperar;
		}
		animZ.SetTrigger ("walkZombie");
		Moviendo();
	}

	public void Atacando()
	{
		
		if ((p.position - transform.position).magnitude <= 10)
		{
			animZ.SetTrigger("attackZombie");
		//	print("entra");
		
		}
		else
		{
			animZ.SetTrigger ("walkZombie");
			target = p;
			Moviendo();
		}
	}


	public void Esperando()
	{
		animZ.SetTrigger ("idleZombie");
		correT += Time.deltaTime;
		if (correT >= maximoTEspera)
		{
			i = 0;
			estados = Estados.patrullar;
			correT = 0f;
		}
	}

	private void ViendoObjetivo()
	{
		if (Physics.Raycast(transform.position, Vector3.Normalize(p.position - transform.position), out viendo, rangoAtack, Objetivo))
		{
			atacar = true;
			Debug.DrawRay(transform.position, Vector3.Normalize(p.position - transform.position) * viendo.distance, Color.green);
		}
		if (Physics.Raycast(transform.position, Vector3.Normalize(p.position - transform.position), out viendo, rangoAtack, Obstaculos))
		{
			atacar = false;
			Debug.DrawRay(transform.position, Vector3.Normalize(p.position - transform.position) * rangoAtack, Color.red);
		}
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


}
