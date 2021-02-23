using System;
using UnityEngine;
using UnityEngine.AI;
using NavMeshBuilder = UnityEditor.AI.NavMeshBuilder;

public class AgentExample : MonoBehaviour
{
    [SerializeField] private Player player = null;
    [SerializeField] private Transform enemyHomePoint = null;
    [SerializeField] private float observeRange = 5f;

    private NavMeshAgent agent;
    private IShooting shootComponent;
    private Transform targetToFollow;

    private void Awake()
    {
        shootComponent = this.GetComponent<IShooting>();
        targetToFollow = player.transform;
        agent = this.GetComponent<NavMeshAgent>();

        //this was made in order to work in 2D environment.
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Start()
    {
        player.PlayerDeathEven += OnPlayerDied;
    }

    private void Update()
    {
        if (targetToFollow != null)
        {
            if (Vector2.Distance(targetToFollow.position, this.transform.position) <= observeRange)
            {
                agent.SetDestination(targetToFollow.position);
            }
        }
        
        TriggerShooting();
    }

    private void TriggerShooting()
    {
        if (Vector2.Distance(agent.transform.position, targetToFollow.position) <= agent.stoppingDistance)
        {
            shootComponent.Shoot(targetToFollow.position);
        }
    }

    private void OnPlayerDied()
    {
        observeRange = Single.MaxValue;
        targetToFollow = enemyHomePoint;
        agent.stoppingDistance = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, observeRange);
    }
}