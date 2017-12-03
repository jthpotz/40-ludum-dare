using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {

	public AudioClip damage;
	public AudioClip enemyAppear;
	public AudioClip enemyAttack;
	public AudioClip item;
	public AudioClip powerUp;
	public AudioClip enemyDefeated;

	// Use this for initialization
	void Start () {
		
		damage = Resources.Load<AudioClip> ("Audio/wav/Damage");
		enemyAppear = Resources.Load<AudioClip> ("Audio/wav/EnemyAppear");
		enemyAttack = Resources.Load<AudioClip> ("Audio/wav/EnemyAttack");
		item = Resources.Load<AudioClip> ("Audio/wav/Item");
		powerUp = Resources.Load<AudioClip> ("Audio/wav/Powerup");
		enemyDefeated = Resources.Load<AudioClip> ("Audio/wav/EnemyDefeated");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
