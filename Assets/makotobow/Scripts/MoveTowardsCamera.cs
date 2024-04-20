using UnityEngine;
using UnityEngine.AI;

public class MoveTowardsCamera : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform cameraTransform;

    void Start()
{
    navMeshAgent = GetComponent<NavMeshAgent>();
    cameraTransform = Camera.main.transform;

    if (navMeshAgent != null && navMeshAgent.isActiveAndEnabled && navMeshAgent.isOnNavMesh)
    {
        navMeshAgent.SetDestination(cameraTransform.position);
    }
}

}
