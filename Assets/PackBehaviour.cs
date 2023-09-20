using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public Transform puller;
    public bool inSight;

    public float myVelocity;


    public float mySpeed;
    public float x;
    public float y;
    public float z;

    public float range = 10f;

    public bool outOfBounds;

    public float howMuchForce;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        outOfBounds = false;
        //rb.AddForce(, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        inSight = Physics.CheckSphere(transform.position, range);
    }
    
    
    private void FixedUpdate()
    {
        mySpeed = rb.velocity.magnitude;
        if ((rb.velocity.magnitude > myVelocity && rb.velocity.magnitude > 0) || (rb.velocity.magnitude > -myVelocity && rb.velocity.magnitude < 0))
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, myVelocity);
        }
        else
        {
            rb.AddForce(x, y, z); 
            
        }
 
    }
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Push"))
        {
            x *= -x;
            outOfBounds = true;
        }*/

        outOfBounds = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Push"))
        {
            x *= -1;
            outOfBounds = true;
        }
            
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    }
}
