using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EnemyName = GlobalConstants.EnemyName;
using EnemyAttack = GlobalConstants.EnemyAttack;
using Effect = GlobalConstants.Effect;

public class Enemy {

	public int health;
	public EnemyName name;
	public EnemyAttack attack;
	public Effect action;

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
	}

	public void DealDamage (int dmg){
		health -= dmg;
	}

	public bool Dead (){
		return !(health > 0);
	}

	public void Throw(WorldController wc, Card c){
		wc.p.H.AddCard (Card.CreateCard (CardDescriptions.smallRocks));
		wc.p.H.AddCard (Card.CreateCard (CardDescriptions.smallRocks));
	}

}
