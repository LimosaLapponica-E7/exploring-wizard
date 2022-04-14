using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRecieveDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public Slider healthBarSlider;

    public int enemyDefeatCount;

    public GameObject lootDrop;

    public GameObject StatUI;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        health -= damage;
        CheckDeath();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Instantiate(lootDrop, transform.position, Quaternion.identity);
            enemyDefeatCount++;
            StatUI.GetComponent<StatUI>().ShowEnemyDefeatCount(enemyDefeatCount);
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
}
