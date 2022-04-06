using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class StatUI : MonoBehaviour
{


    [SerializeField] private TMP_Text waveNumber;
    [SerializeField] private TMP_Text gold;
    [SerializeField] private TMP_Text attackSpeed;
    [SerializeField] private TMP_Text enemiesKilled;

    public void ShowEnemyDefeatCount(float count)
    {
        enemiesKilled.text = "Enemies Defeated: " + count;
    }
}
