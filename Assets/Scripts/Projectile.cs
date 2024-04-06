using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    [SerializeField] private float ShootSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShootBullet();
        }
    }


    public void ShootBullet()
    {
        Bullet bullet = Instantiate(_bullet, transform.position, _bullet.transform.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(gameObject.transform.forward * (Time.fixedDeltaTime * ShootSpeed), ForceMode.Acceleration);
    }
}