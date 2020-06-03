using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public float Cooldown;
    public float Damage;
    public float BulletForce;
    void Start()
    {
        StartCoroutine(StartShooting());
    }
    IEnumerator StartShooting()
    {
        Debug.Log("i'm here");
        yield return new WaitForSeconds(Cooldown);
        if (player != null)
        {
            GameObject Bullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Vector2 mousepos = player.GetComponent<Transform>().position;
            Vector2 pos = transform.position;
            Vector2 direction = (mousepos - pos).normalized;
            Bullet.GetComponent<Rigidbody2D>().velocity = direction * BulletForce;
            Bullet.GetComponent<TestBullet>().Damage = Damage;
        }
        StartCoroutine(StartShooting());
    }
}
