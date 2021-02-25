using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public static Player instance;
	
	[Header("Items")]
	public GameObject currentWeapon;

	[Header("Stats")]
	public float maxHealth = 100f;
	public float currentHealth;
	public float speed = 5f;
	public float attackSpeed = 0.8f;
	public float healSpeed = 5f;

	private void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}
}
