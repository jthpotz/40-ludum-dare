using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DisplayMessage : MonoBehaviour {

	//@ = heart, & = weight, $ = coin, ^ = up arrow, _ = down arrow, < = left arrow, > = right arrow, - = negative, / = slash, % = hammer, ! = !, . = ., ? = ?, # = attack, * = distance

	public bool curDisplay;

	private GameObject msgHere;

	void Start(){
		
	}

	void Update(){
		
	}

	private IEnumerator DirtyHack(string msg, GameObject canvas, bool manClear, float delay){
		yield return new WaitForSeconds (delay);
		Display (msg, canvas, manClear);
	}

	public void Display(string msg, GameObject canvas, bool manClear = false){


		if(curDisplay){
			StartCoroutine (DirtyHack (msg, canvas, manClear, .1f));
			return;
		}

		curDisplay = true;

		msgHere = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/Msg"), new Vector2 (), Quaternion.identity) as GameObject;
		msgHere.transform.SetParent (canvas.transform, false);

		if(msg.Length > 2 * GlobalConstants.msgLettersPerRow){
			Debug.Log ("Msg too long.");
			return;
		}

		int split = Split (msg);

		if(msg.Length - split > GlobalConstants.msgLettersPerRow){
			Debug.Log ("Msg split poorly.");
			return;
		}

		MakeRow (msg, split, 0);
		MakeRow (msg, split, 1);

		if(!manClear){
			Invoke ("ClearMessage", GlobalConstants.messageDisplayTime);
		}
	}

	public void ClearMessage(){
		GameObject.Destroy (msgHere);
		curDisplay = false;
	}

	private int Split(string msg){
		int currentBreak = 0;
		for(int i = 0; i < msg.Length; i++){
			if(msg[i] == ' ' && i < GlobalConstants.msgLettersPerRow){
				currentBreak = i + 1;
			}
			if(i == GlobalConstants.msgLettersPerRow && currentBreak == 0){
				return i - 1;
			}
		}
		if(currentBreak == 0){
			currentBreak = msg.Length;
		}
		else if(msg[currentBreak - 1] == ' '){
			msg.Remove (currentBreak - 1, 1);
			currentBreak--;
		}

		return currentBreak;
	}

	public void MakeRow(string msg, int split, int row){

		GameObject label;

		int colStart = 0;

		if(row == 0){
			if(((split - 1) % 2) == 0){
				colStart = 2 * GlobalConstants.msgStartCol  + (((split - 1)) / 2) * GlobalConstants.msgOffset;
			}
			else{
				colStart = 2 * GlobalConstants.msgStartCol  + ((split)  / 2) *  GlobalConstants.msgOffset - 25;
			}
		}
		else{
			if(((msg.Length - split - 1) % 2) == 0){
				colStart = 2 * GlobalConstants.msgStartCol  + (((msg.Length - split - 1)) / 2) * GlobalConstants.msgOffset;
			}
			else{
				colStart = 2 * GlobalConstants.msgStartCol  + ((msg.Length - split)  / 2) * GlobalConstants.msgOffset - 25;
			}
		}

		for(int i = row * split; CheckDone(msg, split, row, i); i++){
			if (msg [i] == ' ') {
				continue;
			}
			//+ row*(-split + msg.Length - split)
			//(GlobalConstants.msgOffset * (GlobalConstants.msgLettersPerRow - (split )) + 
			label = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/Label"), new Vector2 (colStart + (GlobalConstants.msgOffset * (GlobalConstants.msgLettersPerRow - (split + row*(-split + msg.Length - split))) +  (i - split * row) * GlobalConstants.msgOffset), GlobalConstants.msgStartRow - (row * GlobalConstants.msgOffset)), Quaternion.identity) as GameObject;

		
			if (msg[i] == '1' || msg[i] == '2' || msg[i] == '3' || msg[i] == '4' || msg[i] == '5' || msg[i] == '6' || msg[i] == '7' || msg[i] == '8' || msg[i] == '9' || msg[i] == '0'){
				label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Numbers/" + msg[i]);	
			}else if(!(msg[i] == '@' || msg[i] == '&' || msg[i] == '$' || msg[i] == '^' || msg[i] == '_' || msg[i] == '<' || msg[i] == '>' || msg[i] == '/' || msg[i] == '-' || msg[i] == '%' || msg[i] == '!' || msg[i] == '?' || msg[i] == '.' || msg[i] == '#' || msg[i] == '*')){
				label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Letters/" + Char.ToUpper (msg[i]));	
			}
			else{
				switch(msg[i]){
				case '@':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Health");	
					break;
				case '&':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Weight");	
					break;
				case '$':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Coin");	
					break;
				case '^':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/UpArrow");	
					break;
				case '_':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/DownArrow");	
					break;
				case '<':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/LeftArrow");	
					break;
				case '>':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/RightArrow");	
					break;
				case '/':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Slash");	
					break;
				case '-':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Negative");	
					break;
				case '%':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Hammer");	
					break;
				case '!':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/ExclamationPoint");	
					break;
				case '?':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/QuestionMark");	
					break;
				case '.':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Period");	
					break;
				case '#':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Attack");	
					break;
				case '*':
					label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Symbols/Exit");	
					break;
				default:
					break;
				}
			}

			((RectTransform)(label.transform)).SetParent (msgHere.transform, false);
		}

	}

	private bool CheckDone(string msg, int split, int row, int i){
		if(row == 0){
			if (i < split){
				return true;
			}
			return false;
		}
		else{
			if(i < msg.Length){
				return true;
			}
			return false;
		}
	}

}
