using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

	private GameObject self;
	private static CanvasController selfScript;

	public static CanvasController SelfScript{
		get { return selfScript; }
	}

	private GameObject canvas;

	private GameObject capacity;
	private GameObject money;

	// Use this for initialization
	void Start () {

		self = GameObject.FindGameObjectWithTag ("CanvasController");
		selfScript = self.GetComponent<CanvasController> ();

		canvas = GameObject.FindGameObjectWithTag ("Canvas");

		capacity = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/Capacity"), new Vector2 (), Quaternion.identity) as GameObject;
		capacity.transform.SetParent (canvas.transform, false);

		money = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/Money"), new Vector2 (), Quaternion.identity) as GameObject;
		money.transform.SetParent (canvas.transform, false);

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


}
