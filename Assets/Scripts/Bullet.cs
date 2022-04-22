using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    [SerializeField] private GameObject bullet;
    public static Bullet instance;

     void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyRecieveDamage>() != null)
        {
            collision.GetComponent<EnemyRecieveDamage>().DealDamage(damage);
        }
        Destroy(bullet);
    }

    public void IncreaseDamage()
    {
        damage++;
    }
}
