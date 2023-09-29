using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoolsController : MonoBehaviour
{
    public GameObject smoolsPrefab;
    public int SmoolsCount;
    public SmoolsBehaviour smoolsBehaviour;


    public float MaxSpeedCap;

    public float AttractMultiplier;
    public float RepelMultiplier;
    public float AttractRange;
    public float RepelRange;

    public int AttractOffsetX;
    public int AttractOffsetY;
    public int AttractOffsetZ;
    // Start is called before the first frame update
    void Start()
    {
        //At the start of the game, it spawns the objects
        for (int i = 0; i < SmoolsCount; i++)
        {
            Vector3 randomPlace = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
            Instantiate(smoolsPrefab, randomPlace, Quaternion.identity);

        }
        smoolsBehaviour = smoolsPrefab.GetComponent<SmoolsBehaviour>();
        
    }

}
