using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuNavigation : MonoBehaviour {

	void Start(){
		
	}

	void Update(){
		
	}

	public void StartGame(){
		SceneManager.LoadScene ("MainLevel");
	}

	public void MainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void ToVictory(){
		SceneManager.LoadScene ("Victory");
	}

	public void ToDeath(){
		SceneManager.LoadScene ("Death");
	}

	public void ToTutorial(){
		SceneManager.LoadScene ("Tutorial");
	}

}
