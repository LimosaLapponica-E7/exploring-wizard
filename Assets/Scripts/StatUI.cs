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

    int enemyDefeatCount;
    void Start()
    {
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

    public void UpdateEnemyDefeatCount()
    {
        enemyDefeatCount++;
        print(enemyDefeatCount);
        enemiesKilled.text = "Enemies Defeated: " + enemyDefeatCount;
    }

    public void UponPlayerDeathDisplayUI()
    {
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
