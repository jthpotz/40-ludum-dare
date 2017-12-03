using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CanvasController : MonoBehaviour {

	private GameObject self;
	private static CanvasController selfScript;

	public static CanvasController SelfScript{
		get { return selfScript; }
	}

	private GameObject canvas;

	private GameObject capacity;
	private GameObject money;
	private GameObject health;
	private GameObject enemyName;
	private GameObject distance;

	// Use this for initialization
	void Start () {

		self = GameObject.FindGameObjectWithTag ("CanvasController");
		selfScript = self.GetComponent<CanvasController> ();

		canvas = GameObject.FindGameObjectWithTag ("Canvas");

		capacity = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/Capacity"), new Vector2 (), Quaternion.identity) as GameObject;
		capacity.transform.SetParent (canvas.transform, false);

		money = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/Money"), new Vector2 (), Quaternion.identity) as GameObject;
		money.transform.SetParent (canvas.transform, false);

		distance = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/Distance"), new Vector2 (), Quaternion.identity) as GameObject;
		distance.transform.SetParent (canvas.transform, false);

		GameObject.FindGameObjectWithTag ("WorldController").GetComponent<WorldController> ().AddStarterCards ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void UpdateCapacity(int num){
		int dig1 = 0;
		int dig2 = 0;

		dig1 = num % 10;
		num /= 10;
		dig2 = num % 10;

		if(SelfScript == null){
			return;
		}

		foreach(Transform ch in SelfScript.capacity.transform){
			if(ch.CompareTag ("CD1s")){
				ch.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + dig1.ToString ());
			}
			else if(ch.CompareTag ("CD10s")){
				ch.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + dig2.ToString ());
			}
		}

	}

	public static void UpdateMaxCapacity(int num){
		int dig1 = 0;
		int dig2 = 0;

		dig1 = num % 10;
		num /= 10;
		dig2 = num % 10;

		if(SelfScript == null){
			return;
		}

		foreach(Transform ch in SelfScript.capacity.transform){
			if(ch.CompareTag ("MD1s")){
				ch.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + dig1.ToString ());
			}
			else if(ch.CompareTag ("MD10s")){
				ch.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + dig2.ToString ());
			}
		}

	}


	public static void UpdateMoney(int num){
		int dig1 = 0;
		int dig2 = 0;
		int dig3 = 0;

		dig1 = num % 10;
		num /= 10;
		dig2 = num % 10;
		num /= 10;
		dig3 = num % 10;

		if(SelfScript == null){
			return;
		}

		foreach(Transform ch in SelfScript.money.transform){
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

	public void AnEnemyAppears(Enemy e){
		health = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/Health"), new Vector2 (), Quaternion.identity) as GameObject;
		health.transform.SetParent (canvas.transform, false);
		EnemyName (e);
	}


	public static void UpdateHealth(int num){
		int dig1 = 0;
		int dig2 = 0;

		dig1 = num % 10;
		num /= 10;
		dig2 = num % 10;

		if(SelfScript == null){
			return;
		}

		foreach(Transform ch in SelfScript.health.transform){
			if(ch.CompareTag ("CD1s")){
				ch.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + dig1.ToString ());
			}
			else if(ch.CompareTag ("CD10s")){
				ch.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + dig2.ToString ());
			}
		}

	}

	private void EnemyName(Enemy e){
		enemyName = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/Name"), new Vector2 (), Quaternion.identity) as GameObject;
		enemyName.transform.SetParent (canvas.transform, false);

		string eName = e.Name.ToString ();

		int split = 0;

		GameObject label;

		for (int i = 1; i < eName.Length; i++) {
			if (Char.IsUpper (eName [i])) {
				split = i;
				break;
			}
		}

		if(split == 0){
			split = eName.Length;
		}

		for(int i = 0; i < split; i++){
			label = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/Label"), new Vector2 (GlobalConstants.enemyNameStartCol + (GlobalConstants.enemyNameOffset * (GlobalConstants.enemyLettersPerRow - split)) + i * GlobalConstants.enemyNameOffset, GlobalConstants.enemyNameStartRow), Quaternion.identity) as GameObject;
			label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Letters/" + Char.ToUpper (eName[i]));
			((RectTransform)(label.transform)).SetParent (enemyName.transform, false);
		}

		for(int i = split; i < eName.Length; i++){
			label = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/Label"), new Vector2 (GlobalConstants.enemyNameStartCol * GlobalConstants.enemyNameOffset, GlobalConstants.enemyNameStartRow - GlobalConstants.enemyNameOffset), Quaternion.identity) as GameObject;
			label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Letters/" + Char.ToUpper (eName[i]));
			((RectTransform)(label.transform)).SetParent (enemyName.transform, false);
		}

	}

	public void EnemyDefeated(){
		GameObject.Destroy (health);
		GameObject.Destroy (enemyName);
	}

	public static void UpdateDistance (int num){
		int dig1 = 0;
		int dig2 = 0;
		int dig3 = 0;

		dig1 = num % 10;
		num /= 10;
		dig2 = num % 10;
		num /= 10;
		dig3 = num % 10;

		if(SelfScript == null){
			return;
		}

		foreach(Transform ch in SelfScript.distance.transform){
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
