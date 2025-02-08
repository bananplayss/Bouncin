using System;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{

	BallBehaviour ball;

	private bool lerpingUp;
	private bool lerpingDown;

	private void Start() {
		lerpingUp = true;

		ball = GetComponentInParent<BallBehaviour>();
		ball.OnBounceOn += Ball_OnBounceOn;
		ball.OnBounceOff += Ball_OnBounceOff;
	}

	private void Ball_OnBounceOff(object sender, EventArgs e) {
		gameObject.SetActive(false);
	}

	private void Ball_OnBounceOn(object sender, EventArgs e) {
		gameObject.SetActive(true);
	}

	public Vector3 ReturnArrowPos() {
		return transform.up;
	}


	private void FixedUpdate() {


		Vector3 multiplier = new Vector3(0, 0, 2f);

		float maxAngle = 0;
		float minAngle = 0;

		if (transform.parent.localScale.x == -1) {
			maxAngle = 85;
			minAngle = 5;

			if (transform.eulerAngles.z >= maxAngle) {
				lerpingDown = false;
				lerpingUp = true;
			}
			if (transform.eulerAngles.z <= minAngle) {
				lerpingUp = false;
				lerpingDown = true;
			}
		} else {
			float minRot = 0.03f;
			float maxRot= .7f;

			if (transform.localRotation.z >= maxRot) {
				lerpingDown = true;
				lerpingUp = false;
			}
			if (transform.localRotation.z <= minRot) {
				lerpingUp = true;
				lerpingDown = false;
			}
		}

		if (lerpingUp) {
			transform.eulerAngles -= multiplier;
		} else if (lerpingDown) { transform.eulerAngles += multiplier; }


	}
}
