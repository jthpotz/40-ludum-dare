using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public int score = 0;

	public int highScore = 0;

	public GameObject hsLabel;
	public GameObject canvas;

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateHighScore(){

		canvas = GameObject.FindGameObjectWithTag ("Canvas");

		hsLabel = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/HighScore"), new Vector2 (), Quaternion.identity) as GameObject;
		((RectTransform)(hsLabel.transform)).SetParent (canvas.transform, false);

		if(score > highScore){
			highScore = score;
		}

		int num = highScore;

		int dig1 = 0;
		int dig2 = 0;
		int dig3 = 0;

		dig1 = num % 10;
		num /= 10;
		dig2 = num % 10;
		num /= 10;
		dig3 = num % 10;

		foreach(Transform ch in hsLabel.transform){
			if(ch.CompareTag ("CD1s")){
				ch.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + dig1.ToString ());
			}
			else if(ch.CompareTag ("CD10s")){
				ch.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + dig2.ToString ());
			}
			else if(ch.CompareTag ("CD100s")){
				ch.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + dig3.ToString ());
			}
		}

	}

}
