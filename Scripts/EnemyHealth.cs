using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public int health;
    public GameObject removedPart;
	public FireBullet FiringScript;

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
        particleSystem.Play();
		removedPart.SetActive(false);
		FiringScript.enabled = false;
	}
}
