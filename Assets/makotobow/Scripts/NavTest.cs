using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 寻路系统
/// </summary>
public class NavTest : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (agent != null)
        {
            bool flag = agent.SetDestination(target.position);
        }
    }
}
