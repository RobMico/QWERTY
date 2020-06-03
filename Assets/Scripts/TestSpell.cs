using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectTile;
    public float Damage;
    public float projectTileForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
           GameObject Bullet= Instantiate(projectTile, transform.position, Quaternion.identity);
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pos = transform.position;
            Vector2 direction = (mousepos - pos).normalized;
            Bullet.GetComponent<Rigidbody2D>().velocity = direction * projectTileForce;
            Bullet.GetComponent<TestBullet>().Damage = Damage;
        }
    }
}
