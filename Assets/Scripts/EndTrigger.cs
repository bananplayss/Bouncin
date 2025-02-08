using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
	[SerializeField] private GameObject end;
	private bool ended;
	
	private void OnTriggerEnter2D(Collider2D collision) {
		end.SetActive(true);
		Time.timeScale = 0.0f;
		ended = true;
	}

	private void Update() {
		if(ended && Input.GetMouseButtonDown(0)) {
			Application.Quit();
		}
	}
}
