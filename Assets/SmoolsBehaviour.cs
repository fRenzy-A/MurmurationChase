using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoolsBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public SmoolsController smoolsController;
    public bool inSight;

    //just reference
    public float mySpeed;

    public float xBounds;
    public float yBounds;
    public float zBounds;

    //how much force will the bounds push objects back
    public float forceOfBounds;

    public bool inPullRange;
    public bool inPushRange;

    //For the bound clamper/ opaque sqaure
    float xOOB; float yOOB; float zOOB;

    public Transform bounds;
    // Start is called before the first frame update

    private void Awake()
    {
        
        
    }
    void Start()
    {
        smoolsController = GameObject.Find("SpawnSmools").GetComponent<SmoolsController>();
        inPullRange = false;
        inPushRange = false;

        xOOB = forceOfBounds; yOOB = forceOfBounds; zOOB = forceOfBounds;

        bounds = GameObject.FindWithTag("GoBack").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        //Just a safety net as the objects wont move with their velocity at 0 or no detection within their Attract/Repel radius
        rb.AddForce(Random.Range(50, 100), Random.Range(50, 100), Random.Range(50, 100), ForceMode.Impulse);

        //Takes the length of the opaque square
        xBounds = (bounds.transform.localScale.x / 2) + bounds.transform.position.x;
        yBounds = (bounds.transform.localScale.y / 2) + bounds.transform.position.y;
        zBounds = (bounds.transform.localScale.z / 2) + bounds.transform.position.z;
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    
    private void FixedUpdate()
    {
        
        //Cap the maximum velocity/speed
        if ((rb.velocity.magnitude > smoolsController.MaxSpeedCap && rb.velocity.magnitude > 0) || (rb.velocity.magnitude > -smoolsController.MaxSpeedCap && rb.velocity.magnitude < 0))
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, smoolsController.MaxSpeedCap);
        }

        //The Attract/Repel radius respectively. Whatever object crosses whichever radius will be stored in an array and will do whatever is coded below
        //If a cleaner solution is possible, recoding is recommended

        //The compare tag is there for the objects not to detect the opaque square which has a "GoBack" tag

        Collider[] inMyPullRadius = Physics.OverlapSphere(rb.transform.position, smoolsController.AttractRange);
        Collider[] inMyPushRadius = Physics.OverlapSphere(rb.transform.position, smoolsController.RepelRange);

        foreach (Collider c in inMyPullRadius)
        {
            if (c.CompareTag("GoBack"))
            {
                return;
            }
            else if(transform != c.transform.root)
            {
                inPullRange = true;
            }
            InPullRadius(c);
        }
        foreach (Collider d in inMyPushRadius)
        {
            if (d.CompareTag("GoBack"))
            {
                return;
            }
            else if (transform != d.transform.root)
            {
                inPushRange = true;
            }
            InPushRadius(d);
        }
        ClampToBounds();
    }

    //When an object hits the Attract Radius
    public void InPullRadius(Collider c)
    {
        if (inPullRange)
        {
            rb.AddForce((c.transform.position - rb.transform.position)* smoolsController.AttractMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(0, 0, 0);
        }
        
    }

    //When an object hits the Repel Radius
    public void InPushRadius(Collider d)
    {
        if (inPushRange)
        {
            //this bool change is to specifically cancel the Attract Range so it wont conflict with the Repel Range
            inPullRange = false;
            Vector3 dir = d.transform.position - transform.position;
            rb.AddForce((smoolsController.RepelMultiplier * -dir) * 2, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(0, 0, 0);
        }
            
        
    }

    //To make the objects stay in a designated area, ie. the opaque square. Each if and else if statements corrolate to each axis.
    private void ClampToBounds()
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
        //Editor gizmos
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, smoolsController.AttractRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, smoolsController.RepelRange);
    }
}
    