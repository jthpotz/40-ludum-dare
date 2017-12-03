using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using CardEffect = GlobalConstants.CardEffect;
using SpawnChance = GlobalConstants.SpawnChance;
using EventChance = GlobalConstants.EventChance;
using EventName = GlobalConstants.EventName;

public class WorldController : MonoBehaviour {

	private GameObject self;
	public WorldController selfScript;

	public GameObject canvas;
	private GameObject canvasController;
	private CanvasController ccScript;

	private GameObject disp;
	public DisplayMessage displayMessage;

	public Player p = new Player();

	public Enemy e = null;

	private bool playerTurn = true;

	private int distance = 0;

	public int Distance{
		get { return distance; }
		set { distance += value; }
	}

	private float moveDelay;
	private float eventDelay;

	private bool msgDone = true;

	private GameObject moveInd;
	private Image i1;
	private Image i2;
	private Image i3;

	public GameObject aControlGO;
	public AudioController aControl;

	public int kills = 0;

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

		moveInd = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/MoveInd"), new Vector2 (), Quaternion.identity) as GameObject;
		((RectTransform)(moveInd.transform)).SetParent (canvas.transform, false);

		foreach(Transform ch in moveInd.transform){
			if(ch.CompareTag ("Dot1")){
				i1 = ch.GetComponent<Image> ();
			}
			if(ch.CompareTag ("Dot2")){
				i2 = ch.GetComponent<Image> ();
			}
			if(ch.CompareTag ("Dot3")){
				i3 = ch.GetComponent<Image> ();
			}
		}

		aControlGO = GameObject.Instantiate (Resources.Load ("Prefabs/Controllers/AudioController"), new Vector2 (), Quaternion.identity) as GameObject;
		aControl = aControlGO.GetComponent<AudioController> ();


//		displayMessage.Display ("Welcome to LD 40! BaBam new line here?", canvas);
//		displayMessage.Display ("!.?/-^_><@#$%&*", canvas);
//		displayMessage.Display ("Doing more display testing right here.", canvas);
//		displayMessage.Display ("Even more display testing.", canvas);
	}
	
	// Update is called once per frame
	void Update () {
		CanvasController.UpdateDistance (distance);
		CanvasController.UpdateMaxCapacity (p.H.TotalCapacity);
		p.H.UpdateHand ();

		if(msgDone && p.H.CurrentCapacity > p.H.TotalCapacity){
			GameObject.FindGameObjectWithTag ("MenuNavigation").GetComponent<MenuNavigation> ().ToDeath ();
		}

		if(distance <= 0){
			GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ().score = p.H.ClearHand ();
			GameObject.FindGameObjectWithTag ("MenuNavigation").GetComponent<MenuNavigation> ().ToVictory ();
		}

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
			if(!i1.enabled && moveDelay >= GlobalConstants.baseTimePerMovem * ((float)p.H.CurrentCapacity / (float)p.H.TotalCapacity) * ((float)1/(float)4)){
				i1.enabled = true;
			}

			if(!i2.enabled && moveDelay >= GlobalConstants.baseTimePerMovem * ((float)p.H.CurrentCapacity / (float)p.H.TotalCapacity) * ((float)1/(float)2)){
				i2.enabled = true;
			}

			if(!i3.enabled && moveDelay >= GlobalConstants.baseTimePerMovem * ((float)p.H.CurrentCapacity / (float)p.H.TotalCapacity) * ((float)3/(float)4)){
				i3.enabled = true;
			}

			if (moveDelay >= GlobalConstants.baseTimePerMovem * ((float)p.H.CurrentCapacity / (float)p.H.TotalCapacity)) {
				moveDelay = 0;
				distance--;
				i1.enabled = false;
				i2.enabled = false;
				i3.enabled = false;
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
							displayMessage.Display ("An enemy " + e.Name + " appears!", canvas, aControl.enemyAppear);
							Invoke ("StartPlayerTurn", GlobalConstants.waitTime);
							return;
						}
						if (Random.Range (0, 100) < (int)SpawnChance.Troll) {
							e = new Enemy (EnemyDescriptions.troll);
							ccScript.AnEnemyAppears (e);
							CanvasController.UpdateHealth (e.Health);
							displayMessage.Display ("An enemy " + e.Name + " appears!", canvas, aControl.enemyAppear);
							Invoke ("StartPlayerTurn", GlobalConstants.waitTime);
							return;
						}
						if (Random.Range (0, 100) < (int)SpawnChance.Rat) {
							e = new Enemy (EnemyDescriptions.rat);
							ccScript.AnEnemyAppears (e);
							CanvasController.UpdateHealth (e.Health);
							displayMessage.Display ("An enemy " + e.Name + " appears!", canvas, aControl.enemyAppear);
							Invoke ("StartPlayerTurn", GlobalConstants.waitTime);
							return;
						}
						if (Random.Range (0, 100) < (int)SpawnChance.Minotaur) {
							e = new Enemy (EnemyDescriptions.minotaur);
							ccScript.AnEnemyAppears (e);
							CanvasController.UpdateHealth (e.Health);
							displayMessage.Display ("An enemy " + e.Name + " appears!", canvas, aControl.enemyAppear);
							Invoke ("StartPlayerTurn", GlobalConstants.waitTime);
							return;
						}
						if (Random.Range (0, 100) < (int)SpawnChance.Wolf) {
							e = new Enemy (EnemyDescriptions.wolf);
							ccScript.AnEnemyAppears (e);
							CanvasController.UpdateHealth (e.Health);
							displayMessage.Display ("An enemy " + e.Name + " appears!", canvas, aControl.enemyAppear);
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
						if(Random.Range (0, 100) < (int)EventChance.Energize){
							msgDone = false;
							Invoke ("MsgDone", GlobalConstants.waitTime);
							Events.DoEvent (EventName.Energize, this);
							p.H.DisableCards ();
							return;
						}
						if(Random.Range (0, 100) < (int)EventChance.SuperStrength){
							msgDone = false;
							Invoke ("MsgDone", GlobalConstants.waitTime);
							Events.DoEvent (EventName.SuperStrength, this);
							p.H.DisableCards ();
							return;
						}
						if(Random.Range (0, 100) < (int)EventChance.Weaken){
							msgDone = false;
							Invoke ("MsgDone", GlobalConstants.waitTime);
							Events.DoEvent (EventName.Weaken, this);
							p.H.DisableCards ();
							return;
						}
						if(Random.Range (0, 100) < (int)EventChance.ParalysingWeakness){
							msgDone = false;
							Invoke ("MsgDone", GlobalConstants.waitTime);
							Events.DoEvent (EventName.ParalysingWeakness, this);
							p.H.DisableCards ();
							return;
						}
						if(Random.Range (0, 100) < (int)EventChance.Speed){
							msgDone = false;
							Invoke ("MsgDone", GlobalConstants.waitTime);
							Events.DoEvent (EventName.Speed, this);
							p.H.DisableCards ();
							return;
						}
						if(Random.Range (0, 100) < (int)EventChance.Flash){
							msgDone = false;
							Invoke ("MsgDone", GlobalConstants.waitTime);
							Events.DoEvent (EventName.Flash, this);
							p.H.DisableCards ();
							return;
						}
						if(Random.Range (0, 100) < (int)EventChance.Lost){
							msgDone = false;
							Invoke ("MsgDone", GlobalConstants.waitTime);
							Events.DoEvent (EventName.Lost, this);
							p.H.DisableCards ();
							return;
						}
						if(Random.Range (0, 100) < (int)EventChance.Bewildered){
							msgDone = false;
							Invoke ("MsgDone", GlobalConstants.waitTime);
							Events.DoEvent (EventName.Bewildered, this);
							p.H.DisableCards ();
							return;
						}
					}
				}
			}

		}

	}

	public void AddStarterCards(){
		for (int i = 0; i < 2; i++) {
			p.H.AddCard (Card.CreateCard (CardDescriptions.coin));
		}
		p.H.AddCard (Card.CreateCard (CardDescriptions.coinStack));

		p.H.AddCard (Card.CreateCard (CardDescriptions.rustySword));

		p.H.AddCard (Card.CreateCard (CardDescriptions.quickShoe));

		p.H.AddCard (Card.CreateCard (CardDescriptions.blink));

		//p.H.AddCard (Card.CreateCard (CardDescriptions.smallSling));
	}
		
	public void DealDamage(int dmg){
		msgDone = false;
		e.DealDamage (dmg);
		CanvasController.UpdateHealth (e.Health);
		if(e.Dead ()){
			displayMessage.Display ("You defeated a " + e.Name + "!", canvas, aControl.enemyDefeated);
			kills++;
			CanvasController.UpdateKills (kills);
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
