using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int maxHealth;
    int currentHealth = 0;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        //Esta coroutina es para recibir el daño que hace el enemigo al jugador.
        StartCoroutine(GetDamage(damage));
    }

    IEnumerator GetDamage(int damage)
    {
        currentHealth -= damage;
        print("Vida del personje" + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameEvents.PlayerDead.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }

        yield return null;
    }


    public void Heal(int health)
    {
        currentHealth += health;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
