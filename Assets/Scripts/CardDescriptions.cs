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
	public int capacity;
	public int teleport;
	public CardType type;
	public CardName name;
	public CardEffect action;

	public static Coin coin = new Coin ();
	public static CoinStack coinStack = new CoinStack ();
	public static RustySword rustySword = new RustySword ();
	public static SmallRock smallRock = new SmallRock ();
	public static QuickShoe quickShoe = new QuickShoe ();
	public static Rock rock = new Rock ();
	public static Backpack backpack = new Backpack ();
	public static DullAxe dullAxe = new DullAxe ();
	public static Blink blink = new Blink ();
	public static ShinySword shinySword = new ShinySword ();
	public static LavaLamp lavaLamp = new LavaLamp ();

	public class Coin : CardDescriptions{
		public Coin(){
			weight = 2;
			attack = 1;
			value = 3;
			uses = 1;
			capacity = 0;
			teleport = 0;
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
			capacity = 0;
			teleport = 0;
			type = CardType.Treasure;
			name = CardName.CoinStack;
			action = CardEffect.AttackCard;
		}
	}

	public class RustySword : CardDescriptions{
		public RustySword(){
			weight = 3;
			attack = 4;
			value = 1;
			uses = 2;
			capacity = 0;
			teleport = 0;
			type = CardType.Weapon;
			name = CardName.RustySword;
			action = CardEffect.AttackCard;
		}
	}

	public class SmallRock : CardDescriptions{
		public SmallRock(){
			weight = 1;
			attack = 2;
			value = 0;
			uses = 1;
			capacity = 0;
			teleport = 0;
			type = CardType.Junk;
			name = CardName.SmallRock;
			action = CardEffect.AttackCard;
		}
	}

	public class QuickShoe : CardDescriptions{
		public QuickShoe(){
			weight = 2;
			attack = 1;
			value = 1;
			uses = 1;
			capacity = 1;
			teleport = 0;
			type = CardType.Utility;
			name = CardName.QuickShoe;
			action = CardEffect.ChangeCapacity;
		}
	}

	public class Rock : CardDescriptions{
		public Rock(){
			weight = 2;
			attack = 3;
			value = 0;
			uses = 1;
			capacity = 0;
			teleport = 0;
			type = CardType.Junk;
			name = CardName.Rock;
			action = CardEffect.AttackCard;
		}
	}

	public class Backpack : CardDescriptions{
		public Backpack(){
			weight = 1;
			attack = 2;
			value = 3;
			uses = 1;
			capacity = 2;
			teleport = 0;
			type = CardType.Utility;
			name = CardName.Backpack;
			action = CardEffect.ChangeCapacity;
		}
	}

	public class DullAxe : CardDescriptions{
		public DullAxe(){
			weight = 3;
			attack = 2;
			value = 2;
			uses = 3;
			capacity = 0;
			teleport = 0;
			type = CardType.Weapon;
			name = CardName.DullAxe;
			action = CardEffect.AttackCard;
		}
	}

	public class Blink : CardDescriptions{
		public Blink(){
			weight = 1;
			attack = 1;
			value = 2;
			uses = 1;
			capacity = 0;
			teleport = -5;
			type = CardType.Spell;
			name = CardName.Blink;
			action = CardEffect.Transport;
		}
	}

	public class ShinySword : CardDescriptions{
		public ShinySword(){
			weight = 3;
			attack = 5;
			value = 2;
			uses = 3;
			capacity = 0;
			teleport = 0;
			type = CardType.Weapon;
			name = CardName.ShinySword;
			action = CardEffect.AttackCard;
		}
	}

	public class LavaLamp : CardDescriptions{
		public LavaLamp(){
			weight = 5;
			attack = 4;
			value = 9;
			uses = 1;
			capacity = 0;
			teleport = 0;
			type = CardType.Treasure;
			name = CardName.LavaLamp;
			action = CardEffect.AttackCard;
		}
	}

	public static CardDescriptions RandomCard(){
		switch((CardName)UnityEngine.Random.Range(0, GlobalConstants.numCards)){
		case CardName.Coin:
			return CardDescriptions.coin;
		case CardName.CoinStack:
			return CardDescriptions.coinStack;
		case CardName.RustySword:
			return CardDescriptions.rustySword;
		case CardName.SmallRock:
			return CardDescriptions.smallRock;
		case CardName.QuickShoe:
			return CardDescriptions.quickShoe;
		case CardName.Rock:
			return CardDescriptions.rock;
		case CardName.Backpack:
			return CardDescriptions.backpack;
		case CardName.DullAxe:
			return CardDescriptions.dullAxe;
		case CardName.Blink:
			return CardDescriptions.blink;
		case CardName.ShinySword:
			return CardDescriptions.shinySword;
		case CardName.LavaLamp:
			return CardDescriptions.lavaLamp;
		default:
			return null;
		}
	}

}
