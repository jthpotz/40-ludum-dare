using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalConstants {

	public delegate void Effect(WorldController wc, Card c);

	public enum CardEffect{
		ChangeCapacity,
		AttackCard,
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
		QuickShoe
	}

	public enum EventName{
		FindLoot
	}

	public enum EventChance{
		FindLoot = 25
	}

	public static readonly int numCards = 4;

	public enum CardType{
		Treasure,
		Weapon,
		Utility,
		Consumable,
		Junk
	}

	public enum EnemyName{
		Goblin
	}

	public enum EnemyAttack{
		Hit
	}

	public enum SpawnChance{
		Goblin = 12
	}

	public enum LootChance{
		Goblin = 10
	}

	public static readonly int cardNameLetters = 7;
	public static readonly float cardNameSpacing = .5f;
	public static readonly float cardNameRowStart = 0;

	public static readonly int startMaxCapcacity = 20;

	public static readonly Vector3 cardScale = new Vector3(37.5f, 37.5f);

	public static readonly float waitTime = .5f;

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

	public static readonly float messageDisplayTime = 5;


	public static readonly int minDistance = 50;
	public static readonly int maxDistance = 150;

	public static readonly int baseTimePerMovem = 5;

	public static readonly int eventDelayTime = 1;

	public static readonly int enemyChance = 20;
	public static readonly int eventChance = 20;
}
