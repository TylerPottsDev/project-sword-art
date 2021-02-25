using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] Rigidbody2D rb;
	[SerializeField] Transform hand;
	[SerializeField] SpriteRenderer GFX;
	[SerializeField] Animator GFXAnim;

	float mx;
	float my;

	private void Update() {
		mx = Input.GetAxisRaw("Horizontal");
		my = Input.GetAxisRaw("Vertical");

		GFXAnim.SetFloat("Movement", Mathf.Abs(mx) + Mathf.Abs(my));

		FlipSprite();

		RotateHand();
	}

	private void FixedUpdate() {
		rb.velocity = new Vector2(mx, my).normalized * Player.instance.speed;
	}

	private void FlipSprite() {
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (mousePos.x < transform.position.x) {
			GFX.flipX = true;
		} else {
			GFX.flipX = false;
		}
	}

	private void RotateHand() {
		float angle = AngleTowardsMouse(hand.position);

		float yScale = 1f;

		if (Mathf.Abs(angle) > 90f) {
			yScale = -Mathf.Abs(hand.localScale.y);
		} else if (Mathf.Abs(angle) < 90f) {
			yScale = Mathf.Abs(hand.localScale.y);
		}

		hand.localScale = new Vector3(hand.localScale.x, yScale, hand.localScale.z);

		hand.rotation = Quaternion.Euler(new Vector3(hand.rotation.x, hand.rotation.y, angle));
	}

	private float AngleTowardsMouse(Vector3 pos) {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 5.23f;

		Vector3 objectPos = Camera.main.WorldToScreenPoint(pos);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

		return angle;
	}
}
