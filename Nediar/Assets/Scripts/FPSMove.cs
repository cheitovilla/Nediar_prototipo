using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMove : MonoBehaviour 
{
	//Se definen algunas variables a utilizar
	public float speed;
    public float speedx2;
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
	
	// Este script tiene el movimiento del player y sus respectivas animaciones
	void Update ()
	{
		//caminar hacia delante
		if (Input.GetKey (KeyCode.W)) 
		{
			anim.SetTrigger ("walkup");
			transform.position += transform.forward * speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += transform.forward * speedx2 * Time.deltaTime;
            }
		} 

		//Caminar hacia atras
		else if (Input.GetKey (KeyCode.S)) 
		{
			anim.SetTrigger ("walkback");
			transform.position -= transform.forward * speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position -= transform.forward * speedx2 * Time.deltaTime;
            }

        }



		//salta mientras camina hacia atras
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

		//ataca estando quieto
		else if (Input.GetButtonDown ("Fire1")) 
		{
			anim.SetTrigger ("attack");	
		}

		//pose inicial
		else 
		{
			anim.SetTrigger ("idle");	
		}

       
	}













	//Colisiones
		private void OnCollisionEnter (Collision collision)
		{
		//verifica que este en piso para ver si salta o no
			if (collision.gameObject.tag == "Piso") 
			{
				enSuelo = true;	
			}
			
		//Pierde vida si colisiona con zombie
			else if (collision.gameObject.tag == "Zombie") 
			{
				FindObjectOfType<Admin>().LoseLife();
			}

		//recupera vida si colisiona con life up y este mismo objeto vuelve aparecer de manera aleatoria para volverlo a coger
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

