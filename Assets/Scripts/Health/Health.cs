using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int health;

    [SerializeField]
    private int startHealth;

    [SerializeField]
    private int maxHealth = 3;


    public int CurrentHealth => health;
    public int StartHealth => startHealth;
    public int MaxHealth => maxHealth;

    public event Action<int> OnHealthChanged;

    private void Awake()
    {
        health = startHealth;
    }

    public void SetStartHealth(int amount)
    {
        startHealth = amount;
    }
    public void SetMaxHealth(int amount)
    {
        maxHealth = amount;
    }

    public void AddHealth(int amount)
    {
        if (amount == 0)
            return;

        health += amount;
        health = health > maxHealth ? maxHealth : health;
        OnHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
