using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalConstants {

	public delegate void Effect(WorldController wc, Card c);

	public enum CardEffect{
		ChangeCapacity,
		AttackCard,
		Transport,
		None
	}

	public enum Sizings{
		CardOffsetX = 150,
		CardOffsetY = 100,
		CardStartX = -460,
		CardStartY = -325,
		CardsInRow = 7
	}

	public enum CardName{
		Coin,
		CoinStack,
		RustySword,
		SmallRock,
		QuickShoe,
		Rock,
		Backpack,
		DullAxe,
		Blink
	}

	public static readonly int numCards = 9;

	public enum EventName{
		FindLoot,
		Energize,
		SuperStrength,
		Weaken,
		ParalysingWeakness,
		Speed,
		Flash,
		Lost,
		Bewildered
	}

	public enum EventChance{
		FindLoot = 55,
		Energize = 20,
		SuperStrength = 5,
		Weaken = 10,
		ParalysingWeakness = 1,
		Speed = 20,
		Flash = 5,
		Lost = 10,
		Bewildered = 1
	}

	public enum CardType{
		Treasure,
		Weapon,
		Utility,
		Spell,
		Junk
	}

	public enum EnemyName{
		Goblin,
		Troll,
		Rat,
		Minotaur
	}

	public enum EnemyAttack{
		ThrowSmall,
		Throw,
		HitSmall,
		Hit
	}

	public enum SpawnChance{
		Goblin = 25,
		Troll = 10,
		Rat = 15,
		Minotaur = 5
	}

	public enum LootChance{
		Goblin = 30,
		Troll = 40,
		Rat = 50,
		Minotaur = 40
	}

	public static readonly int cardNameLetters = 7;
	public static readonly float cardNameSpacing = .5f;
	public static readonly float cardNameRowStart = 0;

	public static readonly int startMaxCapcacity = 20;

	public static readonly Vector3 cardScale = new Vector3(37.5f, 37.5f);

	public static readonly float waitTime = 3f;

	public static readonly int lettersPerRow = 20;
	public static readonly int maxRows = 3;
	public static readonly int msgStartingHeight;

	public static readonly int enemyNameStartCol = 150;
	public static readonly int enemyNameStartRow = 210;
	public static readonly int enemyNameOffset = 50;
	public static readonly int enemyLettersPerRow = (550 - GlobalConstants.enemyNameStartCol) / GlobalConstants.enemyNameOffset;

	public static readonly int msgStartCol = -500;
	public static readonly int msgStartRow = 100;
	public static readonly int msgOffset = 50;
	public static readonly int msgLettersPerRow = (550 - GlobalConstants.msgStartCol) / GlobalConstants.msgOffset;

	public static readonly float messageDisplayTime = waitTime;


	public static readonly int minDistance = 50;
	public static readonly int maxDistance = 100;

	public static readonly int baseTimePerMovem = 5;

	public static readonly int eventDelayTime = 1;

	public static readonly int enemyChance = 20;
	public static readonly int eventChance = 20;
}
