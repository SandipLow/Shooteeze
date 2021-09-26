using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

	public int health;

	public Image GO;

	public FPSCharacterController playerMovementScript;

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		GO.gameObject.SetActive(true);
		playerMovementScript.enabled = false;
		Time.timeScale = 0;
		// Destroy(gameObject);
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.transform.name == "Laser")
		{
			Debug.Log("Laser Interruption");
			gameObject.GetComponent<PlayerHealth>().TakeDamage(1000);
		}
	}

}
