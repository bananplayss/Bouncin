using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI triesText;
    [SerializeField] private Transform ball;

	float currentTime = 0f;
	float score = 0;
	int tries = 0;

	private void Start() {
		Instance = this;
	}

	private void Update() {

		score = ball.transform.position.y * 3;
		if (ball.transform.position.y < 0) score = 0;

		scoreText.text = Mathf.RoundToInt(score).ToString();


		currentTime += Time.deltaTime;
		TimeSpan time = TimeSpan.FromSeconds(currentTime);
		timeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
		triesText.text = tries.ToString()+"x";
	}

	public void IncreaseTries() {
		tries++;
	}

	public static ScoreUI Instance { get; private set; }
}
