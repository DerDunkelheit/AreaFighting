using Components;
using UnityEngine;

namespace Player
{
    public class PlayerMovementComponent : BaseComponent
    {
        [SerializeField] private float moveSpeed = 5f;
        
        private float horizontalInput;
        private float verticalInput;
        private Rigidbody2D rb;
        private Vector2 currentMovement;
        
        private readonly float inputTreshold = 0.1f;

        protected override bool AllowInput => true;

        private void Awake()
        {
            rb = this.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            currentMovement = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;
            var moveTo = rb.position + currentMovement * Time.deltaTime;
            rb.MovePosition(moveTo);
        }

        protected override void HandleInput()
        {
            base.HandleInput();

            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        protected override void HandleAbility()
        {
            base.HandleAbility();

            if (currentMovement.normalized.magnitude > inputTreshold)
            {
                this.transform.localScale = currentMovement.normalized.x > 0 ? Vector3.one : new Vector3(-1, 1, 1);
            }
        }
    }
}
