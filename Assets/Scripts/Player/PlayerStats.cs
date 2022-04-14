using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public GameObject Player;

    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public Slider healthBarSlider;

    public int gold;
    public int potion;

    public GameObject StatUI;

    void Start()
    {
        gold = 0;
        health = maxHealth;
    }
    private void Awake()
    {
            instance = this;
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

    public void giveGold(float gold)
    {
        gold = gold + 5;
        StatUI.GetComponent<StatUI>().UpdateGoldNumber(gold);
        Debug.Log("Give Gold Got Calld");
        print(gold);
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
                Player.SetActive(false);

           StatUI.GetComponent<StatUI>().UponPlayerDeathDisplayUI();
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
