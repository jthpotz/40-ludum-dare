using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CardEffects = GlobalConstants.CardEffects;

public class WorldController : MonoBehaviour {

	private GameObject self;
	private GameObject canvas;

	private Player p = new Player();

	// Use this for initialization
	void Start () {

		self = GameObject.FindGameObjectWithTag ("WorldController");
		canvas = GameObject.FindGameObjectWithTag ("Canvas");

		Object.DontDestroyOnLoad (self);

		p.H.AddCard (Card.CreateCard (CardDescriptions.coins, canvas));
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (GameObject.FindGameObjectWithTag ("Coins").transform.position);
	}
}
