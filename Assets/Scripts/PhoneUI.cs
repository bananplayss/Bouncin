using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneUI : MonoBehaviour
{
	public static PhoneUI Instance { get; private set; }

	public event EventHandler OnJump;
	public event EventHandler OnSwitch;


	[SerializeField] private GameObject container;

	[SerializeField] private Button jumpButton;
	[SerializeField] private Button switchButton;

	private void Awake() {
		Instance = this;

		jumpButton.onClick.AddListener(() => {
			OnJump?.Invoke(this, EventArgs.Empty);
		});

		switchButton.onClick.AddListener(() => {
			OnSwitch?.Invoke(this, EventArgs.Empty);
		});
	}

	private void Start() {
		GameManager.Instance.OnDisablePhoneUI += Instance_OnDisablePhoneUI;
	}

	private void Instance_OnDisablePhoneUI(object sender, System.EventArgs e) {
		container.SetActive(false);
	}


}
