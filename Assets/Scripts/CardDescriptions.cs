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

	public static Coins coins = new Coins ();
	public static CoinStack coinStack = new CoinStack ();
	public static RustySword rustySword = new RustySword ();
	public static SmallRocks smallRocks = new SmallRocks ();

	public class Coins : CardDescriptions{
		public Coins(){
			weight = 2;
			attack = 1;
			value = 3;
			uses = 1;
			type = CardType.Treasure;
			name = CardName.Coins;
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
			uses = 1;
			type = CardType.Weapon;
			name = CardName.RustySword;
			action = CardEffect.AttackCard;
		}
	}

	public class SmallRocks : CardDescriptions{
		public SmallRocks(){
			weight = 2;
			attack = 1;
			value = 0;
			uses = 1;
			type = CardType.Junk;
			name = CardName.SmallRocks;
			action = CardEffect.AttackCard;
		}
	}

}
