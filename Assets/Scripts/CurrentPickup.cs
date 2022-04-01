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

        Debug.Log("Collision!");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Collision!");
            if (currentObject == PickupObject.GOLD)
            {
                PlayerStats.playerStats.gold += pickupQuantity;
                Debug.Log(PlayerStats.playerStats.gold);
            }
            else if (currentObject == PickupObject.POTION)
            {
                PlayerStats.playerStats.potion += pickupQuantity;
                Debug.Log(PlayerStats.playerStats.potion);
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
