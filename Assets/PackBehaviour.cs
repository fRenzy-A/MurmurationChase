using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackBehaviour : MonoBehaviour
{
    public GameObject smools;
    public Rigidbody rb;
    public Transform puller;
    public SmoolsController smoolsController;
    public SphereCollider repelArea;
    public bool inSight;

    /*public int maxVelocity;*/


    public float mySpeed;

    /*public int pullMultiplier;
    public int pushMultiplier;*/

    /*public int pullXMult;
    public int pullYMult;
    public int pullZMult;*/

    public float xBounds;
    public float yBounds;
    public float zBounds;


    public float forceOfBounds;

    /*public int pullRange;
    public int pushRange;
    public bool outOfBounds;*/

    float xOOB; float yOOB; float zOOB;

    public Collider[] howMany;

    public Transform bounds;
    // Start is called before the first frame update

    private void Awake()
    {
        repelArea = GetComponent<SphereCollider>();
        smools = GameObject.Find("SpawnSmools");
        smoolsController = smools.GetComponent<SmoolsController>();
    }
    void Start()
    {
        
        xOOB = forceOfBounds; yOOB = forceOfBounds; zOOB = forceOfBounds;
        bounds = GameObject.FindWithTag("Push").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        //outOfBounds = false;

        rb.AddForce(Random.Range(1,10),Random.Range(1, 10), Random.Range(1, 10), ForceMode.Impulse);


        xBounds = (bounds.transform.localScale.x / 2) + bounds.transform.position.x;
        yBounds = (bounds.transform.localScale.y / 2) + bounds.transform.position.y;
        zBounds = (bounds.transform.localScale.z / 2) + bounds.transform.position.z;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //inSight = Physics.CheckSphere(transform.position, pushRange);

    }
    
    
    private void FixedUpdate()
    {
        //cap the maximum velocity/speed
        if ((rb.velocity.magnitude > smoolsController.MaxSpeedCap && rb.velocity.magnitude > 0) || (rb.velocity.magnitude > -smoolsController.MaxSpeedCap && rb.velocity.magnitude < 0))
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, smoolsController.MaxSpeedCap);
        }
        Collider[] inMyRadius = Physics.OverlapSphere(rb.transform.position,smoolsController.AttractRange);

        //Collider[] inMyPushRadius = Physics.OverlapSphere(rb.transform.position, pushRange);
        //howMany = inMyPushRadius;

        foreach (Collider c in inMyRadius)
        {
            if (c.CompareTag("Push"))
            {
                return;
            }
            else
            {
                float attX = (c.transform.position.x - rb.transform.position.x) * smoolsController.AttractMultiplier;
                float attY = (c.transform.position.y - rb.transform.position.y) * smoolsController.AttractMultiplier;
                float attZ = (c.transform.position.z - rb.transform.position.z) * smoolsController.AttractMultiplier;
                rb.AddForce(/*(c.transform.position - rb.transform.position)* smoolsController.AttractMultiplier*/ attX * smoolsController.AttractOffsetX, attY * smoolsController.AttractOffsetY,attZ * smoolsController.AttractOffsetZ, ForceMode.Acceleration);
            }
        }
        /*foreach (Collider d in inMyPushRadius)
        {
            if (d.CompareTag("Push"))
            {
                return;
            }
            else if (d.transform != d.transform.root)
            {
                Vector3 dir = d.transform.position - transform.position;
                dir = -dir;
                rb.AddForce(dir * pushAwayMultiplier, ForceMode.Force);
            }
            
            //else rb.AddForce(d.transform.position + rb.transform.position, ForceMode.Impulse);
        }*/
        ClampToBounds();
        repelArea.radius = smoolsController.RepelRange;
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Push"))
        {
            Vector3 dir = other.transform.position - transform.position;
            dir = -dir;
            rb.AddForce(dir * (smoolsController.RepelMultiplier), ForceMode.Force);
        }
    }
    private void OnDrawGizmosSelected()
    {
        /*Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, smoolsController.AttractRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, smoolsController.RepelRange);*/
    }
}
    