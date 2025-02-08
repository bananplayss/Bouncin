using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followTransform;

	private void Update() {
		Vector3 followTransformPos = followTransform.position;
		followTransformPos.z = -10;
		followTransformPos.x = 0.1f;
		followTransformPos.y += .5f;

		transform.position = Vector3.Lerp(transform.position, followTransformPos, Time.deltaTime*3f);
	}
}
