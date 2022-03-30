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
                collision.GetComponent<EnemyRecieveDamage>().DealDamage(damage);
            }
            else
            {
                Destroy(gameObject);
            }
    }
}
