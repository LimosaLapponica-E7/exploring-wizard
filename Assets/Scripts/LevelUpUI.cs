using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    public GameObject uponLevelUpUI;
    // Start is called before the first frame update
    void Start()
    {
        uponLevelUpUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowLevelUpUI()
    {
        uponLevelUpUI.SetActive(true);
    }
    public void IncreaseMovementSpeed()
    {
        Player.instance.IncreaseMovementSpeed();
        uponLevelUpUI.SetActive(false);
    }

    // Currently not working need to set up in the Player or Spell Script
    public void IncreaseAttackSpeed()
    {
        Player.instance.IncreaseAttackSpeed();
        uponLevelUpUI.SetActive(false);
    }

    public void IncreaseHealth()
    {
        PlayerStats.instance.IncreaseHealth();
        uponLevelUpUI.SetActive(false);
    }

    // Currently not working need to set up in the Player or Spell Script
    public void IncreaseDamage()
    {
        uponLevelUpUI.SetActive(false);
    }
}
