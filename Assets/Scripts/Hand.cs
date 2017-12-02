using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sizings = GlobalConstants.Sizings;

public class Hand {

	private List<Card> allCards = new List<Card> (0);

	public Hand(){
		
	}

	public void AddCard(Card c){
		allCards.Add (c);
		SetCardPosition (c, allCards.IndexOf (c));
		UpdateOrder ();
		Debug.Log (c.GO.transform.position);
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

	public void SetCardPosition(Card c, int pos){
		Debug.Log (c);
		Vector3 v = ((RectTransform)(c.GO.transform)).anchoredPosition;
		v.x = (int)Sizings.CardStartX + (pos * (int)Sizings.CardOffsetX);
		v.y = (int)Sizings.CardStartY + ((int)(pos / (int)Sizings.CardsInRow) * (int)Sizings.CardOffsetY);
		((RectTransform)(c.GO.transform)).anchoredPosition = v;
		Debug.Log (v);
	}

}
