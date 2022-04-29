using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombUI : MonoBehaviour
{
    [SerializeField] private TMP_Text levelNumber;
    [SerializeField] private TMP_Text bombCounter;
    [SerializeField] private TMP_Text goldNumber;

    private void Update()
        {

        }

    public void UpdateLevelNumber(float count)
    {
        levelNumber.text = "Level: " + count;
    }
    public void UpdateBombNumber(float count)
    {
        bombCounter.text = ":  " + count;
    }

    public void UpdateGold(float count)
    {
        goldNumber.text = ":  " + count;
    }
}
