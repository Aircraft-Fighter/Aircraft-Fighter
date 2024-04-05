using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRollChecker : MonoBehaviour
{
    [SerializeField] float rollAngleMin = 80f;
    [SerializeField] float rollAngleMax = 100f;
    [SerializeField] float reverseRollAngleMin = 260f;
    [SerializeField] float reverseRollAngleMax = 280f;
    [SerializeField] float rotationDuration = 1f; // Duration of the rotation in seconds
    [SerializeField] private float RotateSpeed = 5;

    private Rigidbody2D rb;


    enum State
    {
        Normal,
        BarrelRoll
    }

    private State _rollState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the airplane is within the barrel roll range

        {
            // Trigger barrel roll action
            //  BarrelRoll();
        }
    }

    private void FixedUpdate()
    {
        BarrelRoll();
        // transform.rotation =new Quaternion(transform.root.eulerAngles.x, transform.root.eulerAngles.y,Quaternion.identity.z,Quaternion.identity.w);
    }

    void PerformBarrelRoll()
    {
        // Implement barrel roll action here, e.g., rotate the airplane around the z-axis
        // Example: rb.AddTorque(someTorqueValue * Time.deltaTime);
        Debug.Log("Performing barrel roll!");
    }

    private void BarrelRoll()
    {
        float currentRotation = Mathf.Abs(transform.root.eulerAngles.x);
        /*// Normalize rotation to 0-360 range
        if (currentRotation > 180f)
            currentRotation -= 360f;*/

        // TODO: Check if normal rotation
        if (!((currentRotation >= rollAngleMin && currentRotation <= rollAngleMax) ||
              (currentRotation >= reverseRollAngleMin && currentRotation <= reverseRollAngleMax)))
        {
            if (_rollState == State.Normal)
                return;

            _rollState = State.Normal;
            Debug.Log(_rollState);
        }
        // TODO: check if barrel rolled
        else if ((currentRotation >= rollAngleMin && currentRotation <= rollAngleMax) ||
                 (currentRotation >= reverseRollAngleMin && currentRotation <= reverseRollAngleMax))
        {
            if (_rollState == State.BarrelRoll)
                return;

            _rollState = State.BarrelRoll;
            Debug.Log(_rollState);
            StartCoroutine(Rotate180Degrees());
            //Rotate180Degrees();


            //transform.Rotate(Vector3.forward, 180);
        }


        // TODO: rotate with DoTween
    }

    IEnumerator Rotate180Degrees()
    {
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, 180);
        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            transform.localRotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime * RotateSpeed;
            yield return null;
        }

        transform.localRotation = endRotation; // Ensure final rotation is exactly 180 degrees
    }
}