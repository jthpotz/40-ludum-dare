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

		for(int i = 0; i < 4; i++){
			p.H.AddCard (Card.CreateCard (CardDescriptions.coins, canvas));
		}
		p.H.AddCard (Card.CreateCard (CardDescriptions.coinStack, canvas));
		for(int i = 0; i < 4; i++){
			p.H.AddCard (Card.CreateCard (CardDescriptions.coins, canvas));
		}
		p.H.AddCard (Card.CreateCard (CardDescriptions.coinStack, canvas));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
