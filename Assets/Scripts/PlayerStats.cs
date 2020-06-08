using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats playerStats;

    public GameObject player;

    public float maxHealth;
    public float health;

    private void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else 
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
    public void DealDamage(float Damage)
    {
        health -= Damage;
        CheckDeath();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
