using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float startSpeed = 100f;
    [HideInInspector]
    public float speed;
    public static int enemiesKilled = 0;
    public float health = 100;
    public int value = 50;
    private Transform target;
 
    private bool isDead = false;
    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1 - pct);
    }
    void Die()
    {
        isDead = true;

        WaveSpawner.ExistingEnemies--;
        Destroy(gameObject);
        enemiesKilled += 1;
        PlayerStats.Money += 10;
    }
}
