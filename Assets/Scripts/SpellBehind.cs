using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehind : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) //GetKeyDown instead of GetKey so that you have to perform a full press
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
          //  spell.GetComponent<Bullet>().damage = Random.Range(minDamage, maxDamage);
        }
    }
}
