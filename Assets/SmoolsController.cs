using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoolsController : MonoBehaviour
{
    public GameObject smoolsPrefab;
    GameObject[] Smools;
    public int SmoolsCount;
    public PackBehaviour smoolsBehaviour;


    public int MaxSpeedCap;

    public int AttractMultiplier;
    public int RepelMultiplier;
    public int AttractRange;
    public int RepelRange;

    public int AttractOffsetX;
    public int AttractOffsetY;
    public int AttractOffsetZ;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SmoolsCount; i++)
        {
            Vector3 randomPlace = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
            Instantiate(smoolsPrefab, randomPlace, Quaternion.identity);
           // Smools[i] = 
            // Smools[i] = smoolsPrefab;
        }
        smoolsBehaviour = smoolsPrefab.GetComponent<PackBehaviour>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        /*smoolsBehaviour.maxVelocity = MaxSpeedCap;
        smoolsBehaviour.pullMultiplier = AttractMultiplier;
        smoolsBehaviour.pullMultiplier = RepelMultiplier;
        smoolsBehaviour.pullRange = AttractRange;
        smoolsBehaviour.pullRange = RepelRange;

        smoolsBehaviour.pullXMult = AttractOffsetX;
        smoolsBehaviour.pullYMult = AttractOffsetY;
        smoolsBehaviour.pullZMult = AttractOffsetZ;*/
    }
}
