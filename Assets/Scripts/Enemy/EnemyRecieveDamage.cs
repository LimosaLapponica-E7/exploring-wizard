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
    float six;
    private void CheckDeath()
    {
        if (health <= 0)
        {
            
            if (Random.Range(0,6) == six)
            {
                Instantiate(potionDrop, transform.position, Quaternion.identity);
                Debug.Log("Instantiated Potion");
            }
            else
            {
                Instantiate(lootDrop, transform.position, Quaternion.identity);
            }
            StatUI.UpdateEnemyDefeatCount();
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject, 0.55f);
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            StartCoroutine(slimeTremble());
        }
    }

    IEnumerator slimeTremble()
    {
        // Based on https://stackoverflow.com/a/65242499
        for (int i = 0; i < 5; i++)
        {
            transform.localPosition += new Vector3(0.07f, 0.07f, 0);
            yield return new WaitForSeconds(0.006f);
            transform.localPosition -= new Vector3(0.07f, 0.07f, 0);
            yield return new WaitForSeconds(0.006f);
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
}
