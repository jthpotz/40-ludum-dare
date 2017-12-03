using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EventName = GlobalConstants.EventName;

public class Events {

	public static void DoEvent(EventName ev, WorldController wc){
		switch(ev){
		case EventName.FindLoot:
			Events.FindLoot (wc);
			return;
		default:
			return;
		}
	}


	private static void FindLoot(WorldController wc){
		CardDescriptions temp = CardDescriptions.RandomCard ();
		wc.p.H.AddCard (Card.CreateCard (temp));
		wc.displayMessage.Display ("You found a " + temp.name + "!", wc.canvas);
	}

}
