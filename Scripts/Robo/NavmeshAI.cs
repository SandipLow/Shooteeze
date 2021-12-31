using UnityEngine;
using UnityEngine.AI;

public class NavmeshAI : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;

    bool alive;
    
    private void Awake() {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update() {
        alive = GetComponentInChildren<EnemyHealth>().alive;

        if (alive)
        {
            navMeshAgent.destination = movePositionTransform.position;   
        }
        else
        {
            GetComponent<NavmeshAI>().enabled = false;
        }
    }
}