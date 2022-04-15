using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Rigidbody2D playerBody;
    [SerializeField] private AudioSource playerHitSound;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slime"){
            PlayerStats.instance.dealDamage(5f);
            playerHitSound.Play();
        }
        if (collision.gameObject.tag == "Obstacle"){
            PlayerStats.instance.dealDamage(2f);
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "Gold")
        {
            PlayerStats.instance.giveGold(5);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Health")
        {
            PlayerStats.instance.healCharacter(5);
            Destroy(gameObject);
        }
    }
}
