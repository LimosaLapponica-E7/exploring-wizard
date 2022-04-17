using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public GameObject Player;

    public float playerLevel;

    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public Slider healthBarSlider;

    public GameObject experienceBar;
    public Slider experienceSlider;

    public float experience;
    public float maxExperience;

    public float goldNumber;
    public int potion;

    public GameObject StatUI;
    void Start()
    {
        goldNumber = 0;
        experience = 0;
        health = maxHealth;
        experienceSlider.value = CalculateExperiencePercentage();
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
        healthBarSlider.value = CalculateHealthPercentage();
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
        goldNumber = goldNumber + gold;
        StatUI.GetComponent<StatUI>().UpdateGoldNumber(goldNumber);
    }


    private void CheckDeath()
    {
        if (health <= 0)
        {
                Player.SetActive(false);

           StatUI.GetComponent<StatUI>().UponPlayerDeathDisplayUI();
        }
    }

    private void CheckLevelUp()
    {
        if (experience >= maxExperience)
        {
            playerLevel++;
            experience = 0;
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }


    public void addExperience(float ep)
    {
        experience += ep;
        CheckLevelUp();
        experienceSlider.value = CalculateExperiencePercentage();
    }
    private float CalculateExperiencePercentage()
    {
        return (experience / maxExperience);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
