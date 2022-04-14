using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPickup : MonoBehaviour
{
    public enum PickupObject {GOLD,POTION};

    public PickupObject currentObject;
    public int pickupQuantity;


    [SerializeField] private GameObject item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (currentObject == PickupObject.GOLD)
            {
                PlayerStats.instance.giveGold(5);
                Debug.Log("Current Pickup call giveGold");
            }
            else if (currentObject == PickupObject.POTION)
            {
                PlayerStats.instance.potion += pickupQuantity;
            }

            Destroy(item);
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
