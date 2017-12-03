using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Sizings = GlobalConstants.Sizings;
using CardType = GlobalConstants.CardType;

public class Hand {

	private List<Card> allCards = new List<Card> (0);

	private int totalCapacity = GlobalConstants.startMaxCapcacity;
	public int currentCapacity = 0;

	public bool enabled = true;

	public int TotalCapacity{
		get { return totalCapacity; }
		set { totalCapacity += value; }
	}
	public int CurrentCapacity{
		get { return currentCapacity; }
	}


	public Hand(){
		
	}

	public void AddCard(Card c){
		if(allCards.Count == 1 && allCards[0].Type == CardType.Struggle){
			RemoveCard (allCards[0]);
		}
		allCards.Add (c);
		SetCardPosition (c, allCards.IndexOf (c));
	}

	public void RemoveCard(Card c){
		if(c.Type != CardType.Struggle && allCards.Count == 1){
			allCards.Add (Card.CreateCard (CardDescriptions.punch));
		}
		GameObject.Destroy (c.GO);
		allCards.Remove (c);
	}

	public Card FindCard(CardType type){
		List<Card> temp = new List<Card> (0);
		foreach(Card c in allCards){
			if(c.Type == type){
				temp.Add (c);
			}
		}
		if(temp.Count == 0){
			return null;
		}
		return temp[Random.Range (0, temp.Count)];
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

	public void DisableCards (){
		enabled = false;
		foreach (Card c in allCards){
			c.GetComponentInChildren<Button> ().enabled = false;
		}
	}

	public void EnableCards (){
		enabled = true;
		foreach (Card c in allCards){
			c.GetComponentInChildren<Button> ().enabled = true;
		}
	}

}
