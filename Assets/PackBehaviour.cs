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

    public Transform bounds;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        bounds = GameObject.FindWithTag("Push").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        outOfBounds = false;
        rb.AddForce(Random.Range(5,10),0,0/*Random.Range(1, 10), Random.Range(1, 10)*/, ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        inSight = Physics.CheckSphere(transform.position, range);
    }
    
    
    private void FixedUpdate()
    {
        //x = rb.velocity.x;//; y = rb.velocity.y; z = rb.velocity.z;
        mySpeed = rb.velocity.magnitude;
        if ((rb.velocity.magnitude > myVelocity && rb.velocity.magnitude > 0) || (rb.velocity.magnitude > -myVelocity && rb.velocity.magnitude < 0))
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, myVelocity);
        }
        Bounds();
        /*if (outOfBounds)
        {
            if (((bounds.transform.localScale.x < rb.transform.position.x) && rb.transform.position.x > 0) || ((-bounds.transform.localScale.x > rb.transform.position.x) && rb.transform.position.x < 0))
            {
                
            }
            if (((bounds.transform.localScale.y < rb.transform.position.y) && rb.transform.position.y > 0) || ((-bounds.transform.localScale.y > rb.transform.position.y) && rb.transform.position.y < 0))
            {
                
            }
            if (((bounds.transform.localScale.z < rb.transform.position.z) && rb.transform.position.z > 0) || ((-bounds.transform.localScale.z > rb.transform.position.z) && rb.transform.position.z < 0))
            {
                
            }
            // rb.AddForce(x * 2, y *2, z * 2);
        }*/
 
    }

    private void Bounds()
    {
        float xBounds;
        float yBounds;
        float zBounds;
        if (((bounds.transform.localScale.x < rb.transform.position.x) && rb.transform.position.x > 0) || ((-bounds.transform.localScale.x > rb.transform.position.x) && rb.transform.position.x < 0))
        {
            xBounds = rb.velocity.x * -1;
            //xBounds = x;
            if (((xBounds < x)&& xBounds > 0)|| ((-xBounds < x)&& xBounds <0))
            {
                
            }
            rb.AddForce(x * 2, 0, 0);

        }
        if (((bounds.transform.localScale.y < rb.transform.position.y) && rb.transform.position.y > 0) || ((-bounds.transform.localScale.y > rb.transform.position.y) && rb.transform.position.y < 0))
        {
            y = rb.velocity.y * -1;
            rb.AddForce(0, y * 2, 0);
        }
        if (((bounds.transform.localScale.z < rb.transform.position.z) && rb.transform.position.z > 0) || ((-bounds.transform.localScale.z > rb.transform.position.z) && rb.transform.position.z < 0))
        {
            z = rb.velocity.z * -1;
            rb.AddForce(0, 0, z * 2);
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
        outOfBounds = true;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    }
}
