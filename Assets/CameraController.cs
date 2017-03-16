using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 30f;
	public float panBorderThickness = 10f;
	public float scrollSpeed = 5f;
	public float minY = 10f;
	public float maxY = 80f;

	private bool doMovement = true;

	// Update is called once per frame
	void Update () {
		toggleMovement ();

		if (!doMovement)
			return;

		MoveCamera ();
	}

	void toggleMovement()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		doMovement = !doMovement;
	}

	void MoveCamera()
	{
		MoveCameraForward ();
		MoveCameraBackward ();
		MoveCameraRight ();
		MoveCameraLeft ();
		MoveCameraZoom ();
	}

	void MoveCameraForward () 
	{
		if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
			performMovement (Vector3.forward);
	}

	void MoveCameraBackward()
	{
		if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
			performMovement (Vector3.back);
	}

	void MoveCameraRight()
	{
		if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
			performMovement (Vector3.right);
	}

	void MoveCameraLeft()
	{
		if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
			performMovement (Vector3.left);
	}

	void performMovement(Vector3 vector)
	{
		transform.Translate (vector * panSpeed * Time.deltaTime, Space.World);
	}

	void MoveCameraZoom()
	{
		float scroll = Input.GetAxis ("Mouse ScrollWheel");

		Vector3 pos = transform.position;

		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp (pos.y, minY, maxY);

		transform.position = pos;
	}
}
