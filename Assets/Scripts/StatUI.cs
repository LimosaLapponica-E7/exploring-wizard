using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StatUI : MonoBehaviour
{
    [SerializeField] private TMP_Text levelNumberUI;
    [SerializeField] private TMP_Text levelNumber;
    [SerializeField] private TMP_Text gold;
    [SerializeField] private TMP_Text enemiesKilled;
    [SerializeField] private TMP_Text movementSpeed;
    [SerializeField] private TMP_Text attackSpeed;
    [SerializeField] private TMP_Text health;
    [SerializeField] private TMP_Text damage;

    public GameObject restartButton;
    public GameObject uponDeathUI;
    public GameObject playerHealthBar;

    static int moveSpeedStat;
    static int attackSpeedStat;
    static int healthStat;
    static int damageStat;

    static int enemyDefeatCount;
    static int playerLevel;

    public bool game_paused;
    void Start()
    {
        enemyDefeatCount = 0;
        uponDeathUI.SetActive(false);
        game_paused = false;
    }

    public void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            game_paused = !game_paused;
            Time.timeScale = game_paused ? 0 : 1;
            UponPlayerDeathDisplayUI();
        }
    }

    public void UpdateLevelNumber()
    {
        playerLevel++;
        levelNumberUI.text = "" + getPlayerLevel();
        levelNumber.text = "Level:" + getPlayerLevel();
        Debug.Log("Player Level" + playerLevel);
    }

    public void UpdateGoldNumber(float count)
    {
        gold.text = "Gold Attained: " + count;
    }

    public static void UpdateEnemyDefeatCount()
    {
        enemyDefeatCount++;
        PlayerStats.instance.addExperience(5);
    }

    public void UpdateMovementSpeed()
    {
        moveSpeedStat++;
        movementSpeed.text = "Movement Speed:" + " " + moveSpeedStat;
    }
    public void UpdateAttackSpeed()
    {
        attackSpeedStat++;
        movementSpeed.text = "Attack Speed:" + " " + attackSpeedStat++; ;
    }
    public void UpdateHealth()
    {
        healthStat++;
        health.text = "Health:" + " " + healthStat;
    }
    public void UpdateDamage()
    {
        damageStat++;
        movementSpeed.text = "Damage:" + " " + damageStat;
    }

    int getEnemyDefeatCount() {
        return enemyDefeatCount;
    }

    int getPlayerLevel()
    {
        return playerLevel;
    }

    public void UponPlayerDeathDisplayUI()
    {
        enemiesKilled.text = "Enemies Defeated: " + getEnemyDefeatCount();;
        uponDeathUI.SetActive(game_paused);
        restartButton.SetActive(game_paused);
    }

/*    private void SetUIActive(bool game_paused)
    {
        uponDeathUI.SetActive(game_paused);
        Time.timeScale = game_paused ? 0 : 1;
    }*/
    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        uponDeathUI.SetActive(false);
        restartButton.SetActive(false);
    }
}
