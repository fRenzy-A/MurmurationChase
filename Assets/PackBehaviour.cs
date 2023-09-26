using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public Transform puller;
    public bool inSight;

    public float maxVelocity;


    public float mySpeed;

    public float pullMultiplier;
    public float pushAwayMultiplier;

    public float pullNPushXMult;
    public float pullNPushYMult;
    public float pullNPushZMult;

    public float xBounds;
    public float yBounds;
    public float zBounds;


    public float forceOfBounds;

    public float pullRange = 10f;
    public float pushRange = 1f;
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

        rb.AddForce(Random.Range(1,10),Random.Range(1, 10), Random.Range(1, 10), ForceMode.Impulse);


        xBounds = (bounds.transform.localScale.x / 2) + bounds.transform.position.x;
        yBounds = (bounds.transform.localScale.y / 2) + bounds.transform.position.y;
        zBounds = (bounds.transform.localScale.z / 2) + bounds.transform.position.z;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        inSight = Physics.CheckSphere(transform.position, pushRange);

    }
    
    
    private void FixedUpdate()
    {
        //x = rb.velocity.x; y = rb.velocity.y; z = rb.velocity.z;
        mySpeed = rb.velocity.magnitude;
        //cap the maximum velocity/speed
        if ((rb.velocity.magnitude > maxVelocity && rb.velocity.magnitude > 0) || (rb.velocity.magnitude > -maxVelocity && rb.velocity.magnitude < 0))
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
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
            /*else if (c.transform.root != c.transform)
            {
                
            }*/
            else
            {
                rb.AddForce((c.transform.position - rb.transform.position), ForceMode.Force);
            }
        }
        foreach (Collider d in inMyPushRadius)
        {
            if (d.CompareTag("Push"))
            {
                return;
            }
            else if (d.transform != d.transform.root)
            {
                Vector3 dir = d.transform.position - transform.position;
                dir = -dir;
                rb.AddForce(dir * 5, ForceMode.Impulse);
            }
            
            //else rb.AddForce(d.transform.position + rb.transform.position, ForceMode.Impulse);
        }
        Bounds();
    }

    private void Bounds()
    {
        
        if ((xBounds < rb.transform.position.x) && rb.transform.position.x > bounds.transform.position.x)
        {
            //xOOB = xOOB * -1;
            rb.AddForce(-xOOB * 2, 0, 0,ForceMode.Acceleration);
        }
        else if ((-xBounds > rb.transform.position.x) && rb.transform.position.x < bounds.transform.position.x)
        {
            //xOOB = xOOB * -1;
            rb.AddForce(xOOB * 2, 0, 0, ForceMode.Acceleration);
        }

        if ((yBounds < rb.transform.position.y) && rb.transform.position.y > bounds.transform.position.y)
        {
            //yOOB = yOOB * -1;
            rb.AddForce(0, -yOOB * 2, 0, ForceMode.Acceleration);
        }
        else if ((-yBounds > rb.transform.position.y) && rb.transform.position.y < bounds.transform.position.y)
        {
            rb.AddForce(0, yOOB * 2, 0, ForceMode.Acceleration);
        }

        if ((zBounds < rb.transform.position.z) && rb.transform.position.z > bounds.transform.position.z)
        {
            //zOOB = zOOB * -1;
            rb.AddForce(0, 0, -zOOB * 2, ForceMode.Acceleration);
        }
        else if ((-zBounds > rb.transform.position.z) && rb.transform.position.z < bounds.transform.position.z)
        {
            rb.AddForce(0, 0, zOOB * 2, ForceMode.Acceleration);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pullRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pushRange);
    }
}
