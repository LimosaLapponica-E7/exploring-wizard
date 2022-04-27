using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombUI : MonoBehaviour
{
    [SerializeField] private TMP_Text bombCounter;

    private void Update()
        {

        }

    public void UpdateBombCounter(float count)
    {
        bombCounter.text = "-" + count;
    }
}
