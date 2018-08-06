using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminScenes : MonoBehaviour {

	public void PlayGame(){
		
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void ExitAplication(){
		
		Application.Quit ();
	}

	public void SceneInitial()
	{
		//SceneManager.LoadScene
	}

}
