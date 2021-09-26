using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FPSCharacterController : MonoBehaviour
{
    public float minX = -60f;
	public float maxX = 60f;

	public float sensitivity;
	public Camera cam;

	float rotY = 0f;
	float rotX = 0f;

	public ParticleSystem Fire;

	//Personal Variables
	public GameObject enterCode;
	public GameObject cleared;

	void Start()
	{
		
	}

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

		if (Input.GetButtonDown("Fire1"))
		{
			shoot();
		}

	}

	public void shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
		{
			Fire.Play();
			// Debug.Log(hit.transform.name);
			
			//Shooting Items control

			if (hit.transform.gameObject.tag == "Enemy")
			{
				hit.transform.GetComponent<EnemyHealth>().TakeDamage(10);
			}

			if (hit.transform.name == "LaserSource")
			{
				hit.transform.GetChild(0).gameObject.SetActive(false);
			}

		}

		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit ,12f))
		{

			if (hit.transform.gameObject.tag == "Grabbable")
			{
				Grab(hit.transform.gameObject);
			}

			//Personal Actions :

			if (hit.transform.gameObject.name == "EnterCode")
			{
				enterCode.SetActive(true);
			}

			if (hit.transform.gameObject.name == "Lock")
			{
				if (gameObject.transform.GetChild(1).name == "Key")
				{
					hit.transform.parent.gameObject.SetActive(false);
					cleared.SetActive(true);
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
					gameObject.GetComponent<FPSCharacterController>().enabled = false;
					gameObject.GetComponent<FPSControllerTouchScreen>().enabled = false;
				}
			}

		}

		
	}

	void Grab(GameObject grabItem)
	{
		grabItem.transform.parent = gameObject.transform;
		grabItem.transform.localPosition = new Vector3(-0.6f, 0.5f, 1f);
		grabItem.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
	}

}
