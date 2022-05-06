using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    private Vector2 movementVector = Vector3.zero;
    [SerializeField] private int dealSlimeDamagePoints;
    private float timeSinceInstantiation;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceInstantiation = 0;
        
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            movementVector = (player.position - transform.position).normalized * speed;
            //target = new Vector2(player.position.x, player.position.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats.instance.dealDamage(dealSlimeDamagePoints);
            EnemyBulletHit.instance.playSound();
            Destroy(gameObject);
        }
    
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy")
             Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        timeSinceInstantiation += Time.deltaTime;
        transform.position += (Vector3)movementVector * Time.deltaTime;
        //movementVector = (target.position - transform.position).normalized * speed;
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //if (transform.position.x == target.x && transform.position.y == target.y)
        if(timeSinceInstantiation > 15)
        {
            DestroyProjectile();
        }

    }



    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
