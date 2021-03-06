using System;
using System.Collections;
using UnityEngine;

namespace Projectiles
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        protected ProjectileData data;
        protected SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = this.GetComponent<SpriteRenderer>();
        }

        public void StartProjectile(ProjectileData data)
        {
            this.data = data;
            SetupInitialConfigurations();
            StartCoroutine(ProjectileBehaviourRoutine());
        }

        public void SetData(ProjectileData data)
        {
            this.data = data;
        }
        
        protected abstract void SetupInitialConfigurations();

        private IEnumerator ProjectileBehaviourRoutine()
        {
            yield return ProjectileAnimationRoutine();
            yield return LoopRoutine();
        }

        protected virtual IEnumerator ProjectileAnimationRoutine()
        {
            yield return null;
        }

        protected virtual IEnumerator LoopRoutine()
        {
            yield return null;
        }
    }
}
