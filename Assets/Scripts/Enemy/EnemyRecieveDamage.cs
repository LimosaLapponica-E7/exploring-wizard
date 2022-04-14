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

    [SerializeField] private GameObject enemy;

    public GameObject lootDrop;

    // Start is called before the first frame update
    int enemyDefeatCount;
    void Start()
    {
        enemyDefeatCount = 0;
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
            Debug.Log("Enemy health 0");
            Instantiate(lootDrop, transform.position, Quaternion.identity);
            GameObject.Find("Stats Player Death UI").GetComponent<StatUI>().UponPlayerDeathDisplayUI();
            Destroy(enemy);
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
}
