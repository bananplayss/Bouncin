using UnityEngine;

public class RotateX : MonoBehaviour
{
	private void Start() {
		PhoneUI.Instance.OnSwitch += Instance_OnSwitch;
	}

	private void Instance_OnSwitch(object sender, System.EventArgs e) {
		XRotate();
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.S)) {
			XRotate();
		}
	}

	public void XRotate() {
		transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.y);
	}
}
