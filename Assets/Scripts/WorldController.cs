using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CardEffect = GlobalConstants.CardEffect;

public class WorldController : MonoBehaviour {

	private GameObject self;
	private WorldController selfScript;

	private GameObject canvas;
	private GameObject canvasController;
	private CanvasController ccScript;

	private GameObject disp;
	private DisplayMessage displayMessage;

	public Player p = new Player();

	public Enemy e = null;

	private bool playerTurn = true;

	// Use this for initialization
	void Start () {

		self = GameObject.FindGameObjectWithTag ("WorldController");
		selfScript = self.GetComponent<WorldController> ();

		canvas = GameObject.FindGameObjectWithTag ("Canvas");

		Object.DontDestroyOnLoad (self);

		canvasController = GameObject.Instantiate (Resources.Load ("Prefabs/Controllers/CanvasController"), new Vector2 (), Quaternion.identity) as GameObject;
		ccScript = canvasController.GetComponent<CanvasController> ();

		disp = GameObject.Instantiate (Resources.Load ("Prefabs/Controllers/DisplayController"), new Vector2 (), Quaternion.identity) as GameObject;
		displayMessage = disp.GetComponent<DisplayMessage> ();


		displayMessage.Display ("Welcome to LD 40! BaBam new line here?", canvas);
		displayMessage.Display ("!.?/-^_><@#$%&", canvas);
		displayMessage.Display ("Doing more display testing right here.", canvas);
		displayMessage.Display ("Even more display testing.", canvas);
	}
	
	// Update is called once per frame
	void Update () {
		p.H.UpdateHand ();

		if(playerTurn == false){
			playerTurn = true;
			EnemyTurn ();
			Invoke ("StartPlayerTurn", GlobalConstants.waitTime);
		}

		if(e == null){
			e = new Enemy (EnemyDescriptions.goblin);
			ccScript.AnEnemyAppears (e);
			CanvasController.UpdateHealth (e.Health);
		}

		if(p.H.CurrentCapacity > p.H.TotalCapacity){
			Debug.Log ("Game Over");
		}

	}

	public void AddStarterCards(){
		for (int i = 0; i < 4; i++) {
			p.H.AddCard (Card.CreateCard (CardDescriptions.coins));
		}
		p.H.AddCard (Card.CreateCard (CardDescriptions.coinStack));

		p.H.AddCard (Card.CreateCard (CardDescriptions.rustySword));

	}
		
	public void DealDamage(int dmg){
		e.DealDamage (dmg);
		CanvasController.UpdateHealth (e.Health);
		if(e.Dead ()){
			ccScript.EnemyDefeated ();
			e = null;
		}
	}

	public void PlayerTurnOver(){
		playerTurn = false;
		p.H.DisableCards ();
	}

	public void EnemyTurn(){
		if (e == null){
			return;
		}
		e.action (this, null);
	}

	public void StartPlayerTurn(){
		p.H.EnableCards ();
	}

}
