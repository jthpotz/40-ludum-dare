﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EnemyName = GlobalConstants.EnemyName;
using EnemyAttack = GlobalConstants.EnemyAttack;
using Effect = GlobalConstants.Effect;
using LootChance = GlobalConstants.LootChance;

public class Enemy {

	public int health;
	public EnemyName name;
	public EnemyAttack attack;
	public Effect action;
	public LootChance loot;

	public int Health{
		get { return health; }
	}
	public EnemyName Name{
		get { return name; }
	}

	public Enemy(EnemyDescriptions ed){
		health = ed.health;
		name = ed.name;
		attack = ed.attack;
		switch(attack){
		case EnemyAttack.Hit:
			action = Throw;
			break;
		}
		loot = ed.loot;
	}

	public void DealDamage (int dmg){
		health -= dmg;
	}

	public bool Dead (){
		return !(health > 0);
	}

	public void OnDeath(WorldController wc){
		if(Random.Range (0, 100) < (int)loot){
			CardDescriptions temp = CardDescriptions.RandomCard ();
			wc.p.H.AddCard (Card.CreateCard (temp));
			wc.p.H.DisableCards ();
			wc.displayMessage.Display ("The " + this.Name + " dropped a " + temp.name + "!", wc.canvas);
		}
		else{
			wc.displayMessage.Display ("The " + this.name + " dropped nothing...", wc.canvas);
		}
	}

	public void Throw(WorldController wc, Card c){
		int rocks = Random.Range (1, 3);
		for(int i = 0; i < rocks; i++){
			wc.p.H.AddCard (Card.CreateCard (CardDescriptions.smallRock));
		}
		wc.displayMessage.Display ("The " + wc.e.Name + " threw " + rocks + " rocks at you.", wc.canvas);
		wc.p.H.DisableCards ();
	}

}
