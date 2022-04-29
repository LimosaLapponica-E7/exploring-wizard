using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHit : MonoBehaviour
{
    public AudioSource playerHit;

    public static EnemyBulletHit instance;
    void Awake()
    {
        instance = this;
    }
    public void playSound()
    {
        playerHit.Play();
    }
}
