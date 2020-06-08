using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectTile;
    public float Damage;
    public float cooldown=0.25f;
    public float projectTileForce;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(1))
        {

            
            StartCoroutine(Fire());
            
        }

    }


    private IEnumerator Fire()
    {

        //       if (IsAnimationPlaying("Player_Attack_Right") || IsAnimationPlaying("Player_Attack_Left") ||
        //              IsAnimationPlaying("Player_Attack_Up") || IsAnimationPlaying("Player_Attack_Down"))
        //       {
        if (!animator.GetBool("isAttack"))
        {
            animator.SetBool("isAttack", true);
            //animator.SetBool("isAttack", false);
            GameObject Bullet = Instantiate(projectTile, transform.position, Quaternion.identity);
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pos = transform.position;
            Vector2 direction = (mousepos - pos).normalized;
            Bullet.GetComponent<Rigidbody2D>().velocity = direction * projectTileForce;
            Bullet.GetComponent<TestBullet>().Damage = Damage;
            yield return new WaitForSeconds(cooldown);
            animator.SetBool("isAttack", false);
        }
//      }
    }
}
