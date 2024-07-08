using UnityEngine;

namespace Player.Scripts
{
    public class Debugger : MonoBehaviour
    {
        private float _xMargin = 20f;
        private float _yMargin = 20f;
        private float _lineWidth = 300f;
        private float _lineHeight = 20f;

        private Controller _controller;

        private void Start()
        {
            _controller = GetComponent<Controller>();
        }

        private void OnGUI()
        {
            GUI.color = Color.green;
            float y = _yMargin;
            GUI.Label(new Rect(_xMargin, y += _yMargin, _lineWidth, _lineHeight), "CONTROLLER DEBUG INFO");
            GUI.Label(new Rect(_xMargin, y += _yMargin, _lineWidth, _lineHeight), $"Speed: {_controller.Speed:0.00}");
        }
    }
}