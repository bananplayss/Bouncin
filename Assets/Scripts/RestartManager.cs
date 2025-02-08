
using UnityEngine;

public class RestartManager : MonoBehaviour
{
    [SerializeField] private Transform ball;

	private float minY = -10;

	private void Update() {
		if(ball.transform.position.y < minY) {
			ball.transform.position = new Vector3(0.6f, -0.4f, 0f);
			ScoreUI.Instance.IncreaseTries();
		}
	}
}
