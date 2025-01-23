using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Modules.Common
{
    public class Joystick : MonoBehaviour,
        IPointerDownHandler,
        IDragHandler,
        IPointerUpHandler
    {
        public event Action PointerDown;
        public event Action PointerUp;


        public float Horizontal
        {
            get { return (snapX) ? SnapFloat(input.x, AxisOptions.Horizontal) : input.x; }
        }

        public float Vertical
        {
            get { return (snapY) ? SnapFloat(input.y, AxisOptions.Vertical) : input.y; }
        }


        public Vector2 Direction
        {
            get { return new Vector2(Horizontal, Vertical); }
        }

        public float HandleRange
        {
            get { return handleRange; }
            set { handleRange = Mathf.Abs(value); }
        }

        public float DeadZone
        {
            get { return deadZone; }
            set { deadZone = Mathf.Abs(value); }
        }

        public AxisOptions AxisOptions
        {
            get { return axisOptions; }
            set { axisOptions = value; }
        }

        public bool SnapX
        {
            get { return snapX; }
            set { snapX = value; }
        }

        public bool SnapY
        {
            get { return snapY; }
            set { snapY = value; }
        }

        public bool IsEnable
        {
            get => this.enabled;
            set
            {
                this.enabled = value;

                if (!value)
                {
                    input = Vector2.zero;
                    handle.anchoredPosition = Vector2.zero;
                    this.PointerUp?.Invoke();
                }
            }
        }

        public bool IsPressed
        {
            get { return _pressed; }
        }

        [SerializeField]
        private float handleRange = 1;

        [SerializeField]
        private float deadZone = 0;

        [SerializeField]
        private AxisOptions axisOptions = AxisOptions.Both;

        [SerializeField]
        private bool snapX = false;

        [SerializeField]
        private bool snapY = false;

        [SerializeField]
        private RectTransform background = null;

        [SerializeField]
        private RectTransform handle = null;

        private Canvas canvas;
        private Camera cam;

        private Vector2 input = Vector2.zero;
        private bool _pressed;

        private void Start()
        {
            HandleRange = handleRange;
            DeadZone = deadZone;
            canvas = GetComponentInParent<Canvas>();
            if (canvas == null)
                Debug.LogError("The Joystick is not placed inside a canvas");

            Vector2 center = new Vector2(0.5f, 0.5f);
            background.pivot = center;
            handle.anchorMin = center;
            handle.anchorMax = center;
            handle.pivot = center;
            handle.anchoredPosition = Vector2.zero;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _pressed = true;
            this.PointerDown?.Invoke();
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            cam = null;
            if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
                cam = canvas.worldCamera;

            Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, background.position);
            Vector2 radius = background.sizeDelta / 2;
            input = (eventData.position - position) / (radius * canvas.scaleFactor);
            FormatInput();
            HandleInput(input.magnitude, input.normalized, radius, cam);
            handle.anchoredPosition = input * radius * handleRange;
        }

        protected void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
        {
            if (magnitude > deadZone)
            {
                if (magnitude > 1)
                    input = normalised;
            }
            else
                input = Vector2.zero;
        }

        private void FormatInput()
        {
            if (axisOptions == AxisOptions.Horizontal)
                input = new Vector2(input.x, 0f);
            else if (axisOptions == AxisOptions.Vertical)
                input = new Vector2(0f, input.y);
        }

        private float SnapFloat(float value, AxisOptions snapAxis)
        {
            if (value == 0)
                return value;

            if (axisOptions == AxisOptions.Both)
            {
                float angle = Vector2.Angle(input, Vector2.up);
                if (snapAxis == AxisOptions.Horizontal)
                {
                    if (angle < 22.5f || angle > 157.5f)
                        return 0;
                    else
                        return (value > 0) ? 1 : -1;
                }
                else if (snapAxis == AxisOptions.Vertical)
                {
                    if (angle > 67.5f && angle < 112.5f)
                        return 0;
                    else
                        return (value > 0) ? 1 : -1;
                }

                return value;
            }
            else
            {
                if (value > 0)
                    return 1;
                if (value < 0)
                    return -1;
            }

            return 0;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pressed = false;
            input = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
            this.PointerUp?.Invoke();
        }
    }

    public enum AxisOptions
    {
        Both,
        Horizontal,
        Vertical
    }
}