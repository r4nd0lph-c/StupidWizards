// ============================================== //
// Script: Player movement controller (Rigidbody) //
// Author: R4nd0lphC                              //
// ============================================== //

using UnityEngine;

namespace Player.Scripts
{
    public class Controller : MonoBehaviour
    {
        [Header("CAMERA")]
        [SerializeField] protected Camera _camera;
        [SerializeField] protected float _xSensitivity = 150f;
        [SerializeField] protected float _ySensitivity = 150f;
        protected float _xRotation;
        protected float _yRotation;
        protected float _xInput;
        protected float _yInput;

        protected virtual void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        protected virtual void Update()
        {
            GetInput();
            Rotate();
        }

        protected virtual void FixedUpdate()
        {
        }

        protected virtual void GetInput()
        {
            _xInput = Input.GetAxis("Mouse X") * Time.deltaTime * _xSensitivity;
            _yInput = Input.GetAxis("Mouse Y") * Time.deltaTime * _ySensitivity;
        }

        protected virtual void Rotate()
        {
            _yRotation += _xInput;
            _xRotation = Mathf.Clamp(_xRotation - _yInput, -90f, 90f);
            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
        }
    }
}