using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Effect = GlobalConstants.Effect;
using CardEffects = GlobalConstants.CardEffects;


public class Card {



	private int weight = 0;
	private int attack = 0;
	private int value = 0;
	private Effect action = null; 

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
	public GlobalConstants.Effect Action{
		get { return action; }
	}

	public GameObject GO{
		get { return go; }
	}

	public Card(int w, int a, int v, CardEffects e){
		weight = w;
		attack = a;
		value = v;

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

}
