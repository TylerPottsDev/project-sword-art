using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] Rigidbody2D rb;
	
	float mx;
	float my;

	private void Update() {
		mx = Input.GetAxis("Horizontal");
		my = Input.GetAxis("Vertical");
	}

	private void FixedUpdate() {
		rb.velocity = new Vector2(mx, my).normalized * Player.instance.speed;
	}
}
