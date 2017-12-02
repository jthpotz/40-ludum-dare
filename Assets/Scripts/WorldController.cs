using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	private GameObject self;

	// Use this for initialization
	void Start () {

		self = GameObject.FindWithTag ("WorldController");

		Object.DontDestroyOnLoad (self);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
