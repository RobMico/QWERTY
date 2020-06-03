using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReceiveDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth;
    public float health;
    void Start()
    {
        health = maxHealth;
    }
    public void DealDamage(float Damage)
    {
        health -= Damage;
        CheckDeath();
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
