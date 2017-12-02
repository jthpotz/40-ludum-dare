using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand {

	private List<Card> allCards = new List<Card> (0);

	public Hand(){
		
	}

	public void AddCard(Card c){
		allCards.Add (c);
	}

	public void RemoveCard(Card c){
		allCards.Remove (c);
		UpdateOrder ();
	}

	public int ClearHand(){
		int sum = 0;

		foreach(Card c in allCards){
			sum += c.Value;
		}

		allCards.Clear ();

		return sum;

	}

	public void UpdateOrder(){
		for(int i = 0; i < allCards.Count; i++){
			allCards [i].GO.transform.SetSiblingIndex (i);
		}
	}

}
