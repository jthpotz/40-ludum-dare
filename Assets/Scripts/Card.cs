using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using Effect = GlobalConstants.Effect;
using CardEffects = GlobalConstants.CardEffects;
using CardName = GlobalConstants.CardName;
using CardType = GlobalConstants.CardType;

public class Card {



	private int weight = 0;
	private int attack = 0;
	private int value = 0;
	private int uses = 0;
	private Effect action = null; 
	private CardEffects actionEnum = CardEffects.None;
	private CardType type;
	private CardName name;

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
	public Effect Action{
		get { return action; }
	}
	public CardEffects ActionEnum{
		get { return actionEnum; }
	}
	public CardType Type{
		get { return type; }
	}
	public CardName Name{
		get { return name; }
	}

	public GameObject GO{
		get { return go; }
		set { go = value; }
	}

	public Card(int w, int a, int v, int u, CardType t, CardName n, CardEffects e = CardEffects.None){
		weight = w;
		attack = a;
		value = v;
		uses = u;
		type = t;
		name = n;

		actionEnum = e;
		switch(e){
		case CardEffects.IncreaseCapacity:
			action = IncreaseCapacity;
			break;
		case CardEffects.DecreaseCapacity:
			action = DecreaseCapacity;
			break;
		default:
			break;
		}
		
	}

	public void IncreaseCapacity(Player p){
		
	}

	public void DecreaseCapacity(Player p){
		
	}

	public static Card CreateCard (Card c, GameObject canvas){
		Card newCard = new Card (c.Weight, c.Attack, c.Value, c.Uses, c.Type, c.Name, c.ActionEnum);
		newCard.GO = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/GenericCard"), new Vector3 (), Quaternion.identity) as GameObject;

		BuildCardVisuals (newCard);

		newCard.GO.transform.SetParent (canvas.transform, false);
		return newCard;
	}

	private static void BuildCardVisuals(Card c){
		GameObject curGO = null;
		if(c.GO.CompareTag ("CardTop") == false){
			Debug.Log ("There was an issue with the instantiation."); 
		}

		foreach (Transform ch in c.GO.transform) {
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

}
