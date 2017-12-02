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
		CardStartY = -235,
		CardsInRow = 7
	}

	public enum CardType{
		Coins
	}

	public static int startMaxCapcacity;

	public static Vector3 cardScale = new Vector3(37.5f, 37.5f);

}
