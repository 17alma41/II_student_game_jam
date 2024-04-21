using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 3;
    bool playerIsDead = false;

    [Header("Vida del enemigo")]
    [SerializeField] int maxHealth;
    int currentHealth = 0;


    [SerializeField] Transform playerTransform;

    [Header("Material que suelta")]
    [SerializeField] GameObject prefab;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        currentHealth = maxHealth;

        GameEvents.PlayerDead.AddListener(OnPlayerDeath);
    }

    void Update()
    {
        EnemyToPlayer();
    }

    IEnumerator Hurt(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Instantiate(
                prefab,
                transform.position,
                Quaternion.identity);

            Destroy(gameObject);
        }

        yield return null;
    }

    public void ApplyDamage(int damage)
    {
        StartCoroutine(Hurt(damage));
    }
    void OnPlayerDeath()
    {
        playerIsDead = true;
    }

    void EnemyToPlayer()
    {
        Vector3 enemyToPlayer = (playerTransform.position - transform.position).normalized;

        if (playerIsDead)
            transform.position -= enemyToPlayer * speed * Time.deltaTime;
        else
            transform.position += enemyToPlayer * speed * Time.deltaTime;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats playerHealth = collision.gameObject.GetComponent<PlayerStats>();
            playerHealth.ApplyDamage(1);

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            ApplyDamage(1);

            

            //Destruir el proyectil cuando choca contra el enemigo
            Destroy(collision.gameObject);
        }
    }
}
