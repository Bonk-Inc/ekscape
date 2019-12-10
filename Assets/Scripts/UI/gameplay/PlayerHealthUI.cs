using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]
    private Health health;

    [SerializeField]
    private GameObject healthParent;

    [SerializeField]
    private GameObject fullHeartPrefab, emptyHeartPrefab;

    private void Start()
    {
        InitHealth();

        health.OnHealthChanged += (h) => UpdateHealth(); 
    }

    private void InitHealth()
    {
        for (int i = 0; i < health.MaxHealth; i++)
        {
            
            if(health.CurrentHealth > i)
            {
                spawnHeart(fullHeartPrefab);
            }
            else
            {
                spawnHeart(emptyHeartPrefab);
            }
        }
    }

    private void RemoveHearts()
    {
        for (int i = 0; i < healthParent.transform.childCount; i++)
        {
            Destroy(healthParent.transform.GetChild(i).gameObject);
        }
    }

    private void spawnHeart(GameObject heartPrefab)
    {
        var heart = Instantiate(heartPrefab);
        heart.transform.SetParent(healthParent.transform, false);
    }
    public void UpdateHealth()
    {
        RemoveHearts();
        InitHealth();
    }
    

}
