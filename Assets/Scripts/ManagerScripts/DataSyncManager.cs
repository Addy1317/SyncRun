using UnityEngine;

namespace SyncRun
{
    public class DataSyncManager : MonoBehaviour
    {
        public Transform playerTransform;
        public RemotePlayerController remotePlayer;

        private Vector3 lastSentPosition;
        private float sendThreshold = 0.3f; // delta threshold
        private float sendInterval = 0.1f;
        private float timer;

        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= sendInterval)
            {
                Vector3 delta = playerTransform.position - lastSentPosition;
                if (delta.magnitude > sendThreshold)
                {
                    Vector3 compressed = Quantize(playerTransform.position);
                    remotePlayer.ReceiveCompressedPosition(compressed);

                    lastSentPosition = playerTransform.position;
                    Debug.Log($"📤 Sent Position: {compressed} (Size: ~12 bytes)");
                }
                timer = 0f;
            }
        }

        Vector3 Quantize(Vector3 pos)
        {
            // Reduce float precision to 2 decimal places
            return new Vector3(
                Mathf.Round(pos.x * 100f) / 100f,
                Mathf.Round(pos.y * 100f) / 100f,
                Mathf.Round(pos.z * 100f) / 100f
            );
        }
    }
}
