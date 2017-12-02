using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EnemyName = GlobalConstants.EnemyName;
using EnemyAttack = GlobalConstants.EnemyAttack;

public class EnemyDescriptions {

	public int health;
	public EnemyName name;
	public EnemyAttack attack;

	public static readonly Goblin goblin = new Goblin ();

	public class Goblin : EnemyDescriptions {
		public Goblin (){
			health = 5;
			name = EnemyName.Goblin;
			attack = EnemyAttack.Hit;
		}
	}

}
