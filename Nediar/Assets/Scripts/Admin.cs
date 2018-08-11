using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Admin : MonoBehaviour 
{

	//Se definen algunas variables a utilizar
	public Text cantEenemy;
	public Image image;
	public int numNPC;
	public GameObject[] Npcs;
	public static int NumEnemy;
	public int life;
	public float max_img, min_img;
	GameObject zombicito;
    public GameObject win;
    public GameObject lose;





	// Use this for initialization
	void Start () 
	{
		//Creacion aleatoria de cantidad de zombies
		numNPC = Random.Range (15, 25);
		Npcs = new GameObject[numNPC];
		life = 400;
		max_img = life;

		//Se instancian los zombies y sus caracteristicas con una posicion aleatoria
		for (int i = 0; i < numNPC; i++) 
		{
			zombicito = Instantiate (Resources.Load("Zombie", typeof(GameObject))) as GameObject;
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
        if (NumEnemy <= 0 )
        {
            win.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
        //lo que sucede cuando el jugador pierde
        if (life <= 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            lose.gameObject.SetActive(true);
            Cursor.visible = true;
            Camera.main.transform.SetParent(null);
            Time.timeScale = 0;

        }
    }

	//Se selecciona una posicion aleatoria de donde van a parecer los zombies
	Vector3 Select_Position()
	{
		Vector3 pos = new Vector3();
		pos.x = Random.Range(-80, 80);
		pos.y = 2.7f;
		pos.z = Random.Range(-80, 80);
		return pos;
	}

	//funcion de matar enemigos y descontar 1 
	public void KillEnemy()
	{
		NumEnemy = NumEnemy - 1;
		cantEenemy.text = "Enemies: " + NumEnemy.ToString ();
	}


	//Funcion de recuperar vida con el objeto recuperable lifeup
	public void GetLife()
	{
		if (life == 400)
		{
			image.fillAmount = (life) / 1;
		}
		life += 30;
		image.fillAmount = (life) / max_img; 
	}


	//funcion de perder vida cuando lo ataca un zombie
	public void LoseLife()
	{
		life -= 30;
		image.fillAmount = (life) / max_img;
	}

}
