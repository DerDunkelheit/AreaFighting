using System;
using UnityEngine;

namespace Components
{
    public class BaseComponent : MonoBehaviour
    {
        protected virtual bool AllowInput { get; } = false;
        
        private void Update()
        {
            if (AllowInput)
            {
                HandleInput();
                HandleAbility();
            }
        }

        protected virtual void HandleInput()
        { }

        protected virtual void HandleAbility()
        { }
    }
}
