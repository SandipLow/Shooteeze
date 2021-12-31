using UnityEngine;

public class PlayerBehaviors : MonoBehaviour
{
    public Camera cam;
    public ParticleSystem Fire;
	public EnterCode enterCode;
	public GameObject cleared;

	private void Update() {

		// if (Input.GetButtonDown("Fire1"))
		// {
		// 	GetComponent<PlayerBehaviors>().shoot();
		// }

	}

    public void shoot()
	{
		RaycastHit hit;

		Fire.Play();

		// infinite hit :

		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
		{
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

		// finite hit :
		
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit ,12f))
		{

			if (hit.transform.gameObject.tag == "Grabbable")
			{
				try
				{
	 				Drop(transform.Find("GrabObject").GetChild(0).gameObject);
					Grab(hit.transform.gameObject);
				}
				catch
				{
					Grab(hit.transform.gameObject);
				}
			}

			if (hit.transform.gameObject.tag == "Lock")
			{
				string KeyName = hit.transform.gameObject.GetComponent<DoorLock>().KeyObjectName;

				if (gameObject.transform.Find("GrabObject").GetChild(0).name == KeyName)
				{
					if (hit.transform.GetComponent<DoorLock>().isNextLevelDoor)
					{
						cleared.SetActive(true);
						Cursor.visible = true;
						Cursor.lockState = CursorLockMode.None;
						gameObject.GetComponent<FPSCharacterController>().enabled = false;
						gameObject.GetComponent<FPSControllerTouchScreen>().enabled = false;
						Time.timeScale = 0;
					}

					hit.transform.parent.gameObject.SetActive(false);
					
				}
			}
			
			if (hit.transform.gameObject.name == "EnterCode")
			{
				enterCode.gameObject.SetActive(true);
				enterCode.code = hit.transform.GetComponent<DoorLockCode>().Code;
				enterCode.Door = hit.transform.parent.gameObject;
				enterCode.Starter();
			}
		}

		
	}

	public void Grab(GameObject grabItem)
	{
		grabItem.transform.parent = gameObject.transform.GetChild(2);
		if (grabItem.TryGetComponent(out Rigidbody rb))
		{
			Destroy(grabItem.GetComponent<Rigidbody>());
		}
		grabItem.transform.localPosition = new Vector3(-0.6f, 0.5f, 1f);
		grabItem.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
	}

	public void Drop(GameObject grabItem)
	{
		grabItem.transform.parent = null;

		if (grabItem.TryGetComponent(out Rigidbody rb))
		{
			grabItem.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 2000f * Time.deltaTime);
		}

		else
		{
			grabItem.AddComponent<Rigidbody>().AddForce(gameObject.transform.forward * 2000f * Time.deltaTime);
		}
	}
}
