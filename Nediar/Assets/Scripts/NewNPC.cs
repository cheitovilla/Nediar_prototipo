using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

//un enum para los estados de los enemigos
public enum Estados
{
	patrullar, esperar , atacar
}


public class NewNPC : NavMesh 
{
	//Definimos algunas variables
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


	//lamamos navmesh de los enemies
	private void Awake()
	{
		InstancaiNav ();
	}

	// Use this for initialization


	void Start () 
	{
		i = Random.Range (0, 4); //num aleatorio de donde iran los zombies
		points = GameObject.FindGameObjectsWithTag("point"); //diferentes posiciones a las que los zombies se dirigiran
		animZ = GetComponent<Animator>();
		p = GameObject.Find("Player_Sword").transform; // objetivo, el player
	}
	
	// Update is called once per frame
	void Update ()
	{
		MachineStates();
		ViendoObjetivo();
	}


	//maquina de estados para los estados
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

		//switch para seleccionar estados
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

	//metodo de patrulla, es e metodo donde los zombies caminan a diferentes puntos, son 5 puntos en total
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

	//si el zombie detenta al player, el ozmbie perseguirá al player
	public void Atacando()
	{
		
		if ((p.position - transform.position).magnitude <= 10)
		{
			animZ.SetTrigger("attackZombie");
		//	print("entra");
		
		}
		else
		{
			//sino, que siga su camino
			animZ.SetTrigger ("walkZombie");
			target = p;
			Moviendo();
		}
	}

	//un estado de esperar para complementar estados, el zombie espera x cantidad de tiempo un rato cuando llega a cierto punto
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

	//los zombies lanzan un raycast que permite ver a donde se dirigen, si al player o a los points
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


	//Colisiones del zombie
	public void OnCollisionEnter(Collision collision)
	{
		//Si colisiona con la espada este hara animacion de muerte y posteriormente morirá
		if (collision.gameObject.tag == "Sword") {
			animZ.SetTrigger ("deathZombie");
			Debug.Log ("me golpeo la espada");
			FindObjectOfType<Admin> ().KillEnemy ();
			Destroy (gameObject, 1);
		}

		//si colisiona con el player hará animacion del player.
		if (collision.gameObject.tag == "Player") 
		{
			animZ.SetTrigger ("attackZombie");	
		}
	}


}
