using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameObject bomb;
    public GameObject spell;

    public float minDamage;
    public float maxDamage;

    public float projectileForce;
    public float spellForce;

    private float timesincespell = 0.0f;

    [SerializeField]
    [Range(0f,5f)]
    float secondspershot = .75f;

    [SerializeField] private AudioSource fireSound;
    [SerializeField] private AudioSource fireInPlaceSound;
    void Start()
    {
        secondspershot = .75f;
    }

    // Update is called once per frame
    void Update()
    {
        //reverse projectile

        timesincespell += Time.deltaTime;
        if (Input.GetKeyDown("space")) //GetKeyDown instead of GetKey so that you have to perform a full press
        {
            Vector2 myPos = transform.position;
            DropBomb();
        }


        //spells, you can aim these more easily
        if (timesincespell > secondspershot)
        {

            if (Input.GetKeyDown("right"))
            {
                Fire(new Vector2(spellForce, 0));
                timesincespell = 0;
            }
            if (Input.GetKeyDown("left"))
            {
                Fire(new Vector2(spellForce * -1, 0));
                timesincespell = 0;
            }

            if (Input.GetKeyDown("up"))
            {
                Fire(new Vector2(0, spellForce));
                timesincespell = 0;
            }

            if (Input.GetKeyDown("down"))
            {
                Fire(new Vector2(0, spellForce * -1));
                timesincespell = 0;
            }

        }

        void Fire(Vector2 direction)
        {
            GameObject projectileInstance = Instantiate(spell, transform.position, Quaternion.identity);
            projectileInstance.GetComponent<Rigidbody2D>().velocity = direction;
            StartCoroutine(Expire(projectileInstance, 3f));
            fireSound.Play();
        }

        void DropBomb()
        {
            GameObject projectileInstance = Instantiate(bomb, transform.position, Quaternion.identity);
            StartCoroutine(Explode(projectileInstance, 3f, 2));
            fireInPlaceSound.Play();
        }

        IEnumerator Expire(GameObject toDestroy, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(toDestroy);
        }

        IEnumerator Explode(GameObject bomb, float timer, float explosionRadius)
        {
            yield return new WaitForSeconds(timer);
            Destroy(bomb);
        }


    }

    // Called from LevelUp UI
    public void IncreaseAttackSpeed()
    {
        secondspershot = secondspershot *  .80f;
        Debug.Log("IncreaseAttackSpeed was called" + secondspershot);

    }
}

