using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	private bool found = false;

	private GameObject score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!found){
			score = GameObject.FindGameObjectWithTag ("Score");
			if(score == null){
				score =GameObject.Instantiate (Resources.Load ("Prefabs/Controllers/ScoreController"), new Vector2 (), Quaternion.identity) as GameObject;
			}
			score.GetComponent<Score> ().UpdateHighScore ();
		}
	}
}
