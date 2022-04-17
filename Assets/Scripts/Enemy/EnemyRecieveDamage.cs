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

    public GameObject lootDrop;

    public GameObject potionDrop;

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
    float num;
    private void CheckDeath()
    {
        if (health <= 0)
        {
            if (Random.Range(0, 6) == num)
            {
                Reward(potionDrop);
            }
            else
            {
                Reward(lootDrop);
            }

        }
    }


    private void Reward(GameObject playerReward)
    {
        StatUI.UpdateEnemyDefeatCount();
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(gameObject, 0.55f);
        StartCoroutine(slimeTremble());
        StartCoroutine(Wait(0.5f, playerReward));
    }

    IEnumerator slimeTremble()
    {
        // Based on https://stackoverflow.com/a/65242499
        for (int i = 0; i < 5; i++)
        {
            transform.localPosition += new Vector3(0.1f, 0.1f, 0);
            yield return new WaitForSeconds(0.1f);
            transform.localPosition -= new Vector3(0.1f, 0.1f, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }


    IEnumerator Wait(float seconds, GameObject playerReward)
    {
        yield return new WaitForSeconds(seconds);
        Instantiate(playerReward, transform.position, Quaternion.identity);
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
}
