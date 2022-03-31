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

    private void Awake()
    {
        if(playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {

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
            Player.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
