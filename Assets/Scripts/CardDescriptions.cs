using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CardName = GlobalConstants.CardName;
using CardType = GlobalConstants.CardType;

public class CardDescriptions {

	public static readonly Card coins = new Card(2, 1, 3, 1, CardType.Treasure, CardName.Coins);
	public static readonly Card coinStack = new Card (4, 2, 6, 1, CardType.Treasure, CardName.CoinStack);

	public static readonly Card rustySword = new Card (4, 4, 1, 1, CardType.Weapon, CardName.RustySword);

}
