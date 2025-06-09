using UnityEngine;

namespace SyncRun
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "BattleBucks/Player Data")]
    public class PlayerSO : ScriptableObject
    {
        [SerializeField] internal float forwardSpeed = 5f;
        [SerializeField] internal float lateralSpeed = 3f;
        [SerializeField] internal float jumpForce = 7f;
        [SerializeField] internal LayerMask groundLayer;
        [SerializeField] internal float groundCheckDistance = 0.1f;

        [Header("Player Bound")]
        [SerializeField] internal float minX = -3f; // Left bound
        [SerializeField] internal float maxX = 3f;  // Right bound
    }
}
