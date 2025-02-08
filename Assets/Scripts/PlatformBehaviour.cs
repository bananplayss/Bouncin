using System.Net.Sockets;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField] private bool isMovingPlatform = false;
    [SerializeField] private bool isFadingPlatform = false;

	[SerializeField] private float movingDistanceMultiplayer = 1;
	[SerializeField] private float speedMultiplayer = 1;

	private Vector3 end;
	private Vector3 start;
	private Vector3 target;


	private float animCooldown = .6f;

	private bool isBouncing = false;

	private float fadeTimer;
	private float fadeTimerMax = 2;
	private bool fading = false;
	private SpriteRenderer sr;
	private Animator animator;

	private void Start() {
		fadeTimer = fadeTimerMax;

		start = transform.position;
		end = transform.position + Vector3.right * 1.6f;
		sr = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();

		SwitchTarget();
	}

	private void Update() {

		fadeTimer -= Time.deltaTime;
		if (fadeTimer < 0) {
			fadeTimer = fadeTimerMax;
			fading = !fading;
		}

		if (isMovingPlatform) {
			transform.position = Vector3.MoveTowards(transform.position,target * movingDistanceMultiplayer, Time.deltaTime * speedMultiplayer);
			if(Vector3.Distance(transform.position, target) < .25f) {
				SwitchTarget();
			}
		}
		if (isFadingPlatform) {
			Color lastColor = sr.color;
			float alpha = 0;
			if (fading) {
				alpha = Mathf.Lerp(1, .2f, Time.deltaTime);
				lastColor.a = alpha;
				sr.color = lastColor;
			} else {
				alpha = Mathf.Lerp(.2f, 1, Time.deltaTime);
				lastColor.a = alpha;
				sr.color = lastColor;
			}
			
			
		}

		if (isBouncing) {
			animCooldown -= Time.deltaTime;
			if (animCooldown < 0) {
				isBouncing = false;
				animCooldown = .5f;
			}
		}
	}

	private void SwitchTarget() {
		target = target == end ? start : end;
	}

	private void OnCollisionEnter2D(Collision2D collision) {


		if (collision.collider.CompareTag("Player")) {
			const string PLATFORM_JUMP_On = "PlatformJumpOn";
			if (!isBouncing) {
				animator.Play(PLATFORM_JUMP_On);
				isBouncing = true;
			}
			
			BallBehaviour.Instance.CanBounce();
			if (!isMovingPlatform) return;
			collision.collider.transform.parent = transform;
			
		}
	}

	private void OnCollisionExit2D(Collision2D collision) { 

		if (collision.collider.CompareTag("Player")) {
			BallBehaviour.Instance.CantBounce();
			if (!isMovingPlatform) return;
			collision.collider.transform.parent = null;
			
		}
	}
}
