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
    [SerializeField] private TMP_Text attackSpeed;

    public GameObject restartButton;
    public GameObject uponDeathUI;
    public GameObject playerHealthBar;

    static int enemyDefeatCount;
    void Start()
    {
        enemyDefeatCount = 0;
        uponDeathUI.SetActive(false);
    }
    public void UpdateLevelNumber(float count)
    {
        levelNumber.text = "Level:" + count;
    }

    public void UpdateGoldNumber(float count)
    {
        gold.text = "Gold Attained: " + count;
    }

    public static void UpdateEnemyDefeatCount()
    {
        enemyDefeatCount++;        
    }

    int getEnemyDefeatCount() {
        return enemyDefeatCount;
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
