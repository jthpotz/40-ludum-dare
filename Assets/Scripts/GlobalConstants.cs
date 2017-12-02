using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalConstants {

	public delegate void Effect(Player p);

	public enum CardEffects{
		IncreaseCapacity,
		DecreaseCapacity,
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
		Coins,
		CoinStack,
		RustySword
	}

	public enum CardType{
		Treasure,
		Weapon,
		Utility,
		Consumable
	}

	public static readonly int cardNameLetters = 7;
	public static readonly float cardNameSpacing = .5f;
	public static readonly float cardNameRowStart = 0;

	public static readonly int startMaxCapcacity;

	public static readonly Vector3 cardScale = new Vector3(37.5f, 37.5f);

}
