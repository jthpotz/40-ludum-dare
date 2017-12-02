using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

	private int totalCapacity = GlobalConstants.startMaxCapcacity;
	private int currentCapacity = 0;

	private Hand h = new Hand ();


	public int TotalCapacity{
		get { return totalCapacity; }
	}
	public int CurrentCapacity{
		get { return currentCapacity; }
	}

	public Hand H{
		get { return h; }
	}

	public Player(){
			
	}

}
