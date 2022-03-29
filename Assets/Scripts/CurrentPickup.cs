using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPickup : MonoBehaviour
{
    public enum PickupObject {GOLD,POTION};
    public PickupObject currentObject;
    public int pickupQuantity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            if(currentObject == PickupObject.GOLD)
            {
                PlayerStats.playerStats.gold += pickupQuantity;
                Debug.Log(PlayerStats.playerStats.gold);
            }
            else if(currentObject == PickupObject.POTION)
            {
                PlayerStats.playerStats.potion += pickupQuantity;
                Debug.Log(PlayerStats.playerStats.potion);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
