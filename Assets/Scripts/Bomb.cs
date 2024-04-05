using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Rigidbody _rigidbody;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //_rigidbody.AddForce(transform.forward  * 1000,ForceMode.Force);
        //_rigidbody.AddForce(transform.forward  * 1000,ForceMode.VelocityChange);
        _rigidbody.AddForce(transform.forward  * 1000,ForceMode.Acceleration);
        //_rigidbody.AddForce(transform.forward  * 1000,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        /*float lerpRotation = Mathf.Lerp(transform.rotation.z, 90, .1f);
        transform.rotation= new Vector3(transform.rotation.x ,transform.rotation.y,lerpRotation );
        transform.rotation = Quaternion.Lerp(Quaternion.identity, Quaternion.Slerp(), );*/
    }
}
