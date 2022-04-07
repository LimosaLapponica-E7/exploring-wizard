using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{
    [SerializeField] public GameObject flockUnit;
    [SerializeField] public int numUnits;
    public GameObject[] allUnits;
    public Vector2 flockLimits = new Vector2(5, 5);

    // Start is called before the first frame update
    void Start()
    {
        // allUnits = new GameObject[numUnits];
        // for(int i = 0; i < numUnits; i++)
        // {
        //     Vector2 pos = this.transform.position + new Vector2(Random.Range(0, 5),
        //                                                 Vector2(Random.Range(0, 5)));
        //     allUnits[i] = (GameObject) Instantiate(flockUnit, pos, Quaternion.identity);
                                                        
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
