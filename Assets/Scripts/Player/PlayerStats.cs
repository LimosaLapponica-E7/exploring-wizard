using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject Player;

    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public Slider healthBarSlider;

    public int gold;
    public int potion;

    private void Awake()
    {
     
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }

    public void dealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        healthBarSlider.value = CalculateHealthPercentage();
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

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
