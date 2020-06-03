using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{

    public float Damage;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Enemy")
        {
            if (collision.tag == "Player")
            {
                Destroy(gameObject);
                return;
            }
        }
        if (gameObject.tag == "Player")
        {
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<EnemyReceiveDamage>().DealDamage(Damage);
                Destroy(gameObject);
                return;
            }
        }
    }
}
