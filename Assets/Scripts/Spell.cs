using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameObject projectile;
    public GameObject spell;

    public float minDamage;
    public float maxDamage;

    public float projectileForce;
    public float spellForce;

    private float timesincespell = 0.0f;
    private float secondspershot = 0.2f;  

    // Update is called once per frame
    void Update()
    {
        //reverse projectile
        timesincespell += Time.deltaTime;
        if (Input.GetKeyDown("space")) //GetKeyDown instead of GetKey so that you have to perform a full press
        {
            GameObject projectileRear = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;
            projectileRear.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
          //  spell.GetComponent<Bullet>().damage = Random.Range(minDamage, maxDamage);
        }

        //spells, you can aim these more easily
        if (timesincespell > secondspershot){
            if (Input.GetKeyDown("right"))
            {
                GameObject spellRight = Instantiate(spell, transform.position, Quaternion.identity);
                spellRight.GetComponent<Rigidbody2D>().velocity = new Vector2(spellForce, 0);
                timesincespell = 0;
            }
            if (Input.GetKeyDown("left"))
            {
                GameObject spellLeft = Instantiate(spell, transform.position, Quaternion.identity);
                spellLeft.GetComponent<Rigidbody2D>().velocity = new Vector2(spellForce * -1, 0);
                timesincespell = 0;
            }

            if (Input.GetKeyDown("up"))
            {
                GameObject spellUp = Instantiate(spell, transform.position, Quaternion.identity);
                spellUp.GetComponent<Rigidbody2D>().velocity = new Vector2(0, spellForce);
                timesincespell = 0;
            }

            if (Input.GetKeyDown("down"))
            {
                GameObject spellDown = Instantiate(spell, transform.position, Quaternion.identity);
                spellDown.GetComponent<Rigidbody2D>().velocity = new Vector2(0, spellForce * -1);
                timesincespell = 0;
            }
        }

    }
}

