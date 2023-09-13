using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public Transform puller;
    public float rb_t = 10f;
    public bool inSight;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0,100,10);
    }

    // Update is called once per frame
    void Update()
    {
        inSight = Physics.CheckSphere(transform.position, rb_t);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pull"))
        {
            puller = other.transform;
        }
        
        //puller = GameObject.FindWithTag("Pull").transform;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Push"))
        {
            rb.AddForce(rb_t,rb_t,rb_t);
        }
    }
    private void FixedUpdate()
    {
        if (inSight) 
        {
                  
            rb.AddForce(puller.position - rb.transform.position,ForceMode.Force);
        }       
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    }
}
