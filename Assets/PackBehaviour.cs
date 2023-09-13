using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public float rb_t = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.AddForce(transform.up * rb_t);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    }
}
