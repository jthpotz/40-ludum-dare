using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CardEffects = GlobalConstants.CardEffects;

public class WorldController : MonoBehaviour {

	private GameObject self;
	private WorldController selfScript;

	private GameObject canvas;
	private GameObject canvasController;

	private Player p = new Player();

	// Use this for initialization
	void Start () {

		self = GameObject.FindGameObjectWithTag ("WorldController");
		selfScript = self.GetComponent<WorldController> ();

		canvas = GameObject.FindGameObjectWithTag ("Canvas");

		Object.DontDestroyOnLoad (self);

		canvasController = GameObject.Instantiate (Resources.Load ("Prefabs/Controllers/CanvasController"), new Vector2 (), Quaternion.identity) as GameObject;

	}
	
	// Update is called once per frame
	void Update () {
		p.H.UpdateHand ();
	}

	public void AddStarterCards(){
		for (int i = 0; i < 4; i++) {
			p.H.AddCard (Card.CreateCard (CardDescriptions.coins));
		}
		p.H.AddCard (Card.CreateCard (CardDescriptions.coinStack));
		for (int i = 0; i < 4; i++) {
			p.H.AddCard (Card.CreateCard (CardDescriptions.coins));
		}
		p.H.AddCard (Card.CreateCard (CardDescriptions.coinStack));

		p.H.AddCard (Card.CreateCard (CardDescriptions.rustySword));

	}
		
	public void DoCard(){
		
	}

}
