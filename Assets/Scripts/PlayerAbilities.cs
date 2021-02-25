using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {
    
	Animator swordAnim;

	private void Start() {
		swordAnim = Player.instance.currentWeapon.GetComponent<Animator>();
	}

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			swordAnim.Play("SwordSwing");
		}
	}

}
