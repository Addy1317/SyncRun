using UnityEngine;

namespace SyncRun
{
    using UnityEngine;

    public class SwipeInputHandler : MonoBehaviour
    {
        public delegate void SwipeDetected(string direction);
        public static event SwipeDetected OnSwipe;

        private Vector2 startTouch;
        private Vector2 endTouch;
        private float minSwipeDistance = 50f;

        void Update()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            HandleKeyboard();
            HandleMouseSwipe();
#else
        HandleTouchSwipe();
#endif
        }

        void HandleKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) OnSwipe?.Invoke("Left");
            if (Input.GetKeyDown(KeyCode.RightArrow)) OnSwipe?.Invoke("Right");
            if (Input.GetKeyDown(KeyCode.UpArrow)) OnSwipe?.Invoke("Up");
        }

        void HandleMouseSwipe()
        {
            if (Input.GetMouseButtonDown(0))
                startTouch = Input.mousePosition;

            if (Input.GetMouseButtonUp(0))
            {
                endTouch = Input.mousePosition;
                DetectSwipe();
            }
        }

        void HandleTouchSwipe()
        {
            if (Input.touchCount == 0) return;

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                startTouch = touch.position;

            if (touch.phase == TouchPhase.Ended)
            {
                endTouch = touch.position;
                DetectSwipe();
            }
        }

        void DetectSwipe()
        {
            Vector2 delta = endTouch - startTouch;

            if (delta.magnitude < minSwipeDistance)
                return;

            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                OnSwipe?.Invoke(delta.x > 0 ? "Right" : "Left");
            else if (delta.y > 0)
                OnSwipe?.Invoke("Up");
        }
    }

}
