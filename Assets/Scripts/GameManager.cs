using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public event EventHandler OnDisablePhoneUI;

	private void Awake() {
		Instance = this;
	}

	private void Start() {
		if(SystemInfo.deviceType == DeviceType.Desktop) {
			OnDisablePhoneUI?.Invoke(this, EventArgs.Empty);
		}
	}
}
