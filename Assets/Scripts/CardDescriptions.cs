using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CardName = GlobalConstants.CardName;
using CardType = GlobalConstants.CardType;
using CardEffect = GlobalConstants.CardEffect;

public class CardDescriptions {

	public int weight;
	public int attack;
	public int value;
	public int uses;
	public CardType type;
	public CardName name;
	public CardEffect action;

	public static Coin coin = new Coin ();
	public static CoinStack coinStack = new CoinStack ();
	public static RustySword rustySword = new RustySword ();
	public static SmallRock smallRock = new SmallRock ();

	public class Coin : CardDescriptions{
		public Coin(){
			weight = 1;
			attack = 1;
			value = 3;
			uses = 1;
			type = CardType.Treasure;
			name = CardName.Coin;
			action = CardEffect.AttackCard;
		}
	}

	public class CoinStack : CardDescriptions{
		public CoinStack(){
			weight = 4;
			attack = 2;
			value = 6;
			uses = 1;
			type = CardType.Treasure;
			name = CardName.CoinStack;
			action = CardEffect.AttackCard;
		}
	}

	public class RustySword : CardDescriptions{
		public RustySword(){
			weight = 4;
			attack = 4;
			value = 1;
			uses = 2;
			type = CardType.Weapon;
			name = CardName.RustySword;
			action = CardEffect.AttackCard;
		}
	}

	public class SmallRock : CardDescriptions{
		public SmallRock(){
			weight = 2;
			attack = 1;
			value = 0;
			uses = 1;
			type = CardType.Junk;
			name = CardName.SmallRock;
			action = CardEffect.AttackCard;
		}
	}

}
