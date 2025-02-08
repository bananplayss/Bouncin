
using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
	public static BallBehaviour Instance {  get; private set; }

	private ArrowBehaviour arrow;
	private Rigidbody2D rig2d;

	public event EventHandler OnBounceOff;
	public event EventHandler OnBounceOn;

	private Animator animator;

	private float animCooldown = .4f;

	private bool isBouncing = false;
	private bool canBounce = true;

	private void Start() {
		Instance = this;

		animator = GetComponent<Animator>();
		arrow = GetComponentInChildren<ArrowBehaviour>();
		rig2d = GetComponent<Rigidbody2D>();

		PhoneUI.Instance.OnJump += Instance_OnJump;
	}

	private void Instance_OnJump(object sender, EventArgs e) {
		if (canBounce) {
			Jump();
		}
		
	}

	public void CanBounce() {
		canBounce = true;
	}

	public void CantBounce() {
		canBounce = false;
	}

	private void Update() {

		if (Input.GetMouseButtonDown(1) && canBounce ) {
			Jump();
		}
		if (isBouncing) {
			animCooldown -= Time.deltaTime;
			if (animCooldown < 0) {
				isBouncing = false;
				animCooldown = .5f;
			}
		}
	}

	private void Jump() {
		rig2d.AddForce(arrow.transform.up * 300);

		OnBounceOff?.Invoke(this, EventArgs.Empty);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		const string platformTag = "Platform";
		const string ballBounceAnim = "BallBounce";
		

		if (collision.gameObject.CompareTag(platformTag)) {
			OnBounceOn?.Invoke(this, EventArgs.Empty);
			if (!isBouncing) {
				animator.Play(ballBounceAnim);
				isBouncing = true;
			}
			
		}
	}


}
