using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCTRL : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float Speed = 2000f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Speed);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
