using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Effect = GlobalConstants.Effect;
using CardEffects = GlobalConstants.CardEffects;
using CardType = GlobalConstants.CardType;

public class Card {



	private int weight = 0;
	private int attack = 0;
	private int value = 0;
	private Effect action = null; 
	private CardEffects actionEnum = CardEffects.None;
	private CardType name;

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
	public Effect Action{
		get { return action; }
	}
	public CardEffects ActionEnum{
		get { return actionEnum; }
	}
	public CardType Name{
		get { return name; }
	}

	public GameObject GO{
		get { return go; }
		set { go = value; }
	}

	public Card(int w, int a, int v, CardType n, CardEffects e = CardEffects.None){
		weight = w;
		attack = a;
		value = v;
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
		Card newCard = new Card (c.Weight, c.Attack, c.Value, c.Name, c.ActionEnum);
		newCard.GO = GameObject.Instantiate (Resources.Load ("Prefabs/Cards/" + c.Name.ToString () + "/" + c.Name.ToString ()), new Vector3 (), Quaternion.identity) as GameObject;
		newCard.GO.transform.SetParent (canvas.transform, false);
		return newCard;
	}

}
