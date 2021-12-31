using UnityEngine;

public class FPSCharacterController : MonoBehaviour
{
    public float minX = -60f;
	public float maxX = 60f;

	public float sensitivity;
	public Camera cam;

	float rotY = 0f;
	float rotX = 0f;

	void Update()
    {
        //Camera Rotator Mouse :

		rotY += Input.GetAxis("Mouse X") * sensitivity;
		rotX += Input.GetAxis("Mouse Y") * sensitivity;

		rotX = Mathf.Clamp(rotX, minX, maxX);

		cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0);
		gameObject.transform.localEulerAngles = new Vector3(0, rotY, 0);

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if (Cursor.visible && Input.GetMouseButtonDown(1))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		//WASD Controller :

		float x = Input.GetAxis("Horizontal")*0.5f;
		float z = Input.GetAxis("Vertical")*0.5f;

		Vector3 move = transform.right * x + transform.forward * z;

		CharacterController ctrl = gameObject.GetComponent<CharacterController>();

		ctrl.Move(move);

    }

}
