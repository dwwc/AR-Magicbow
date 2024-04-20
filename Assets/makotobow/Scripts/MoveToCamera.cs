using UnityEngine;
using UnityEngine.AI;

public class MoveToCamera : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform cameraTransform;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        cameraTransform = Camera.main.transform; // 获取主摄像机的 Transform

        SetCameraAsTarget();
    }

    void SetCameraAsTarget()
    {
        if (cameraTransform != null)
        {
            navMeshAgent.destination = cameraTransform.position;
            navMeshAgent.enabled = true;
        }
    }
}
