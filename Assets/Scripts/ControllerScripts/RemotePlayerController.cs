using UnityEngine;

namespace SyncRun
{
    public class RemotePlayerController : MonoBehaviour
    {
        private Vector3 targetPosition;
        private Vector3 lastPosition;
        private float lerpTime = 0f;
        private float lerpDuration = 0.1f; // time between updates

        void Update()
        {
            lerpTime += Time.deltaTime;
            float t = Mathf.Clamp01(lerpTime / lerpDuration);
            transform.position = Vector3.Lerp(lastPosition, targetPosition, t);
        }

        public void ReceiveCompressedPosition(Vector3 compressedPosition)
        {
            lastPosition = transform.position;
            targetPosition = compressedPosition;
            lerpTime = 0f;
        }
    }
}
