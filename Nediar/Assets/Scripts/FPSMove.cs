﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMove : MonoBehaviour 
{

	public float speed;
	public float jumpForce;
	Rigidbody rb;
	Animator anim;
	public bool enSuelo = true;
	GameObject vida;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		anim.SetTrigger ("idle");
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKey (KeyCode.W)) 
		{
			anim.SetTrigger ("walkup");
			transform.position += transform.forward * speed * Time.deltaTime;

			if (Input.GetKey (KeyCode.Space)) 
			{
				if (enSuelo) 
				{
					enSuelo = false;
					anim.SetTrigger ("jump");
					transform.position += transform.up * speed * Time.deltaTime;	
					rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
				}
			} 

			else if (Input.GetButtonDown ("Fire1")) 
			{
				anim.SetTrigger ("attack");	
			}
		} 
		else if (Input.GetKey (KeyCode.S)) 
		{
			anim.SetTrigger ("walkback");
			transform.position -= transform.forward * speed * Time.deltaTime;

			if (Input.GetKey (KeyCode.Space)) 
			{
				if (enSuelo) 
				{
					enSuelo = false;
					anim.SetTrigger ("jump");
					transform.position += transform.up * speed * Time.deltaTime;	
					rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
				}
			} 

			else if (Input.GetButtonDown ("Fire1")) 
			{
				anim.SetTrigger ("attack");	
			}
		}

		else if (Input.GetKey (KeyCode.Space)) 
		{
			if (enSuelo) 
			{
				enSuelo = false;
				anim.SetTrigger ("jump");
				transform.position += transform.up * speed * Time.deltaTime;	
				rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
			}
		} 

		else if (Input.GetButtonDown ("Fire1")) 
		{
			anim.SetTrigger ("attack");	
		}

		else 
		{
			anim.SetTrigger ("idle");	
		}
	}


		private void OnCollisionEnter (Collision collision)
		{
			if (collision.gameObject.tag == "Piso") 
			{
				enSuelo = true;	
			}
			
			else if (collision.gameObject.tag == "Zombie") 
			{
				FindObjectOfType<Admin>().LoseLife();
			}

			else if (collision.gameObject.tag == "LifeUp") 
			{
				FindObjectOfType<Admin> ().GetLife ();
				Destroy (collision.gameObject);
				vida = Instantiate(Resources.Load("Life", typeof(GameObject))) as GameObject;
				vida.transform.position = new Vector3(Random.Range(-25, 25), 5f, Random.Range(-25, 25));
				vida.tag = "LifeUp";

			}

		}
}

