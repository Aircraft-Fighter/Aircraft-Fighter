using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private float throwSeed ;
    private Rigidbody _bombRigidbody;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowBomb();
        }
    }

    public void ThrowBomb()
    {
        GameObject initBomb = Instantiate(bomb, transform.position, Quaternion.identity);
        _bombRigidbody = initBomb.GetComponent<Rigidbody>();
        _bombRigidbody.AddForce(gameObject.transform.forward * (Time.fixedDeltaTime * throwSeed), ForceMode.Acceleration);
    }
}