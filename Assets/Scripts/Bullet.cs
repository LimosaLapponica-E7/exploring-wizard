using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.GetComponent<EnemyRecieveDamage>() != null)
            {
            print(collision.name);
                collision.GetComponent<EnemyRecieveDamage>().DealDamage(damage);
            }
            else
            {
            Debug.Log("Thing Died");
                Destroy(gameObject);
            }
    }
}
