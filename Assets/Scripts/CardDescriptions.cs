using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CardName = GlobalConstants.CardName;
using CardType = GlobalConstants.CardType;
using CardEffect = GlobalConstants.CardEffect;
using CardDrop = GlobalConstants.CardDrop;

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

	public static readonly Coin coin = new Coin ();
	public static readonly CoinStack coinStack = new CoinStack ();
	public static readonly RustySword rustySword = new RustySword ();
	public static readonly SmallRock smallRock = new SmallRock ();
	public static readonly SmallBag smallBag = new SmallBag ();
	public static readonly Rock rock = new Rock ();
	public static readonly Backpack backpack = new Backpack ();
	public static readonly DullAxe dullAxe = new DullAxe ();
	public static readonly Blink blink = new Blink ();
	public static readonly ShinySword shinySword = new ShinySword ();
	public static readonly LavaLamp lavaLamp = new LavaLamp ();
	public static readonly SmallSling smallSling = new SmallSling ();
	public static readonly HeavySling heavySling = new HeavySling ();
	public static readonly Punch punch = new Punch ();

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

	public class SmallBag : CardDescriptions{
		public SmallBag(){
			weight = 2;
			attack = 1;
			value = 1;
			uses = 1;
			capacity = 1;
			teleport = 0;
			type = CardType.Utility;
			name = CardName.SmallBag;
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

	public class SmallSling : CardDescriptions{
		public SmallSling(){
			weight = 3;
			attack = 1;
			value = 2;
			uses = 5;
			capacity = 0;
			teleport = 0;
			type = CardType.Weapon;
			name = CardName.SmallSling;
			action = CardEffect.AttackCard;
		}
	}

	public class HeavySling : CardDescriptions{
		public HeavySling(){
			weight = 4;
			attack = 3;
			value = 4;
			uses = 3;
			capacity = 0;
			teleport = 0;
			type = CardType.Weapon;
			name = CardName.HeavySling;
			action = CardEffect.AttackCard;
		}
	}

	public class Punch : CardDescriptions{
		public Punch(){
			weight = 1;
			attack = 2;
			value = 0;
			uses = 1;
			capacity = -attack;
			teleport = 0;
			type = CardType.Struggle;
			name = CardName.Punch;
			action = CardEffect.Struggle;
		}
	}

	public static CardDescriptions RandomCard(){

		CardDescriptions cd = null;

		while(true){
			if(Random.Range (0, 100) < (int)CardDrop.Weapon){
				while(true){
					cd = CardDescriptions.GetDescription((CardName)UnityEngine.Random.Range (0, GlobalConstants.numCards));
					if(cd.type == CardType.Weapon){
						return cd;
					}
				}
			}
			if(Random.Range (0, 100) < (int)CardDrop.Utility){
				while(true){
					cd = CardDescriptions.GetDescription((CardName)UnityEngine.Random.Range (0, GlobalConstants.numCards));
					if(cd.type == CardType.Utility){
						return cd;
					}
				}
			}
			if(Random.Range (0, 100) < (int)CardDrop.Spell){
				while(true){
					cd = CardDescriptions.GetDescription((CardName)UnityEngine.Random.Range (0, GlobalConstants.numCards));
					if(cd.type == CardType.Spell){
						return cd;
					}
				}
			}
			if(Random.Range (0, 100) < (int)CardDrop.Treasure){
				while(true){
					cd = CardDescriptions.GetDescription((CardName)UnityEngine.Random.Range (0, GlobalConstants.numCards));
					if(cd.type == CardType.Treasure){
						return cd;
					}
				}
			}
			if(Random.Range (0, 100) < (int)CardDrop.Junk){
				while(true){
					cd = CardDescriptions.GetDescription((CardName)UnityEngine.Random.Range (0, GlobalConstants.numCards));
					if(cd.type == CardType.Junk){
						return cd;
					}
				}
			}
		}

	}

	private static CardDescriptions GetDescription(CardName cName){
		switch((CardName)UnityEngine.Random.Range(0, GlobalConstants.numCards)){
		case CardName.Coin:
			return CardDescriptions.coin;
		case CardName.CoinStack:
			return CardDescriptions.coinStack;
		case CardName.RustySword:
			return CardDescriptions.rustySword;
		case CardName.SmallRock:
			return CardDescriptions.smallRock;
		case CardName.SmallBag:
			return CardDescriptions.smallBag;
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
		case CardName.SmallSling:
			return CardDescriptions.smallSling;
		case CardName.HeavySling:
			return CardDescriptions.heavySling;
		case CardName.Punch:
			return CardDescriptions.punch;
		default:
			return null;
		}
	}

}
