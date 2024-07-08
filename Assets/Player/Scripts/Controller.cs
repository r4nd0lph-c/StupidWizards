// ===================================== //
// Script: Player Controller (Rigidbody) //
// Author: R4nd0lphC                     //
// ===================================== //

using UnityEngine;

namespace Player.Scripts
{
    public class Controller : MonoBehaviour
    {
        [Header("GETTERS & SETTERS")]
        public float Speed => playerRigidbody.linearVelocity.magnitude;

        [Header("REFERENCES")]
        [SerializeField] private Rigidbody playerRigidbody;
        [SerializeField] private Camera playerCamera;

        [Header("CAMERA")]
        [SerializeField] private float xSensitivity = 150f;
        [SerializeField] private float ySensitivity = 150f;
        private float _xRotation;
        private float _yRotation;
        private float _xInput;
        private float _yInput;

        [Header("MOVEMENT")]
        [SerializeField] private float moveSpeedMax = 10f;
        [SerializeField] private float moveForce = 100f;
        [SerializeField] private float stopSpeedLimit = 8f;
        private float _hInput;
        private float _vInput;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            GetInput();
            Rotate();
        }

        private void FixedUpdate()
        {
            // Move();
        }

        private void GetInput()
        {
            _xInput = Input.GetAxis("Mouse X") * Time.deltaTime * xSensitivity;
            _yInput = Input.GetAxis("Mouse Y") * Time.deltaTime * ySensitivity;
            _hInput = Input.GetAxisRaw("Horizontal");
            _vInput = Input.GetAxisRaw("Vertical");
        }

        private void Rotate()
        {
            _yRotation += _xInput;
            _xRotation = Mathf.Clamp(_xRotation - _yInput, -90f, 90f);
            playerCamera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
        }

        private void Move()
        {
            float speedFactor = (moveSpeedMax - playerRigidbody.linearVelocity.magnitude) / moveSpeedMax;
            Vector3 direction = (transform.forward * _vInput + transform.right * _hInput).normalized;
            playerRigidbody.AddForce(speedFactor * moveForce * direction, ForceMode.Force);

            // Vector3 direction = (transform.forward * _vInput + transform.right * _hInput).normalized;
            // if (Speed <= moveSpeedMax)
            //     playerRigidbody.AddForce(direction * moveForce, ForceMode.Force);

            if (Speed <= stopSpeedLimit && _hInput == 0 & _vInput == 0)
                playerRigidbody.linearVelocity = Vector3.zero;
        }
    }
}