using UnityEngine;

namespace SyncRun
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;       // Player transform
        [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -10f);
        [SerializeField] private float followSpeed = 5f;

        private void LateUpdate()
        {
            if (!target) return;

            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
