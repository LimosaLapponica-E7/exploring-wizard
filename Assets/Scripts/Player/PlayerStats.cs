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
    public AudioSource[] backgroundMusic;

    AudioSource LevelupSound;
    void Start()
    {
        backgroundMusic[0].Play();
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
            StatUI.GetComponent<StatUI>().UponPlayerDeathDisplayUI(true);
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
            experience = 0;
            StartCoroutine(FadeOutLevelUp(backgroundMusic
            [(PlayerStats.instance.playerLevel) % backgroundMusic.Length], 3f));
        }
    }

    // Based on https://forum.unity.com/threads/fade-out-audio-source.335031/
    IEnumerator FadeOutLevelUp(AudioSource music, float FadeTime)
    {
        float startVolume = music.volume;

        while (music.volume > 0)
        {
            music.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }

        music.Stop();
        music.volume = startVolume;
        LevelUpSound.Play();
        StatUI.GetComponent<StatUI>().UpdateLevelNumber();
        LevelUpUI.GetComponent<LevelUpUI>().ShowLevelUpUI();
        maxExperience = maxExperience * 1.25f;
        playerLevel++;
        BombUI.GetComponent<BombUI>().UpdateLevelNumber(playerLevel);
        bombNumber++;
        updateGoldCount();
        backgroundMusic[PlayerStats.instance.playerLevel % backgroundMusic.Length].Play();
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
