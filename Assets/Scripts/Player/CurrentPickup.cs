using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPickup : MonoBehaviour
{
    public enum PickupObject { GOLD, POTION };

    public PickupObject currentObject;
    public int pickupQuantity;
    AudioSource rewardSound;

    [SerializeField] private GameObject item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (currentObject == PickupObject.GOLD)
            {
                PlayerStats.instance.giveGold(5f);
            }
            if (currentObject == PickupObject.POTION)
            {
                PlayerStats.instance.healCharacter(10f);
                Destroy(gameObject);
            }
            rewardSound = GameObject.Find("Reward Sound").GetComponent<AudioSource>();
            rewardSound.Play();
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
