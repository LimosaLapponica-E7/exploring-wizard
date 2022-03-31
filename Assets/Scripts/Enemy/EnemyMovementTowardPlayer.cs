using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementTowardPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    // Enemy Movement
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan(direction.x) * Mathf.Rad2Deg;
        movement = direction;
        if(direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        moveTowardPlayer(movement);
    }
    void moveTowardPlayer(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
