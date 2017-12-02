using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DisplayMessage : MonoBehaviour {

	//@ = heart, & = weight, $ = coin, + = up arrow, _ = down arrow, ( = left arrow, ) = right arrow

	public bool curDisplay;

	private GameObject msgHere;

	private WorldController wc;

	void Start(){
		
	}

	void Update(){
		
	}

	public void Init(WorldController wc){
		this.wc = wc;
	}

	public void Display(string msg, Canvas canvas, bool manClear = false){

		curDisplay = true;

		GameObject label;

		if(msg.Length > 2 * GlobalConstants.msgLettersPerRow){
			Debug.Log ("Msg too long.");
			return;
		}

		int split = Split (msg);

		for(int i = 0; i < split; i++){
			label = GameObject.Instantiate (Resources.Load ("Prefabs/StatusBars/Label"), new Vector2 (GlobalConstants.enemyNameStartCol + (GlobalConstants.enemyNameOffset * (GlobalConstants.enemyLettersPerRow - split)) + i * GlobalConstants.enemyNameOffset, GlobalConstants.enemyNameStartRow), Quaternion.identity) as GameObject;
			label.transform.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Letters/" + Char.ToUpper (msg[i]));
			((RectTransform)(label.transform)).SetParent (msgHEre.transform, false);
		}

		if(!manClear){
			Invoke ("ClearMessage", 2);
		}
	}

	public void ClearMessage(){
		GameObject.Destroy (msgHere);
		curDisplay = false;
	}

	private int Split(string msg){
		int currentBreak = 0;
		for(int i = 0; i < msg.Length; i++){
			if(msg[i] == ' '){
				currentBreak = i + 1;
			}
			if(i == GlobalConstants.msgLettersPerRow && currentBreak == 0){
				return i - 1;
			}
		}
		return msg.Length;
	}

}
