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

    public float xBounds;
    public float yBounds;
    public float zBounds;


    public float forceOfBounds;

    public float pullRange = 10f;
    public float pushRange = 3f;
    public bool outOfBounds;

    public float howMuchForce;
    float xOOB; float yOOB; float zOOB;

    public Collider[] howMany;

    public Transform bounds;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        xOOB = forceOfBounds; yOOB = forceOfBounds; zOOB = forceOfBounds;
        bounds = GameObject.FindWithTag("Push").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        outOfBounds = false;
        rb.AddForce(Random.Range(5,10),Random.Range(1, 10), Random.Range(1, 10), ForceMode.Impulse);
        xBounds = 20 + bounds.transform.position.x;
        yBounds = 20 + bounds.transform.position.y;
        zBounds = 20 + bounds.transform.position.z;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        inSight = Physics.CheckSphere(transform.position, pushRange);

    }
    
    
    private void FixedUpdate()
    {
        x = rb.velocity.x; y = rb.velocity.y; z = rb.velocity.z;
        mySpeed = rb.velocity.magnitude;
        //cap the maximum velocity/speed
        if ((rb.velocity.magnitude > myVelocity && rb.velocity.magnitude > 0) || (rb.velocity.magnitude > -myVelocity && rb.velocity.magnitude < 0))
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, myVelocity);
        }
        Collider[] inMyRadius = Physics.OverlapSphere(rb.transform.position,pullRange);

        Collider[] inMyPushRadius = Physics.OverlapSphere(rb.transform.position, pushRange);
        howMany = inMyPushRadius;
        
        foreach (Collider c in inMyRadius) 
        {
            if (c.CompareTag("Push"))
            {
                return;
            }
            
            else if (c.transform.root != c.transform)
            {
                rb.AddForce(c.transform.position - rb.transform.position, ForceMode.Acceleration);
            }        
        }
        foreach (Collider d in inMyPushRadius)
        {
            if (d.CompareTag("Push"))
            {
                return;
            }
            else if (d.transform.root != d.transform)
            {
               
                rb.AddForce(d.transform.position + rb.transform.position * 3, ForceMode.Acceleration);
            }
        }
        Bounds();
    }

    private void Bounds()
    {
        
        if ((xBounds < rb.transform.position.x) && rb.transform.position.x > bounds.transform.position.x)
        {
            //xOOB = xOOB * -1;
            rb.AddForce(-xOOB * 2, 0, 0);
        }
        else if ((-xBounds > rb.transform.position.x) && rb.transform.position.x < bounds.transform.position.x)
        {
            //xOOB = xOOB * -1;
            rb.AddForce(xOOB * 2, 0, 0);
        }

        if ((yBounds < rb.transform.position.y) && rb.transform.position.y > bounds.transform.position.y)
        {
            //yOOB = yOOB * -1;
            rb.AddForce(0, -yOOB * 2, 0);
        }
        else if ((-yBounds > rb.transform.position.y) && rb.transform.position.y < bounds.transform.position.y)
        {
            rb.AddForce(0, yOOB * 2, 0);
        }

        if ((zBounds < rb.transform.position.z) && rb.transform.position.z > bounds.transform.position.z)
        {
            //zOOB = zOOB * -1;
            rb.AddForce(0, 0, -zOOB * 2);
        }
        else if ((-zBounds > rb.transform.position.z) && rb.transform.position.z < bounds.transform.position.z)
        {
            rb.AddForce(0, 0, zOOB * 2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Push"))
        {
            x *= -x;
            outOfBounds = true
        }*/

        outOfBounds = false;
    }
    private void OnTriggerExit(Collider other)
    {
        /*if (other.gameObject.CompareTag("Push"))
        {
            if (((bounds.transform.localScale.x < rb.transform.position.x) && rb.transform.position.x > 0) || ((-bounds.transform.localScale.x > rb.transform.position.x) && rb.transform.position.x < 0))
            {
                x = rb.velocity.x * -1;
            }
            if (((bounds.transform.localScale.y < rb.transform.position.y) && rb.transform.position.y > 0) || ((-bounds.transform.localScale.y > rb.transform.position.y) && rb.transform.position.y < 0))
            {
                y = rb.velocity.y * -1;
            }
            if (((bounds.transform.localScale.z < rb.transform.position.z) && rb.transform.position.z > 0) || ((-bounds.transform.localScale.z > rb.transform.position.z) && rb.transform.position.z < 0))
            {
                z = rb.velocity.z * -1;
            }
            
        }*/
        /*if (other.gameObject.CompareTag("Push"))
        {
            if (((xBounds < rb.transform.position.x) && rb.transform.position.x > 0) || ((-xBounds > rb.transform.position.x) && rb.transform.position.x < 0))
            {
                xOOB = xOOB * -1;
                
            }
            if (((yBounds < rb.transform.position.y) && rb.transform.position.y > 0) || ((-yBounds > rb.transform.position.y) && rb.transform.position.y < 0))
            {
                yOOB = yOOB * -1;
                
            }
            if (((zBounds < rb.transform.position.z) && rb.transform.position.z > 0) || ((-zBounds > rb.transform.position.z) && rb.transform.position.z < 0))
            {
                zOOB = zOOB * -1;
                
            }
        }*/
        outOfBounds = true;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pullRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pushRange);
    }
}
