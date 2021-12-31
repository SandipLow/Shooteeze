using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public ParticleSystem killedPS;
    public int health;
	public bool alive;
    public GameObject removedPart;
	public FireBullet FiringScript;
	public GameObject pathFindingScript;

	private void Start() {
		alive = true;
	}
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
        killedPS.Play();
		removedPart.SetActive(false);
		FiringScript.enabled = false;
		if (pathFindingScript.TryGetComponent(out NavMeshAgent n))
		{
			n.enabled = false;
		}
		alive = false;
	}
}
