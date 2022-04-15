using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementTowardPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    // Enemy Movement
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private float timesinceflip = 0.0f;

    Transform player;
    void Start()
    {
       rb = this.GetComponent<Rigidbody2D>();
       player = (GameObject.Find("Player")).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timesinceflip += Time.deltaTime;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan(direction.x) * Mathf.Rad2Deg;
        movement = direction;
        if(direction.x < 0 && timesinceflip > 0.33)
        {
            spriteRenderer.flipX = true;
            timesinceflip = 0;
        }
        if(direction.x > 0 && timesinceflip > 0.33)
        {
            spriteRenderer.flipX = false;
            timesinceflip = 0;
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
