using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy; // Primer tipo de enemigo
    [SerializeField] GameObject boss; // Segundo tipo de enemigo
    [SerializeField] int enemies; // Cantidad total de enemigos
    [SerializeField] List<Transform> enemySpawn; // Lista de posiciones de spawn de enemigos
    bool playerIsDead = false;

    [Header("Tiempo de aparición del enemigo")]
    [SerializeField] float spawnTime;

    [Header("Probabilidad del segundo enemigo")]
    [Range(0, 1)] // Rango de probabilidad entre 0 y 1
    [SerializeField] float secondEnemyProbability = 0.2f; // Probabilidad inicial del segundo enemigo

    Countdown countdown;

    void Start()
    {
        countdown = GetComponent<Countdown>();
        GameEvents.PlayerDead.AddListener(OnPlayerDeath);
        GameEvents.OnCountdownZero.AddListener(SpawnWave);
    }

    void OnPlayerDeath()
    {
        playerIsDead = true;
    }

    void SpawnWave()
    {
        StartCoroutine(SpawnWaveCoroutine());
    }

    IEnumerator SpawnWaveCoroutine()
    {
        for (int i = 0; i < enemies; i++)
        {
            if (!playerIsDead)
            {
                Vector3 spawnPos = enemySpawn[Random.Range(0, enemySpawn.Count)].position;

                // Determinar si se instanciará el segundo enemigo
                if (Random.value <= secondEnemyProbability)
                {
                    GameObject.Instantiate(boss, spawnPos, Quaternion.identity);
                }
                else
                {
                    GameObject.Instantiate(enemy, spawnPos, Quaternion.identity);
                }
            }

            yield return new WaitForSeconds(spawnTime);
        }

        countdown.ResetTime(); // Reiniciar el tiempo cuando se acabe la oleada
    }
}
