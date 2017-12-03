using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EnemyName = GlobalConstants.EnemyName;
using EnemyAttack = GlobalConstants.EnemyAttack;
using LootChance = GlobalConstants.LootChance;

public class EnemyDescriptions {

	public int health;
	public EnemyName name;
	public EnemyAttack attack;
	public LootChance loot;

	public static readonly Goblin goblin = new Goblin ();
	public static readonly Troll troll = new Troll ();
	public static readonly Rat rat = new Rat ();
	public static readonly Minotaur minotaur = new Minotaur ();
	public static readonly Wolf wolf = new Wolf ();

	public class Goblin : EnemyDescriptions {
		public Goblin (){
			health = 5;
			name = EnemyName.Goblin;
			attack = EnemyAttack.ThrowSmall;
			loot = LootChance.Goblin;
		}
	}

	public class Troll : EnemyDescriptions {
		public Troll (){
			health = 9;
			name = EnemyName.Troll;
			attack = EnemyAttack.Throw;
			loot = LootChance.Troll;
		}
	}

	public class Rat : EnemyDescriptions {
		public Rat (){
			health = 5;
			name = EnemyName.Rat;
			attack = EnemyAttack.HitSmall;
			loot = LootChance.Rat;
		}
	}

	public class Minotaur : EnemyDescriptions {
		public Minotaur (){
			health = 6;
			name = EnemyName.Minotaur;
			attack = EnemyAttack.Hit;
			loot = LootChance.Minotaur;
		}
	}

	public class Wolf : EnemyDescriptions {
		public Wolf (){
			health = 4;
			name = EnemyName.Wolf;
			attack = EnemyAttack.Drag;
			loot = LootChance.Wolf;
		}
	}

}
