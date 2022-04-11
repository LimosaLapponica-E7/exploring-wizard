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

    private int enemyDefeatCount;

    public StatUI callStatUI;

    public GameObject lootDrop;
    // Start is called before the first frame update
    void Start()
    {
        callStatUI = GameObject.FindObjectOfType(typeof(StatUI)) as StatUI;
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
            Destroy(gameObject);
            Instantiate(lootDrop, transform.position, Quaternion.identity);
            enemyDefeatCount++;
            callStatUI.ShowEnemyDefeatCount(enemyDefeatCount);
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
}
