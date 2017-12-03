using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CardEffect = GlobalConstants.CardEffect;
using SpawnChance = GlobalConstants.SpawnChance;
using EventChance = GlobalConstants.EventChance;
using EventName = GlobalConstants.EventName;

public class WorldController : MonoBehaviour {

	private GameObject self;
	private WorldController selfScript;

	public GameObject canvas;
	private GameObject canvasController;
	private CanvasController ccScript;

	private GameObject disp;
	public DisplayMessage displayMessage;

	public Player p = new Player();

	public Enemy e = null;

	private bool playerTurn = true;

	private int distance = 0;


	private float moveDelay;
	private float eventDelay;

	private bool msgDone = true;

	// Use this for initialization
	void Start () {

		distance = Random.Range (GlobalConstants.minDistance, GlobalConstants.maxDistance);

		self = GameObject.FindGameObjectWithTag ("WorldController");
		selfScript = self.GetComponent<WorldController> ();

		canvas = GameObject.FindGameObjectWithTag ("Canvas");

		canvasController = GameObject.Instantiate (Resources.Load ("Prefabs/Controllers/CanvasController"), new Vector2 (), Quaternion.identity) as GameObject;
		ccScript = canvasController.GetComponent<CanvasController> ();

		disp = GameObject.Instantiate (Resources.Load ("Prefabs/Controllers/DisplayController"), new Vector2 (), Quaternion.identity) as GameObject;
		displayMessage = disp.GetComponent<DisplayMessage> ();

//		displayMessage.Display ("Welcome to LD 40! BaBam new line here?", canvas);
//		displayMessage.Display ("!.?/-^_><@#$%&*", canvas);
//		displayMessage.Display ("Doing more display testing right here.", canvas);
//		displayMessage.Display ("Even more display testing.", canvas);
	}
	
	// Update is called once per frame
	void Update () {
		CanvasController.UpdateDistance (distance);
		p.H.UpdateHand ();

		if(playerTurn == false){
			playerTurn = true;
			Invoke ("EnemyTurn", GlobalConstants.waitTime);
		}

		if(e == null && msgDone){
			if(p.H.enabled){
				p.H.DisableCards ();
			}
//			e = new Enemy (EnemyDescriptions.goblin);
//			ccScript.AnEnemyAppears (e);
//			CanvasController.UpdateHealth (e.Health);
			moveDelay += Time.deltaTime;
			Debug.Log (moveDelay);
			Debug.Log (GlobalConstants.baseTimePerMovem * (p.H.CurrentCapacity / p.H.TotalCapacity));
			Debug.Log (p.H.CurrentCapacity + ", " + p.H.TotalCapacity);
			if (moveDelay >= GlobalConstants.baseTimePerMovem * ((float)p.H.CurrentCapacity / (float)p.H.TotalCapacity)) {
				moveDelay = 0;
				distance--;
				CanvasController.UpdateDistance (distance);
			}

			eventDelay += Time.deltaTime;
			if(eventDelay >= GlobalConstants.eventDelayTime){
				eventDelay = 0;
				if(Random.Range (0, 100) < GlobalConstants.enemyChance){
					while (true) {
						if (Random.Range (0, 100) < (int)SpawnChance.Goblin) {
							e = new Enemy (EnemyDescriptions.goblin);
							ccScript.AnEnemyAppears (e);
							CanvasController.UpdateHealth (e.Health);
							displayMessage.Display ("An enemy " + e.Name + " appears!", canvas);
							Invoke ("StartPlayerTurn", GlobalConstants.waitTime);
							return;
						}
					}
				}
				else if(Random.Range (0, 100) < GlobalConstants.eventChance){
					while(true){
						if(Random.Range (0, 100) < (int)EventChance.FindLoot){
							msgDone = false;
							Invoke ("MsgDone", GlobalConstants.waitTime);
							Events.DoEvent (EventName.FindLoot, this);
							p.H.DisableCards ();
							return;
						}
					}
				}
			}

		}

		if(p.H.CurrentCapacity > p.H.TotalCapacity){
			GameObject.FindGameObjectWithTag ("MenuNavigation").GetComponent<MenuNavigation> ().ToDeath ();
		}

		if(distance == 0){
			GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ().score = p.H.ClearHand ();
			GameObject.FindGameObjectWithTag ("MenuNavigation").GetComponent<MenuNavigation> ().ToVictory ();
		}

	}

	public void AddStarterCards(){
		for (int i = 0; i < 4; i++) {
			p.H.AddCard (Card.CreateCard (CardDescriptions.coin));
		}
		p.H.AddCard (Card.CreateCard (CardDescriptions.coinStack));

		p.H.AddCard (Card.CreateCard (CardDescriptions.rustySword));

		p.H.AddCard (Card.CreateCard (CardDescriptions.quickShoe));

	}
		
	public void DealDamage(int dmg){
		msgDone = false;
		e.DealDamage (dmg);
		CanvasController.UpdateHealth (e.Health);
		if(e.Dead ()){
			displayMessage.Display ("You defeated a " + e.Name + "!", canvas);
			ccScript.EnemyDefeated ();
			Invoke ("EnemyDies", GlobalConstants.waitTime);
			Invoke ("GetRidOfEnemy", GlobalConstants.waitTime); 
			Invoke ("MsgDone", GlobalConstants.waitTime*3);
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
		Invoke ("StartPlayerTurn", GlobalConstants.waitTime);
	}

	public void StartPlayerTurn(){
		p.H.EnableCards ();
	}

	public void GetRidOfEnemy(){
		e = null;
	}

	public void MsgDone(){
		msgDone = true;
	}

	public void EnemyDies(){
		e.OnDeath (this);
	}

}
