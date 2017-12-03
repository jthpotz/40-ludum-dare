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
		case EventName.Energize:
			Events.Energize (wc);
			return;
		case EventName.SuperStrength:
			Events.SuperStrength (wc);
			return;
		case EventName.Weaken:
			Events.Weaken (wc);
			return;
		case EventName.ParalysingWeakness:
			Events.ParalyzingWeakness (wc);
			return;
		case EventName.Speed:
			Events.Speed (wc);
			return;
		case EventName.Flash:
			Events.Flash (wc);
			return;
		case EventName.Lost:
			Events.Lost (wc);
			return;
		case EventName.Bewildered:
			Events.Bewildered (wc);
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

	private static void Energize(WorldController wc){
		wc.p.H.TotalCapacity = 2;
		CanvasController.UpdateMaxCapacity (wc.p.H.TotalCapacity);
		wc.displayMessage.Display ("You feel stronger!", wc.canvas);
	}

	private static void SuperStrength(WorldController wc){
		wc.p.H.TotalCapacity = 4;
		CanvasController.UpdateMaxCapacity (wc.p.H.TotalCapacity);
		wc.displayMessage.Display ("You suddenly gain super strength!", wc.canvas);
	}

	private static void Weaken(WorldController wc){
		wc.p.H.TotalCapacity = 2;
		CanvasController.UpdateMaxCapacity (wc.p.H.TotalCapacity);
		wc.displayMessage.Display ("You feel weaker!", wc.canvas);
	}

	private static void ParalyzingWeakness(WorldController wc){
		wc.p.H.TotalCapacity = 4;
		CanvasController.UpdateMaxCapacity (wc.p.H.TotalCapacity);
		wc.displayMessage.Display ("You suddenly feel super weak!", wc.canvas);
	}

	private static void Speed(WorldController wc){
		wc.Distance = -5;
		if(wc.Distance <= 0){
			GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ().score = wc.p.H.ClearHand ();
			GameObject.FindGameObjectWithTag ("MenuNavigation").GetComponent<MenuNavigation> ().ToVictory ();
		}
		wc.displayMessage.Display ("You dash forward!", wc.canvas);
	}

	private static void Flash(WorldController wc){
		wc.Distance = -10;
		if(wc.Distance <= 0){
			GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ().score = wc.p.H.ClearHand ();
			GameObject.FindGameObjectWithTag ("MenuNavigation").GetComponent<MenuNavigation> ().ToVictory ();
		}
		wc.displayMessage.Display ("You suddenly sprint far forward!", wc.canvas);
	}

	private static void Lost(WorldController wc){
		wc.Distance = -5;
		wc.displayMessage.Display ("You get slightly turned around!", wc.canvas);
	}

	private static void Bewildered(WorldController wc){
		wc.Distance = -10;
		wc.displayMessage.Display ("You realize you are lost!", wc.canvas);
	}

}
