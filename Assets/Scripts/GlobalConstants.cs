using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalConstants {

	public delegate void Effect(Player p);

	public enum CardEffects{
		IncreaseCapacity,
		DecreaseCapacity
	}

	public static int startMaxCapcacity;

}
