using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 4;
    float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    Vector2 movement;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Vertical");
        inputVertical = Input.GetAxisRaw("Horizontal");
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
            rb.velocity = new Vector2(inputHorizontal * moveSpeed, inputHorizontal * moveSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }
}
