using System;
using UnityEngine;

namespace PickupableObjects
{
    public abstract class PickupBase : MonoBehaviour
    {
        protected GameObject player;
        
        protected abstract void Pickup();
        private void SelfDestroy() => Destroy(this.gameObject);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                player = other.gameObject;
                Pickup();
                SelfDestroy();
            }
        }
    }
}
