using System.Collections;
using System.Collections.Generic;
using UnityEngine;



	public enum States_Game
	{
		Idle, Moving, Rotating, Attack
	};


public class NPC : MonoBehaviour 
{

	bool start = false;
	public float speed = 2f;
	States_Game state;
	Vector3 rotation;
	public float walkk;


	// Use this for initialization
	void Start () 
	{
		

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!start)
		{
			Link_Start();
			start = true;            
		}
		StartCoroutine(SelectState());
	}


	public virtual void Link_Start()
	{
		StartCoroutine(SelectState());
	}


	public void Movement()
	{
		if(state == States_Game.Moving)
		{
			transform.position += transform.forward * speed * Time.deltaTime;
			walkk = 2;
		}
		if (state == States_Game.Rotating)
		{
			transform.eulerAngles += rotation;
			 
		}
		if (state == States_Game.Attack)
		{
			walkk = 0;
		}
	}

	IEnumerator SelectState()
	{
		yield return new WaitForSeconds(3);
		state = (States_Game)Random.Range(0, 3);
		StartCoroutine(SelectState());
		rotation.y = Random.Range(-1, 2);
	}


}
