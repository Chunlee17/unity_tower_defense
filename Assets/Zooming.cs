using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zooming : MonoBehaviour
{
	public Camera mainCamera;
	public float minY = 20;
	public float maxY = 80;
	public void Zoom(bool isZoomIn)
	{
		if (isZoomIn)
		{
			Vector3 position = mainCamera.transform.position;
			position.y -= 0.01f * 1000 * 5 * Time.deltaTime;
			position.y = Mathf.Clamp(position.y, minY, maxY);
			mainCamera.transform.position = position;
		}
		else
		{
			Vector3 position = mainCamera.transform.position;
			position.y -= -0.01f * 1000 * 5 * Time.deltaTime;
			position.y = Mathf.Clamp(position.y, minY, maxY);
			mainCamera.transform.position = position;
		}
	}
}
