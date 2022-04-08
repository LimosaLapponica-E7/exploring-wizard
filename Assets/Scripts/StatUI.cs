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

    void Start()
    {
        uponDeathUI.SetActive(false);
    }
    public void updateLevelNumber(float count)
    {
        levelNumber.text = "Level:" + count;
    }

    public void UpdateGoldNumber(float count)
    {
        gold.text = "Enemies Defeated: " + count;
    }

    public void ShowEnemyDefeatCount(float count)
    {
        enemiesKilled.text = "Enemies Defeated: " + count;
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
    }
}
