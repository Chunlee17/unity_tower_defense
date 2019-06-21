using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public bool doMovement = false;
	public float panSpeed = 30f;
	public float scrollSpeed = 5f;
	public float panBorderThickness = 10f;
	public float minY = 20;
	public float maxY = 80;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.Space))
			doMovement = !doMovement;
		if (!doMovement)
		{
			return;
		}

		if (GameManager.gameEnded)
		{
			this.enabled = false;
			return;
		}
		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
		{
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
		{
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");

		Vector3 position = transform.position;
		position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		position.y = Mathf.Clamp(position.y, minY, maxY);
		transform.position = position;

	}
}
