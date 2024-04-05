using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float RotateSpeed;
    public Vector3 vectorRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(vectorRotation * Time.deltaTime,RotateSpeed);
    }
}
