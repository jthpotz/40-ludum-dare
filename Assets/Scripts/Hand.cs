using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sizings = GlobalConstants.Sizings;

public class Hand {

	private List<Card> allCards = new List<Card> (0);

	private int totalCapacity = GlobalConstants.startMaxCapcacity;
	private int currentCapacity = 0;


	public int TotalCapacity{
		get { return totalCapacity; }
	}
	public int CurrentCapacity{
		get { return currentCapacity; }
	}


	public Hand(){
		
	}

	public void AddCard(Card c){
		allCards.Add (c);
		SetCardPosition (c, allCards.IndexOf (c));
	}

	public void RemoveCard(Card c){
		GameObject.Destroy (c.GO);
		allCards.Remove (c);
	}

	public void UpdateHand(){
		UpdateOrder ();
		UpdateCurrentCapacity ();
		CanvasController.UpdateCapacity (currentCapacity);
		CanvasController.UpdateMoney (FindTotalValue ());
	}

	public int ClearHand(){
		int sum = 0;

		foreach(Card c in allCards){
			sum += c.Value;
			GameObject.Destroy (c.GO);
		}

		allCards.Clear ();

		return sum;

	}

	public void UpdateOrder(){
		for(int i = 0; i < allCards.Count; i++){
			allCards [i].gameObject.transform.SetSiblingIndex (allCards.Count - 1 - i);
			SetCardPosition (allCards[i], i);
		}
	}



	public void UpdateCurrentCapacity (){
		int sum = 0;

		foreach(Card c in allCards){
			sum += c.Weight;
		}

		currentCapacity = sum;
	}

	public int FindTotalValue(){
		int sum = 0;

		foreach(Card c in allCards){
			sum += c.Value;
		}

		return sum;

	}

	public void SetCardPosition(Card c, int pos){
		Vector3 v = ((RectTransform)(c.gameObject.transform)).anchoredPosition;
		v.x = (int)Sizings.CardStartX + ((pos % (int)Sizings.CardsInRow) * (int)Sizings.CardOffsetX);
		v.y = (int)Sizings.CardStartY + ((int)(pos / (int)Sizings.CardsInRow) * (int)Sizings.CardOffsetY);
		((RectTransform)(c.gameObject.transform)).anchoredPosition = v;
	}

}
