using UnityEngine;

namespace SyncRun
{
    public class PlayerView : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] internal Rigidbody rb;
        [SerializeField] internal Transform groundCheck;
        [SerializeField] internal Transform groundRayPoint;

        public void Move(Vector3 velocity, float minX, float maxX)
        {
            Vector3 pos = transform.position;

            // Only apply X movement if we’re inside the playable area
            bool canMoveLeft = velocity.x < 0 && pos.x > minX;
            bool canMoveRight = velocity.x > 0 && pos.x < maxX;

            float clampedX = (canMoveLeft || canMoveRight) ? velocity.x : 0f;

            Vector3 currentVel = rb.linearVelocity;
            rb.linearVelocity = new Vector3(clampedX, currentVel.y, velocity.z);
        }

        public void Jump(float jumpForce)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // reset vertical
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log($"[JUMP EXECUTED] Force: {jumpForce}");
        }

        public bool IsGrounded(LayerMask groundLayer, float checkDistance)
        {
            bool grounded = Physics.Raycast(groundRayPoint.position, Vector3.down, checkDistance, groundLayer);
            Debug.DrawRay(groundRayPoint.position, Vector3.down * checkDistance, grounded ? Color.green : Color.red);
            return grounded;
        }

        public void ClampPosition(float minX, float maxX)
        {
            Vector3 pos = transform.position;
            float originalX = pos.x;
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            transform.position = pos;


            if (Mathf.Abs(originalX - pos.x) > 0.01f)
                Debug.Log($"[BOUNDS] Clamped X: {originalX} → {pos.x}");
        }
    }
}
