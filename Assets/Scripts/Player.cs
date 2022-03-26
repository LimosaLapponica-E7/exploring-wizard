using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D playerBody;
    public float moveSpeed = 5f;
    public Animator animator;

    Vector2 movement;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

   /*     animator.SetFloat("Horizonatal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);*/
    }

    private void FixedUpdate()
    {
        playerBody.MovePosition(playerBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
