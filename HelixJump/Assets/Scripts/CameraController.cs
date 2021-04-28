using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform target;

	public float smooth = 1f; //0.125f
	public Vector3 offset;

	private void FixedUpdate()
	{
        if (target.transform.position.y - transform.position.y < -0.76f)
        {
			Vector3 desiredPosition = target.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smooth);
			transform.position = smoothedPosition;
		}

	}
}
