using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
	public PlayerHealth playerHealth;

	public void Start()
	{
		gameObject.GetComponent<Slider>().maxValue = playerHealth.health;
	}

	void Update()
    {
		gameObject.GetComponent<Slider>().value = playerHealth.health;
    }
}
