using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Rigidbody2D playerBody;
    float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    public static Player instance;

    void Awake()
    {
        instance = this;
    } 

 

    void Start()
    {
    
    }
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
       
        if (inputHorizontal != 0 || inputVertical != 0 )
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }
            playerBody.velocity = new Vector2(inputHorizontal * moveSpeed, inputVertical * moveSpeed);
        }
        else
        {
            playerBody.velocity = new Vector2(0f, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime"){
            PlayerStats.playerStats.dealDamage(5f);
        }
    }
}
