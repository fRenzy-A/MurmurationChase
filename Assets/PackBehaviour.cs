using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public Transform puller;
    public float rb_x;
    public float rb_y;
    public float rb_z;
    public bool inSight;
    public float range = 10f;
    private bool pushBack;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(rb_x,rb_y,rb_z);
    }

    // Update is called once per frame
    void Update()
    {
        inSight = Physics.CheckSphere(transform.position, range);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pull"))
        {
            puller = other.transform;
        }
        
        //puller = GameObject.FindWithTag("Pull").transform;

    }
    
    private void FixedUpdate()
    {
        if (inSight) 
        {
                  
            rb.AddForce(puller.position - rb.transform.position,ForceMode.Force);
        }       
        if (pushBack)
        {
            rb.AddForce(rb.transform.position - rb.transform.position, ForceMode.Force);
        }
        else pushBack = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Push"))
        {
            pushBack = true;
        }
        
        //rb.AddForce(rb.transform.position - other.transform.position, ForceMode.Force);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    }
}
