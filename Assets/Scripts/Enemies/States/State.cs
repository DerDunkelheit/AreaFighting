using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.States
{
    public abstract class State
    {
        public event Action<string> RequestChangeStateEvent;

        private List<ITransition> transitions = new List<ITransition>();
        
        protected EnemyController controller;

        public abstract string Id { get; }

        protected State(EnemyController controller)
        {
            this.controller = controller;
        }

        protected void AddTransition(ITransition transition)
        {
            transitions.Add(transition);
        }

        public void Run()
        {
            foreach (var transition in transitions)
            {
                transition.Run(controller);
            }

            foreach (var transition in transitions)
            {
                if (transition.Allowed)
                {
                    RequestChangeStateEvent?.Invoke(transition.NextStateId);
                }
            }

            OnRun();
        }

        public void Enter() => OnEnter();
        public void Exit() => OnExit();

        protected virtual void OnRun()
        { }

        protected virtual void OnEnter()
        { }

        protected virtual void OnExit()
        { }
    }
}