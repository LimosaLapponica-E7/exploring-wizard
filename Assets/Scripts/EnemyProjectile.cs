using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    [SerializeField] private int dealSlimeDamagePoints;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("It Working");
            PlayerStats.instance.dealDamage(dealSlimeDamagePoints);
            DestroyProjectile();
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);



        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

    }



    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
