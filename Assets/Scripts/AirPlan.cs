using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlan : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    private PlayerControls _playerControls;
    [SerializeField] private float rotateSpeed = 500;
    [SerializeField] private float MovingSpeed = 10;
    private Rigidbody _rigidbody;

    private State _rollState;
    private Vector3 direction;

    enum State
    {
        Normal,
        BarrelRoll
    }

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void Update()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            var rot = Mathf.Atan2(_joystick.Direction.y, _joystick.Direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rot - 180, 0, 0),
                .25f * Time.deltaTime * rotateSpeed);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (MovingSpeed * Time.fixedDeltaTime));
        Move();
    }

    private void Move()
    {
        float rotateDirection = _playerControls.Rotation.Rotate.ReadValue<float>();
        // Debug.Log(rotateDirection);
        float angle = rotateDirection * rotateSpeed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.left, angle);
    }
}