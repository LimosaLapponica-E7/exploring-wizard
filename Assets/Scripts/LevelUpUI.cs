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
        SetUIActive(true);
    }

    public void buyBombTest()
    {
        PlayerStats.instance.buyBomb();
    }


    private void SetUIActive(bool isActive)
    {
        uponLevelUpUI.SetActive(isActive);
        Time.timeScale = isActive ? 0 : 1;
    }

    public void IncreaseMovementSpeed()
    {
        Player.instance.IncreaseMovementSpeed();
        SetUIActive(false);

    }

    // Currently not working need to set up in the Player or Spell Script
    public void IncreaseAttackSpeed()
    {
        /*Spell.IncreaseAttackSpeed();*/
        SetUIActive(false);
    }

    public void IncreaseHealth()
    {
        PlayerStats.instance.IncreaseHealth();
        SetUIActive(false);
    }

    // Currently not working need to set up in the Player or Spell Script
    public void IncreaseDamage()
    {
        Bullet.instance.IncreaseDamage();
        SetUIActive(false);
    }
}
