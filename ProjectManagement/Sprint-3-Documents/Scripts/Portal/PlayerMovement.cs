using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    public GameObject playerPrefab;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 position)
    {
        if (!agent.enabled)
        {
            agent.enabled = true;
        }
        agent.SetDestination(position);
    }

    public bool IsStillMoving()
    {
        return agent.remainingDistance > agent.stoppingDistance;
    }

    private void StopAgent()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }

    private void EnableAgent()
    {
        agent.isStopped = false;
    }

    public void TeleportTo(Transform destination)
    {
        StopAgent();
        EnableAgent(); // Enable the agent first
        transform.position = destination.position; // Set the position afterward

        // Set the new destination for the agent after teleportation
        agent.SetDestination(destination.position);
    }
}