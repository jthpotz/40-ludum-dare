using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using Effect = GlobalConstants.Effect;
using CardEffect = GlobalConstants.CardEffect;
using CardName = GlobalConstants.CardName;
using CardType = GlobalConstants.CardType;
using Sizings = GlobalConstants.Sizings;

public class Card : MonoBehaviour {



	public int weight = 0;
	public int attack = 0;
	public int value = 0;
	public int uses = 0;
	public int capacity = 0;
	public int teleport = 0;
	public Effect action = null; 
	public CardEffect actionEnum = CardEffect.None;
	public CardType type;
	public new CardName name;

	private int pos = 0;

	private GameObject go;


	public int Weight{
		get { return weight; }
	}
	public int Attack{
		get { return attack; }
	}
	public int Value{
		get { return value; }
	}
	public int Uses{
		get { return uses; }
	}
	public int Capacity{
		get { return capacity; }
	}
	public int Teleport{
		get { return teleport; }
	}
	public Effect Action{
		get { return action; }
	}
	public CardEffect ActionEnum{
		get { return actionEnum; }
	}
	public CardType Type{
		get { return type; }
	}
	public CardName Name{
		get { return name; }
	}

	public int Pos{
		get { return pos; }
		set { pos = value; }
	} 

	public GameObject GO{
		get { return go; }
	}

	void Start(){
		go = gameObject;
		go.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);

	}

	void Update(){
		
	}

	public void InitCard(int w, int a, int v, int u, int c, int tel, CardType t, CardName n, CardEffect e = CardEffect.None){


		weight = w;
		attack = a;
		value = v;
		uses = u;
		capacity = c;
		teleport = tel;
		type = t;
		name = n;

		actionEnum = e;
		switch (e) {
		case CardEffect.ChangeCapacity:
			action = ChangeCapacity;
			break;
		case CardEffect.AttackCard:
			action = AttackCard;
			break;
		case CardEffect.Transport:
			action = Transport;
			break;
		default:
			break;
		}

		BuildCardVisuals (this);

	}

	public static Card CreateCard (CardDescriptions c) {
		GameObject newGO = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/GenericCard"), new Vector3 (), Quaternion.identity) as GameObject;
		Card newCard = newGO.GetComponent<Card> ();
		newCard.InitCard (c.weight, c.attack, c.value, c.uses, c.capacity, c.teleport, c.type, c.name, c.action);
		//Card newCard = new Card (c.Weight, c.Attack, c.Value, c.Uses, c.Type, c.Name, c.ActionEnum);
		//newCard.GO = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/GenericCard"), new Vector3 (), Quaternion.identity) as GameObject;
		
		return newCard;
	}

	private static void BuildCardVisuals(Card c){

		GameObject curGO = null;
		if(c.gameObject.CompareTag ("CardTop") == false){
			Debug.Log ("There was an issue with the instantiation."); 
		}

		foreach (Transform ch in c.gameObject.transform) {
			if(ch.CompareTag ("CardButton")){
				foreach (Transform child in ch.transform) {
					if(child.CompareTag ("CardBack")){
						curGO = child.gameObject;
					}
				}
			}
		}
		if(curGO == null){
			Debug.Log ("There was an issue with finding the children."); 
		}
		curGO.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Cards/Backgrounds/" + c.Type.ToString ());

		BuildCardLabels (c, curGO);

	}

	private static void BuildCardLabels(Card c, GameObject curGO){

		ResetLabels (c, curGO);

		GameObject label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (-1f, 2.5f), Quaternion.identity) as GameObject;
		label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Weight");
		((RectTransform)(label.transform)).SetParent (curGO.transform, false);

		label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (-.5f, 2.5f), Quaternion.identity) as GameObject;
		label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + c.Weight);
		((RectTransform)(label.transform)).SetParent (curGO.transform, false);

		label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (.5f, 2.5f), Quaternion.identity) as GameObject;
		label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Coin");
		((RectTransform)(label.transform)).SetParent (curGO.transform, false);

		label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (1f, 2.5f), Quaternion.identity) as GameObject;
		label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + c.Value);
		((RectTransform)(label.transform)).SetParent (curGO.transform, false);

		for(int i = 0; i < 5; i++){
			label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 ((-1 + i * .5f), 1.75f), Quaternion.identity) as GameObject;
			label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Negative");
			((RectTransform)(label.transform)).SetParent (curGO.transform, false);
		}

		if(c.Type == CardType.Junk || c.Type == CardType.Treasure || c.Type == CardType.Weapon){ 
			label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (-1f, 1f), Quaternion.identity) as GameObject;
			label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Attack");
			((RectTransform)(label.transform)).SetParent (curGO.transform, false);

			label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (-.5f, 1f), Quaternion.identity) as GameObject;
			label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + c.Attack);
			((RectTransform)(label.transform)).SetParent (curGO.transform, false);

			if(c.Type == CardType.Weapon){
				label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (.5f, 1f), Quaternion.identity) as GameObject;
				label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Hammer");
				((RectTransform)(label.transform)).SetParent (curGO.transform, false);

				label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (1f, 1f), Quaternion.identity) as GameObject;
				label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + c.Uses);
				((RectTransform)(label.transform)).SetParent (curGO.transform, false);
			}
		}
		if(c.Type == CardType.Utility){
			label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (-1f, 1f), Quaternion.identity) as GameObject;
			label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Weight");
			((RectTransform)(label.transform)).SetParent (curGO.transform, false);

			if(c.capacity > 0){
				label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (-.5f, 1f), Quaternion.identity) as GameObject;
				label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/UpArrow");
				((RectTransform)(label.transform)).SetParent (curGO.transform, false);

				label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (.5f, 1f), Quaternion.identity) as GameObject;
				label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + c.capacity);
				((RectTransform)(label.transform)).SetParent (curGO.transform, false);
			}
			else if(c.capacity < 0){
				label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (-.5f, 1f), Quaternion.identity) as GameObject;
				label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/DownArrow");
				((RectTransform)(label.transform)).SetParent (curGO.transform, false);

				label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (.5f, 1f), Quaternion.identity) as GameObject;
				label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + (-c.capacity));
				((RectTransform)(label.transform)).SetParent (curGO.transform, false);
			}
		}

		if(c.Type == CardType.Spell){
			label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (-1f, 1f), Quaternion.identity) as GameObject;
			label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Exit");
			((RectTransform)(label.transform)).SetParent (curGO.transform, false);

			if(c.teleport > 0){
				label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (-.5f, 1f), Quaternion.identity) as GameObject;
				label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/UpArrow");
				((RectTransform)(label.transform)).SetParent (curGO.transform, false);

				label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (.5f, 1f), Quaternion.identity) as GameObject;
				label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + c.teleport);
				((RectTransform)(label.transform)).SetParent (curGO.transform, false);
			}
			else if(c.teleport < 0){
				label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (-.5f, 1f), Quaternion.identity) as GameObject;
				label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/DownArrow");
				((RectTransform)(label.transform)).SetParent (curGO.transform, false);

				label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (.5f, 1f), Quaternion.identity) as GameObject;
				label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + (-c.teleport));
				((RectTransform)(label.transform)).SetParent (curGO.transform, false);
			}
		}

		BuildCardName (c, curGO);

	}

	public static void BuildCardName(Card c, GameObject curGO){

		string name = c.Name.ToString ();

		int split = 0;
		float colStart = 0;

		GameObject label;

		for(int i = 1; i < name.Length; i++){
			if(Char.IsUpper (name[i])){
				split = i;
				break;
			}
		}

		if(split == 0){
			split = name.Length;
		}

		if(((split - 1) % 2) == 0){
			colStart = -((split - 1) / 4);
		}
		else{
			colStart = -(split / 4) + .25f;
		}


		for(int i = 0; i < split; i++){
			label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (colStart + i * GlobalConstants.cardNameSpacing, GlobalConstants.cardNameRowStart), Quaternion.identity) as GameObject;
			label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Letters/" + Char.ToUpper (name[i]));
			((RectTransform)(label.transform)).SetParent (curGO.transform, false);
		}

		colStart = -((name.Length - split - 1) / 4);

		if(((name.Length - split - 1) % 2) == 0){
			colStart = -((name.Length - split - 1) / 4);
		}
		else{
			colStart = -((name.Length - split) / 4) + .25f;
		}

		for(int i = split; i < name.Length; i++){
			label = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/Label"), new Vector2 (colStart + (i - split) * GlobalConstants.cardNameSpacing, GlobalConstants.cardNameRowStart - GlobalConstants.cardNameSpacing), Quaternion.identity) as GameObject;
			label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Letters/" + Char.ToUpper (name[i]));
			((RectTransform)(label.transform)).SetParent (curGO.transform, false);
		}

	}

	public static void ResetLabels(Card c, GameObject curGo){
		foreach(Transform ch in curGo.transform){
			GameObject.Destroy (ch.gameObject);
		}
	}

	public void DoAction(Card c){

		c.action (GameObject.FindGameObjectWithTag ("WorldController").GetComponent<WorldController> (), this);

	}

	public static void AttackCard(WorldController wc, Card c){
		wc.displayMessage.Display ("You hit the " + wc.e.Name + " for " + c.attack + " damage.", wc.canvas);
		wc.DealDamage (c.attack);
		c.uses--;
		if(c.uses < 1){
			wc.p.H.RemoveCard (c);
		}
		else{
			GameObject curGO = null;
			foreach (Transform ch in c.gameObject.transform) {
				if(ch.CompareTag ("CardButton")){
					foreach (Transform child in ch.transform) {
						if(child.CompareTag ("CardBack")){
							curGO = child.gameObject;
						}
					}
				}
			}
			if(curGO == null){
				Debug.Log ("There was an issue with finding the children."); 
			}
			BuildCardLabels (c, curGO);
		}
		wc.PlayerTurnOver ();
	}

	public void ChangeCapacity(WorldController wc, Card c){
		wc.displayMessage.Display ("Your capactiy changed by " + c.capacity + "!", wc.canvas);
		wc.p.H.TotalCapacity = c.capacity;
		c.uses--;
		if(c.uses < 1){
			wc.p.H.RemoveCard (c);
		}
		CanvasController.UpdateMaxCapacity (wc.p.H.TotalCapacity);
		wc.PlayerTurnOver ();
	}

	public void Transport(WorldController wc, Card c){
		if(c.teleport < 0){
			wc.displayMessage.Display ("You teleported " + (-c.teleport) + " forward!", wc.canvas);
		}
		else{
			wc.displayMessage.Display ("You teleported " + c.teleport + " backward!", wc.canvas);
		}
		wc.Distance = c.teleport;
		c.uses--;
		if(c.uses < 1){
			wc.p.H.RemoveCard (c);
		}
		CanvasController.UpdateDistance (wc.Distance);
		wc.PlayerTurnOver ();
	}

}


