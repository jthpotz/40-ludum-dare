using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CardType = GlobalConstants.CardType;

public class CardDescriptions {

	public static readonly Card coins = new Card(2, 1, 3, CardType.Coins);
	public static readonly Card coinStack = new Card (4, 2, 6, CardType.CoinStack);

}
