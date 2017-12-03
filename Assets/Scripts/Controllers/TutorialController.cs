using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

	private GameObject disp;
	public DisplayMessage displayMessage;

	private GameObject canvas;

	private bool started = false;

	// Use this for initialization
	void Start () {

		disp = GameObject.Instantiate (Resources.Load ("Prefabs/Controllers/DisplayController"), new Vector2 (), Quaternion.identity) as GameObject;
		displayMessage = disp.GetComponent<DisplayMessage> ();

		canvas = GameObject.FindGameObjectWithTag ("Canvas");

	}
	
	// Update is called once per frame
	void Update () {

		if(!started){
			started = true;
			Begin ();
		}

	}

	private void Begin(){
		displayMessage.Display ("Welcome to Hoarding Havoc!", canvas);
		Invoke ("Intro", GlobalConstants.waitTime);
	}

	public void Intro(){
		displayMessage.Display ("As a hoarder you collect everything", canvas);
		Invoke ("Intro2", GlobalConstants.waitTime);
	}

	public void Intro2(){
		displayMessage.Display ("This tutorial will show you the basics", canvas);
		Invoke ("Weight", GlobalConstants.waitTime);
	}

	public void Weight(){
		displayMessage.Display ("This & is the weight symbol.", canvas);
		Invoke ("WhereW", GlobalConstants.waitTime);
	}

	public void WhereW(){
		displayMessage.Display ("Your current/max & is in the top left", canvas);
		Invoke ("Losing", GlobalConstants.waitTime);
	}

	public void Losing(){
		displayMessage.Display ("You lose if you go over your max &", canvas);
		Invoke ("Coins", GlobalConstants.waitTime);
	}

	public void Coins(){
		displayMessage.Display ("This $ is the loot symbol.", canvas);
		Invoke ("WhereC", GlobalConstants.waitTime);
	}

	public void WhereC(){
		displayMessage.Display ("Your loot is at the top center.", canvas);
		Invoke ("Score", GlobalConstants.waitTime);
	}

	public void Score(){
		displayMessage.Display ("Your loot is your score.", canvas);
		Invoke ("Distance", GlobalConstants.waitTime);
	}

	public void Distance(){
		displayMessage.Display ("This * is the distance symbol.", canvas);
		Invoke ("WhereD", GlobalConstants.waitTime);
	}

	public void WhereD(){
		displayMessage.Display ("The distance left is below your &.", canvas);
		Invoke ("Winning", GlobalConstants.waitTime);
	}

	public void Winning(){
		displayMessage.Display ("You win when * hits 0 and you escape", canvas);
		Invoke ("Health", GlobalConstants.waitTime);
	}

	public void Health(){
		displayMessage.Display ("This @ is the health symbol.", canvas);
		Invoke ("Enemies", GlobalConstants.waitTime);
	}

	public void Enemies(){
		displayMessage.Display ("Only enemies have @.", canvas);
		Invoke ("WhereH", GlobalConstants.waitTime);
	}

	public void WhereH(){
		displayMessage.Display ("It appears in the top right corner.", canvas);
		Invoke ("Cards", GlobalConstants.waitTime);
	}

	public void Cards(){
		displayMessage.Display ("Your cards appear along the bottom.", canvas);
		Invoke ("Attack", GlobalConstants.waitTime);
	}

	public void Attack(){
		displayMessage.Display ("This # symbol is attack.", canvas);
		Invoke ("Damage", GlobalConstants.waitTime);
	}

	public void Damage(){
		displayMessage.Display ("All cards have an # value.", canvas);
		Invoke ("Kills", GlobalConstants.waitTime); 
	}

	public void Kills(){
		displayMessage.Display ("# also logs bested enemies.", canvas);
		Invoke ("Kills2", GlobalConstants.waitTime); 
	}

	public void Kills2(){
		displayMessage.Display ("Bested enemies count is below loot.", canvas);
		Invoke ("Weapon", GlobalConstants.waitTime); 
	}


	public void Weapon(){
		displayMessage.Display ("Weapons are orange and high #", canvas);
		Invoke ("Uses", GlobalConstants.waitTime);
	}

	public void Uses(){
		displayMessage.Display ("This % symbol is uses.", canvas);
		Invoke ("GeneralUse", GlobalConstants.waitTime);
	}

	public void GeneralUse(){
		displayMessage.Display ("Unless listed % is 1", canvas);
		Invoke ("Slings", GlobalConstants.waitTime);
	}

	public void Slings(){
		displayMessage.Display ("Slings are special weapons.", canvas);
		Invoke ("Slings2", GlobalConstants.waitTime);
	}

	public void Slings2(){
		displayMessage.Display ("They will also throw a random junk", canvas);
		Invoke ("Treasure", GlobalConstants.waitTime);
	}

	public void Treasure(){
		displayMessage.Display ("Treasure is gold and high $", canvas);
		Invoke ("Utility", GlobalConstants.waitTime);
	}

	public void Utility(){
		displayMessage.Display ("Can ^ or _ your &", canvas);
		Invoke ("Spell", GlobalConstants.waitTime);
	}

	public void Spell(){
		displayMessage.Display ("Spells are blue and can ^ or _ *", canvas);
		Invoke ("HaveFun", GlobalConstants.waitTime);
	}

	public void HaveFun(){
		displayMessage.Display ("Have Fun!", canvas);
		GameObject.FindGameObjectWithTag ("MenuNavigation").GetComponent<MenuNavigation> ().MainMenu ();
	}


}
