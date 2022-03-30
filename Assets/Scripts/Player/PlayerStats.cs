using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject Player;

    public float health;
    public float maxHealth;

    public int gold;
    public int potion;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void dealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

    public void healCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
