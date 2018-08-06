using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//administa las escenas
public class AdminScenes : MonoBehaviour {


	//si le da click al boton link star
	public void PlayGame(){
		
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	//sale de la aplicacion
	public void ExitAplication(){
		
		Application.Quit ();
	}



}
