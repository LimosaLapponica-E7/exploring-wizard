using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource playerHitSound;
    [SerializeField] private int dealSlimeDamagePoints;
    [SerializeField] private int dealBirdDamagePoints;
    [SerializeField] private int obstacleDamagePoints;

    float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    public static Player instance;

    /// <summary>
    /// Dodge distance/speed that gets processed every frame. Might wanna keep this low! 
    /// </summary>
    private float _dodgeSpeed = 6000;

    /// <summary>
    /// How long dodges last.
    /// </summary>
    private float _dodgeTime = .25f;

    /// <summary>
    /// Reference to the dodging coroutine.
    /// </summary>
    private Coroutine _dodging;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift) && _dodging == null)
        {
            _dodging = StartCoroutine(DodgeCoroutine());
 
        }
    }
    void FixedUpdate()
{

    if (inputHorizontal != 0 || inputVertical != 0)
    {

        if (inputHorizontal != 0 || inputVertical != 0)
        {
            inputHorizontal *= speedLimiter;
            inputVertical *= speedLimiter;
        }
        rb.velocity = new Vector2(inputHorizontal * moveSpeed, inputVertical * moveSpeed);
    }
    else
    {
        rb.velocity = new Vector2(0f, 0f);
    }


}

private IEnumerator DodgeCoroutine()
{
    var endOfFrame = new WaitForEndOfFrame();
    var rigidbody = GetComponent<Rigidbody2D>();

    for (float timer = 0; timer < _dodgeTime; timer += Time.deltaTime)
    {
        rigidbody.MovePosition(transform.position + (transform.forward * (moveSpeed * Time.deltaTime)));

            yield return endOfFrame;
    }
    _dodging = null;
}

void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slime"){
            PlayerStats.instance.dealDamage(5);
            playerHitSound.Play();
        }

        if (collision.gameObject.tag == "Bird")
        {
            PlayerStats.instance.dealDamage(dealBirdDamagePoints);
            playerHitSound.Play();
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            PlayerStats.instance.dealDamage(obstacleDamagePoints);
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "Gold")
        {
            PlayerStats.instance.giveGold(5);
            Destroy(gameObject);
        }
    }

    public void IncreaseMovementSpeed()
    {
        moveSpeed = moveSpeed * 1.25f;
        Debug.Log("Move Speed increased by " + moveSpeed);
    }

}
