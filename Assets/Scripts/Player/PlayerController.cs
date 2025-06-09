using UnityEngine;

namespace SyncRun
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerSO playerSO;
        [SerializeField] private PlayerView playerView;

        void Update()
        {
            HandleMovement();
            HandleJump();
        }

        private void HandleMovement()
        {
            float moveX = Input.GetAxisRaw("Horizontal") * playerSO.lateralSpeed;
            Vector3 velocity = new Vector3(moveX, 0f, playerSO.forwardSpeed);
            playerView.Move(velocity, playerSO.minX, playerSO.maxX);
            //playerView.ClampPosition(playerSO.minX, playerSO.maxX);
            Debug.Log($"[MOVE] InputX: {moveX}, Velocity: {velocity}, Position: {playerView.transform.position}");
        }

        private void HandleJump()
        {
            bool grounded = playerView.IsGrounded(playerSO.groundLayer, playerSO.groundCheckDistance);

            Debug.Log($"[GROUND CHECK] Grounded: {grounded}");

            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                Debug.Log("[JUMP] Jump triggered");
                playerView.Jump(playerSO.jumpForce);
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !grounded)
            {
                Debug.Log("[JUMP BLOCKED] Not grounded");
            }
        }
    }
}
