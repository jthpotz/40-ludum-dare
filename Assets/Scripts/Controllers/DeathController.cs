using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour {

	private GameObject disp;
	public DisplayMessage displayMessage;

	private GameObject canvas;

	private bool started = false;

	// Use this for initialization
	void Start () {

		disp = GameObject.Instantiate (Resources.Load ("Prefabs/Controllers/DisplayController"), new Vector2 (), Quaternion.identity) as GameObject;
		displayMessage = disp.GetComponent<DisplayMessage> ();

		canvas = GameObject.FindGameObjectWithTag ("Canvas");

	}

	// Update is called once per frame
	void Update () {
		if(!started){
			started = true;
			Results ();
		}
	}

	void Results(){
		displayMessage.Display ("Over burdened with loot you collapse...", canvas, null, true);
	}

}
