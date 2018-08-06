using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//pues para pausar el juego
public class Pause : MonoBehaviour {


	public GameObject panel_pause;// un panel de menu pausa


	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1;
	}

	// Update is called once per frame
	//activa pausa
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Pausa ();
		}
	}

	//funcion pausa
	public void Pausa(){
		panel_pause.SetActive (true);

		Time.timeScale = 0;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;

	}

	//funcion continuar
	public void Reanudar(){

		panel_pause.SetActive (false);
		Time.timeScale = 1;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

	}

	//volver al menu
	public void VolverInicio(){
		SceneManager.LoadScene ("Inicio");
	}
}
