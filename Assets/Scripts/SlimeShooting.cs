using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeShooting : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position != null)
        {
            Vector2 playerPosition = player.position;
            if (Vector2.Distance(transform.position, playerPosition) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
                gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            }
            else if (Vector2.Distance(transform.position, playerPosition) < stoppingDistance && Vector2.Distance(transform.position, playerPosition) > retreatDistance)
            {
                transform.position = this.transform.position;
                gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            }
            else if (Vector2.Distance(transform.position, playerPosition) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPosition, -speed * Time.deltaTime);
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            }

            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
