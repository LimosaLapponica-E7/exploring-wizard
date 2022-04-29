using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    [SerializeField] private AudioSource LevelUpSound;
    public GameObject Player;
    public int playerLevel;

    public float health;
    public float maxHealth;

    public float experience;
    public float maxExperience;

    public float goldNumber;
    public float bombNumber;
    public int potion;

    public GameObject healthBar;
    public Slider healthBarSlider;

    public GameObject experienceBar;
    public Slider experienceSlider;

    public GameObject StatUI;
    public GameObject BombUI;
    public GameObject LevelUpUI;

    AudioSource LevelupSound;
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

    void Update()
    {
        StatUI.GetComponent<StatUI>().CheckPause();
    }

    public void dealDamage(int damage)
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

    public void buyBomb()
    {
        
        if (goldNumber >= 10)
        {
            bombNumber++;
            goldNumber = goldNumber - 10f;
            updateGoldCount();
        }
   
    }

    public void useBomb()
    {
        bombNumber--;
        BombUI.GetComponent<BombUI>().UpdateBombNumber(bombNumber);
    }
    public void giveGold(float gold)
    {
        goldNumber = goldNumber + gold;
        updateGoldCount();
    }

    private void updateGoldCount()
    {
        StatUI.GetComponent<StatUI>().UpdateGoldNumber(goldNumber);
        BombUI.GetComponent<BombUI>().UpdateGold(goldNumber);
        BombUI.GetComponent<BombUI>().UpdateBombNumber(bombNumber);

    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Player.SetActive(false);
            StatUI.GetComponent<StatUI>().UponPlayerDeathDisplayUI();
        }
    }
    public void IncreaseHealth()
    {
        maxHealth = maxHealth + 5f;
        Debug.Log("Max Health increased " + maxHealth);
    }
    private void CheckLevelUp()
    {
        if (experience >= maxExperience)
        {
            StatUI.GetComponent<StatUI>().UpdateLevelNumber();
            LevelUpUI.GetComponent<LevelUpUI>().ShowLevelUpUI();
            experience = 0;
            maxExperience = maxExperience * 1.25f;
            playerLevel++;
            BombUI.GetComponent<BombUI>().UpdateLevelNumber(playerLevel);
            bombNumber++;
            updateGoldCount();
            LevelUpSound.Play();

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
}
