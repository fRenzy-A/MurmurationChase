using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoundClamps : MonoBehaviour
{
    // Start is called before the first frame update
    public float clampX;
    public float clampY;
    public float clampZ;

    public float clampBoundForce;
    void Start()
    {
        clampX = (transform.localScale.x / 2) + transform.position.x;
        clampY = (transform.localScale.y / 2) + transform.position.y;
        clampZ = (transform.localScale.z / 2) + transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] outOfBounds = Physics.OverlapBox(transform.position, transform.localScale);

        /*foreach (Collider smoolCollider in outOfBounds)
        {
            if ((clampX < smoolCollider.transform.position.x) && smoolCollider.transform.position.x > transform.position.x)
            {
                //xOOB = xOOB * -1;
                smoolCollider.AddForce(-xOOB * 2, 0, 0, ForceMode.Acceleration);
            }
            else if ((-clampX > rb.transform.position.x) && rb.transform.position.x < bounds.transform.position.x)
            {
                //xOOB = xOOB * -1;
                rb.AddForce(xOOB * 2, 0, 0, ForceMode.Acceleration);
            }

            if ((clampY < rb.transform.position.y) && rb.transform.position.y > bounds.transform.position.y)
            {
                //yOOB = yOOB * -1;
                rb.AddForce(0, -yOOB * 2, 0, ForceMode.Acceleration);
            }
            else if ((-clampY > rb.transform.position.y) && rb.transform.position.y < bounds.transform.position.y)
            {
                rb.AddForce(0, yOOB * 2, 0, ForceMode.Acceleration);
            }

            if ((clampZ < rb.transform.position.z) && rb.transform.position.z > bounds.transform.position.z)
            {
                //zOOB = zOOB * -1;
                rb.AddForce(0, 0, -zOOB * 2, ForceMode.Acceleration);
            }
            else if ((-clampZ > rb.transform.position.z) && rb.transform.position.z < bounds.transform.position.z)
            {
                rb.AddForce(0, 0, zOOB * 2, ForceMode.Acceleration);
            }
        }*/
    }
}
