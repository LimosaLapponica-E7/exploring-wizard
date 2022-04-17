using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StatUI : MonoBehaviour
{


    [SerializeField] private TMP_Text levelNumber;
    [SerializeField] private TMP_Text gold;
    [SerializeField] private TMP_Text enemiesKilled;

    public GameObject restartButton;
    public GameObject uponDeathUI;
    public GameObject playerHealthBar;

    static int enemyDefeatCount;
    static int playerLevel;

    void Start()
    {
        enemyDefeatCount = 0;
        uponDeathUI.SetActive(false);
    }
    public void UpdateLevelNumber()
    {
        playerLevel++;
        levelNumber.text = "Level:" + getPlayerLevel();
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
        uponDeathUI.SetActive(true);
        playerHealthBar.SetActive(false);
        restartButton.SetActive(true);
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        uponDeathUI.SetActive(false);
        restartButton.SetActive(false);
    }
}
