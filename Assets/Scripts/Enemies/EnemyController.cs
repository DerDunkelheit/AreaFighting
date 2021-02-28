using System;
using System.Collections.Generic;
using Components;
using Enemies.States;
using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyController : MonoBehaviour
    {
        public event Action DeathEvent;

        [SerializeField] private float detectRange = 5;
        [SerializeField] private PlayerController playerController = null;
        [SerializeField] private Transform enemyHomePoint = null;

        private Transform targetToFollow;
        private NavMeshAgent agent;
        private HealthComponent healthComponent;
        private IShooting shootComponent;

        private Dictionary<string, State> stateMap = new Dictionary<string, State>();
        private State currentState;

        public float GetDetectRange => detectRange;
        public Vector2 GetTargetPosition => targetToFollow.position;
        public NavMeshAgent GetAgent => agent;

        private void Awake()
        {
            agent = this.GetComponent<NavMeshAgent>();
            shootComponent = this.GetComponent<IShooting>();
            healthComponent = this.GetComponent<HealthComponent>();
            healthComponent.HealthDepletedEvent += OnEnemyDied;

            //this was made in order to work in 2D environment.
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            SetUpInitialStates();
        }

        private void Start()
        {
            ChangeState(ProducingStateIds.CHECK_TARGET_STATE);

            playerController.PlayerDeathEven += OnPlayerDied;
            targetToFollow = playerController.gameObject.transform;
        }

        private void Update()
        {
            currentState.Run();
            TriggerShooting();
        }

        private void SetUpInitialStates()
        {
            AddState(new CheckTargetState(this));
            AddState(new FollowTargetState(this));
        }

        private void TriggerShooting()
        {
            if (Vector2.Distance(agent.transform.position, targetToFollow.position) <= agent.stoppingDistance)
            {
                shootComponent.Shoot(targetToFollow.position);
            }
        }

        private void AddState(State state)
        {
            stateMap.Add(state.Id, state);
            state.RequestChangeStateEvent += ChangeState;
        }

        private void ChangeState(string nextStateId)
        {
            if (currentState != null)
            {
                if (currentState.Id == nextStateId)
                    return;

                currentState.Exit();
            }

            if (!stateMap.TryGetValue(nextStateId, out currentState))
            {
                throw new ArgumentException($"State {nextStateId} doesn't exist");
            }

            currentState.Enter();
        }

        private void OnPlayerDied()
        {
            detectRange = Single.MaxValue;
            targetToFollow = enemyHomePoint;
            agent.stoppingDistance = 0;
        }

        private void OnEnemyDied()
        {
            DeathEvent?.Invoke();
            Destroy(this.gameObject);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, detectRange);
        }
    }
}