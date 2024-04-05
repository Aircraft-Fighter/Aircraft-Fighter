using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    private Bomb _bomb;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject initBomb= Instantiate(bomb, transform.position, Quaternion.Euler(90,0,0));
            
        }
    }
}